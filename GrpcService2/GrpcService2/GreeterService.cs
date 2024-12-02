using System.Diagnostics;
using GrpcCommons.Protos;
using GrpcCommons.Services.Abstractions;


namespace GrpcService2.Services;

public class GreeterService : IGreeterService
{
    public Task<HelloReply> SayHelloAsync(
        HelloRequest request)
    {
        Debug.WriteLine("Request received");

        return Task.FromResult(new HelloReply
        {
            Message = $"Message from GrpcService02"
        });
    }
}
