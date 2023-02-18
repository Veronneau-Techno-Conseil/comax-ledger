using CommunAxiom.Ledger.ComaxProcessor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureAppConfiguration((context, config) =>
{
    var env = context.HostingEnvironment;
    config.AddEnvironmentVariables()
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        .AddCommandLine(args);
});

builder.ConfigureServices(services => services.AddHostedService<TransactionProccessorHostedService>());

var app = builder.Build();

app.Run();