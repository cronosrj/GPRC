using ProtoBuf;

namespace GrpcCommons.Protos
{
    [ProtoContract]
    public class HelloRequest
    {
        [ProtoMember(1)]
        public string Name { get; set; }
    }
}