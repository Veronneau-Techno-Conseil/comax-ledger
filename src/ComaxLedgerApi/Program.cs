using ComaxLedgerApi;
using CommunAxiom.Ledger.Api.Contracts;
using CommunAxiom.Ledger.ComaxProcessor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<HttpClientHelper>();
builder.Services.AddTransient<ITransaction<IntKeyEntity>, IntKeyTransaction>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI();
// }

app.UseAuthorization();

app.MapControllers();

app.Run();