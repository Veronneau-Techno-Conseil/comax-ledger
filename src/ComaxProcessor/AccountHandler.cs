using PeterO.Cbor;
using Sawtooth.Sdk;
using Sawtooth.Sdk.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunAxiom.Ledger.ComaxProcessor
{
    internal class AccountHandler : Sawtooth.Sdk.Processor.ITransactionHandler
    {
        readonly string PREFIX = ProcessorConstants.COMAX_FAMILY.ToByteArray().ToSha512().ToHexString().Substring(0, 6);
        T[] Arrayify<T>(T obj) => new[] { obj };

        public string FamilyName => ProcessorConstants.COMAX_FAMILY;

        public string Version => "1.0.0";

        public string[] Namespaces => Arrayify(PREFIX);

        

        public Task ApplyAsync(TpProcessRequest request, TransactionContext context)
        {
            //context.g

            var obj = CBORObject.DecodeFromBytes(request.Payload.ToByteArray());
            
            var name = obj["Name"].AsString();
            var verb = obj["Verb"].AsString().ToLowerInvariant();

            switch (verb)
            {
                case "reg":
                    break;
                default:
                    throw new InvalidTransactionException($"Unknown verb {verb}");
            }
            throw new NotImplementedException();
        }
    }
}
