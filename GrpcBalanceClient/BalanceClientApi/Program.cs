using BalanceClientApi.Endpoints;
using GrpcCommons.Services.Abstractions;
using ProtoBuf.Grpc.ClientFactory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCodeFirstGrpcClient<IGreeterService>(o => {
        
        // Address of grpc server
        o.Address = new Uri("http://localhost:5169");
        
        // another channel options (based on best practices docs on https://docs.microsoft.com/en-us/aspnet/core/grpc/performance?view=aspnetcore-6.0)
        o.ChannelOptionsActions.Add(options =>
        {
            options.HttpHandler = new SocketsHttpHandler()
            {
                // keeps connection alive
                PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
                KeepAlivePingDelay = TimeSpan.FromSeconds(60),
                KeepAlivePingTimeout = TimeSpan.FromSeconds(30),
                
                // allows channel to add additional HTTP/2 connections
                EnableMultipleHttp2Connections = true
            };
        });
    });

var app = builder.Build();

app.MapStartEndpoint();

app.Run();
