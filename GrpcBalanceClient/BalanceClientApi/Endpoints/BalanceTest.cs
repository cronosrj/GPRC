using System.Diagnostics;
using Grpc.Core;
using GrpcCommons.Protos;

namespace BalanceClientApi.Endpoints
{
    public static class BalanceTest
    {
        public static void MapStartEndpoint(
			this IEndpointRouteBuilder app)
		{
			app.MapGet("Start", StartAsync);
		}

        public static async Task<IResult> StartAsync()
		{		
            //var channel = GrpcChannel.ForAddress("http://localhost:5169");

            var calls = 50;

            while(calls != 0)
            {
                HelloReply result;

                try
                {
                    var client = GrpcFactory.GetGreeterService();
                    result = await client.SayHelloAsync(                   
                        new HelloRequest 
                        { 
                            Name = "GreeterClient" 
                        });
                }
                catch(RpcException ex)
                {
                    Debug.WriteLine(ex.Message);
                    
                    var client = GrpcFactory.GetGreeterService();

                    result = await client.SayHelloAsync(                   
                        new HelloRequest 
                        { 
                            Name = "GreeterClient" 
                        });
                }
                

                Debug.WriteLine(result.Message);

                calls--;

                await Task.Delay(TimeSpan.FromSeconds(2));
            }
 
            return Results.Ok();
		}
    }
}