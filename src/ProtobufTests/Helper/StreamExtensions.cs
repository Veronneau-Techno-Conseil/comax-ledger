namespace CommunAxiom.Ledger.ProtobufTests.Helper
{
    public static class StreamExtensions
    {
        public static bool StreamEquals(this Stream self, Stream other)
        {
            if (self == other)
            {
                return true;
            }

            if (self == null || other == null)
            {
                throw new ArgumentNullException(self == null ? "self" : "other");
            }

            if (self.Length != other.Length)
            {
                return false;
            }

            for (var i = 0; i < self.Length; i++)
            {
                int aByte = self.ReadByte();
                int bByte = other.ReadByte();
                if (aByte.CompareTo(bByte) != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}