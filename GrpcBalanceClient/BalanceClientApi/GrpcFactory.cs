using System.Diagnostics;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcCommons.Services.Abstractions;
using ProtoBuf.Grpc.Client;

namespace BalanceClientApi
{
    public static class GrpcFactory
    {
        public static IDictionary<string, GrpcChannel> Channels { get; private set; } = new Dictionary<string, GrpcChannel>();

        public static IGreeterService GetGreeterService()
        {
            var service01 =  "http://localhost:5169";
            var service02 =  "http://localhost:5269";          

            if (!Channels.ContainsKey(service01))
                Channels.Add(service01, GrpcChannel.ForAddress(service01));
              
            if (!Channels.ContainsKey(service02))
                Channels.Add(service02, GrpcChannel.ForAddress(service02));              

            var channel01 = Channels[service01];
            var channel02 = Channels[service02];

            IGreeterService greeterService = default;

            if (channel01.State == ConnectivityState.Idle || channel01.State == ConnectivityState.Ready)
                greeterService = channel01.CreateGrpcService<IGreeterService>();
            else if(channel02.State == ConnectivityState.Idle || channel02.State == ConnectivityState.Ready)
                greeterService = channel02.CreateGrpcService<IGreeterService>();
            else
                Debug.WriteLine("Nenhum seviço diponível");

            return greeterService;
        }
    }
}