using CommunAxiom.Ledger.ProtobufTests.Helper;
using FluentAssertions;
using Google.Protobuf;
using NUnit.Framework;
using ProtoBuf;

namespace CommunAxiom.Ledger.ProtobufTests
{
    [TestFixture]
    public class ProtobufTest
    {
        [Test]
        public void ProtobufAndProtobufNetShouldBeEqual()
        {
            var person = new Person();
            using var file1 = new MemoryStream();
            person.WriteTo(file1);

            var personEntity = new PersonEntity();
            using var file2 = new MemoryStream();
            Serializer.Serialize(file2, personEntity);

            var result = file1.StreamEquals(file2);

            result.Should().Be(true);
        }
    }
}