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
        public static void Main(string[] args)
        {
            var validatorAddress = "tcp://127.0.0.1:4004";
            
            var processor = new TransactionProcessor(validatorAddress);
            
            processor.AddHandler(new ComaxSampleHandler());
            processor.Start();

            Console.CancelKeyPress += delegate { processor.Stop(); };
        }

    }
}
