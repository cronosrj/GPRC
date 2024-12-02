using GrpcCommons.Protos;
using ProtoBuf.Grpc.Configuration;

namespace GrpcCommons.Services.Abstractions
{
    [Service]
    public interface IGreeterService
    {
        Task<HelloReply> SayHelloAsync(
            HelloRequest request);
    }
}