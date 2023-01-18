using Google.Protobuf;
using PeterO.Cbor;
using Sawtooth.Sdk;
using Sawtooth.Sdk.Processor;

namespace CommunAxiom.Ledger.ComaxProcessor
{
    public class ComaxSampleHandler : ITransactionHandler
    {
        T[] Arrayify<T>(T obj) => new[] { obj };

        public string FamilyName => ProcessorConstants.COMAX_FAMILY;

        public string Version => "1.0.0";

        public string[] Namespaces => new[] { ProcessorConstants.COMAX_FAMILY_PREFIX };

        public async Task ApplyAsync(TpProcessRequest request, TransactionContext context)
        {
            var obj = CBORObject.DecodeFromBytes(request.Payload.ToByteArray());

            var name = obj["Name"].AsString();
            var verb = obj["Verb"].AsString().ToLowerInvariant();

            switch (verb)
            {
                case "set":
                    var value = obj["Value"].AsInt32();
                    await SetValue(name, value, context);
                    break;
                case "inc":
                    await Increase(name, context);
                    break;
                case "dec":
                    await Decrease(name, context);
                    break;
                default:
                    throw new InvalidTransactionException($"Unknown verb {verb}");
            }
        }
        
        private string GetAddress(string name) => ProcessorConstants.COMAX_FAMILY_PREFIX + name.ToByteArray().ToSha512().TakeLast(32).ToArray().ToHexString();
        
        private async Task SetValue(string name, int value, TransactionContext context)
        {
            var state = await context.GetStateAsync(Arrayify(GetAddress(name)));
            if (state != null && state.Any() && !state.First().Value.IsEmpty)
            {
                throw new InvalidTransactionException($"Verb is 'set', but address is aleady set");
            }

            await context.SetStateAsync(new Dictionary<string, ByteString>
            {
                { GetAddress(name), ByteString.CopyFrom(BitConverter.GetBytes(value)) }
            });
            Console.WriteLine($"Value for {name} decreased to {value}");
        }
        
        private async Task Decrease(string name, TransactionContext context)
        {
            var state = await context.GetStateAsync(Arrayify(GetAddress(name)));
            if (state != null && state.Any() && !state.First().Value.IsEmpty)
            {
                var val = BitConverter.ToInt32(state.First().Value.ToByteArray(), 0) - 1;
                await context.SetStateAsync(new Dictionary<string, ByteString>
                {
                    { state.First().Key, ByteString.CopyFrom(BitConverter.GetBytes(val)) }
                });
                Console.WriteLine($"Value for {name} decreased to {val}");
                return;
            }
            throw new InvalidTransactionException($"Verb is 'dec', but state wasn't found at this address");
        }

        private async Task Increase(string name, TransactionContext context)
        {
            var state = await context.GetStateAsync(Arrayify(GetAddress(name)));
            if (state != null && state.Any() && !state.First().Value.IsEmpty)
            {
                var val = BitConverter.ToInt32(state.First().Value.ToByteArray(), 0) + 1;
                await context.SetStateAsync(new Dictionary<string, ByteString>
                {
                    { state.First().Key, ByteString.CopyFrom(BitConverter.GetBytes(val)) }
                });
                Console.WriteLine($"Value for {name} increased to {val}");
                return;
            }
            throw new InvalidTransactionException("Verb is 'inc', but state wasn't found at this address");
        }
    }
}