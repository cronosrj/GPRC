using ProtoBuf;

namespace GrpcCommons.Protos
{
    [ProtoContract]
    public class HelloReply
    {
        [ProtoMember(1)]
        public string Message { get; set; }
    }
}