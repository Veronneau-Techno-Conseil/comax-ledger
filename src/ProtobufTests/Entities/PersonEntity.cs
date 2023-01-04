using ProtoBuf;

namespace CommunAxiom.Ledger.ProtobufTests
{
    [ProtoContract]
    [Serializable]
    public class PersonEntity
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        
        [ProtoMember(2)]
        public string FirstName { get; set; }
        
        [ProtoMember(3)]
        public string LastName { get; set; }
        
        [ProtoMember(4)]
        public double Salary { get; set; }
        
        [ProtoMember(5)]
        public bool IsActive { get; set; }
        
        [ProtoMember(6)]
        public List<string> Assets { get; set; }
        
        [ProtoMember(7)]
        public TimeSpan Start { get; set; }
        
        [ProtoMember(8)]
        public TimeSpan Duration { get; set; }
        
        [ProtoMember(9)]
        public TimeSpan BirthDate { get; set; }
        
        [ProtoMember(10)]
        public TimeSpan Age { get; set; }

        [ProtoMember(11)]
        public List<RoleEntity> Roles { get; set; }
        
        [ProtoMember(12)]
        public IDictionary<string, string> Attributes { get; set; }
    }
}