using Sawtooth.Sdk.Processor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CommunAxiom.Ledger.ComaxProcessor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var validatorAddress = args.Any() ? args.First() : "tcp://127.0.0.1:4004";

            var processor = new TransactionProcessor(validatorAddress);
            
            processor.AddHandler(new AccountHandler());
            processor.Start();

            Console.CancelKeyPress += delegate { processor.Stop(); };
            Sawtooth.Sdk.Client.ValidatorClient validatorClient = Sawtooth.Sdk.Client.ValidatorClient.Create("");
            var state = await validatorClient.GetBatchAsync("fwerfe");
            
        }

    }
}
