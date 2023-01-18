using ProtoBuf;

namespace CommunAxiom.Ledger.ProtobufTests
{
    [ProtoContract]
    public class RoleEntity
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Title { get; set; }
    }
}