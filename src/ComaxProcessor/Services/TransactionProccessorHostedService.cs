using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Sawtooth.Sdk.Processor;

namespace CommunAxiom.Ledger.ComaxProcessor
{
    public class TransactionProccessorHostedService : IHostedService, IDisposable
    {
        private readonly TransactionProcessor _transactionProcessor;
        public TransactionProccessorHostedService(IConfiguration configuration)
        {
            var validatorUrl = configuration.GetSection("SawtoothConfig:ValidatorUrl");
            
            _transactionProcessor = new TransactionProcessor(validatorUrl.Value);
        }
        public Task StartAsync(CancellationToken cancellationToken)
        {
            _transactionProcessor.AddHandler(new IntKeyTransactionHandler());
            _transactionProcessor.Start();
            
            Console.WriteLine("IntKeyTransactionHandler has been started!");
            
            // Console.CancelKeyPress += delegate { _transactionProcessor.Stop(); };
            return  Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _transactionProcessor.Stop();
            return  Task.CompletedTask;
        }

        public void Dispose()
        {
            _transactionProcessor.Stop();
        }
    }
}