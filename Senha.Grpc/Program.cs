using Senha.Grpc.Adapter.Mongo.Entities;
using Senha.Grpc.Services;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

builder.Services.Configure<SenhaDatabaseConfig>(builder.Configuration.GetSection("SenhaDatabase"));
var app = builder.Build();


// Configure the HTTP request pipeline.
app.MapGrpcService<SenhaClienteService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
