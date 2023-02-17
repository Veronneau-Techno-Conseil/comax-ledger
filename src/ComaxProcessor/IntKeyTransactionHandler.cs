using CommunAxiom.Ledger.Api.Contracts;
using Google.Protobuf;
using ProtoBuf;
using Sawtooth.Sdk;
using Sawtooth.Sdk.Processor;

namespace CommunAxiom.Ledger.ComaxProcessor
{
    public class IntKeyTransactionHandler : ITransactionHandler
    {
        T[] Arrayify<T>(T obj) => new[] { obj };

        public string FamilyName => ProcessorConstants.COMAX_FAMILY;

        public string Version => ProcessorConstants.VERSION;

        public string[] Namespaces => new[] { ProcessorConstants.COMAX_FAMILY_PREFIX };

        public async Task ApplyAsync(TpProcessRequest request, TransactionContext context)
        {
            using var payload = new MemoryStream(request.Payload.ToByteArray());
            var data = Serializer.Deserialize<IntKeyEntity>(payload);
            
            switch (data.Verb)
            {
                case "set":
                    var value =data.Value;
                    await SetValue(data.Name, value, context);
                    break;
                case "inc":
                    await Increase(data.Name, context);
                    break;
                case "dec":
                    await Decrease(data.Name, context);
                    break;
                default:
                    throw new InvalidTransactionException($"Unknown verb {data.Verb}");
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