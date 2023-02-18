using System.IO;
using CommunAxiom.Ledger.Api.Contracts;
using ProtoBuf;
using Sawtooth.Sdk;
using Sawtooth.Sdk.Client;

namespace CommunAxiom.Ledger.ComaxProcessor
{
    public class IntKeyTransaction : ITransaction<IntKeyEntity>
    {
        public byte[] CreateTransaction(IntKeyEntity data)
        {
            var signer = new Signer();

            var settings = new EncoderSettings()
            {
                BatcherPublicKey = signer.GetPublicKey().ToHexString(),
                SignerPublickey = signer.GetPublicKey().ToHexString(),
                FamilyName = Processor.COMAX_FAMILY,
                FamilyVersion = Processor.VERSION,
            };
            
            settings.Inputs.Add(Processor.COMAX_FAMILY_PREFIX);
            settings.Outputs.Add(Processor.COMAX_FAMILY_PREFIX);
            
            var encoder = new Encoder(settings, signer.GetPrivateKey());

            using var memoryStream = new MemoryStream();
            Serializer.Serialize(memoryStream, data);
            var byteArray = memoryStream.ToArray();

            return encoder.EncodeSingleTransaction(byteArray);
        }

    }
}