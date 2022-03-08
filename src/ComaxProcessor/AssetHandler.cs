using Sawtooth.Sdk.Processor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunAxiom.Ledger.ComaxProcessor
{
    internal class AssetHandler : Sawtooth.Sdk.Processor.ITransactionHandler
    {
        public string FamilyName => throw new NotImplementedException();

        public string Version => throw new NotImplementedException();

        public string[] Namespaces => throw new NotImplementedException();

        public Task ApplyAsync(TpProcessRequest request, TransactionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
