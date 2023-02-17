using ProtoBuf;

namespace CommunAxiom.Ledger.Api.Contracts
{
    [ProtoContract]
    [Serializable]
    public class IntKeyEntity
    {
        [ProtoMember(1)] public string Name { get; set; } = string.Empty;
        [ProtoMember(2)] public string Verb { get; set; } = string.Empty;
        [ProtoMember(3)] public int Value { get; set; }
    }
}