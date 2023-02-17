using CommunAxiom.Ledger.Api.Contracts;
using CommunAxiom.Ledger.ComaxProcessor;
using Microsoft.AspNetCore.Mvc;
using ProtoBuf;
using Sawtooth.Sdk;
using Sawtooth.Sdk.Client;

namespace ComaxLedgerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntKeyController : ControllerBase
    {
        [Route("Set")]
        [HttpPost]
        public async Task<object> Set()
        {
            var data = new IntKeyEntity { Name = "ComaxFamily", Verb = "set", Value = 10 };

            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync("http://localhost:8008/batches", CreateContent(data));
            
            return await response.Content.ReadAsStringAsync();
        }
        
        private ByteArrayContent CreateContent(IntKeyEntity data)
        {
            var payload = ConfigureSettings(data);
            var content = new ByteArrayContent(payload);
            content.Headers.Add("Content-Type", "application/octet-stream");
            return content;
        }
        private byte[] ConfigureSettings(IntKeyEntity data)
        {
            var signer = new Signer();

            var settings = new EncoderSettings()
            {
                BatcherPublicKey = signer.GetPublicKey().ToHexString(),
                SignerPublickey = signer.GetPublicKey().ToHexString(),
                FamilyName = ProcessorConstants.COMAX_FAMILY,
                FamilyVersion = ProcessorConstants.VERSION,
            };
            settings.Inputs.Add(ProcessorConstants.COMAX_FAMILY_PREFIX);
            settings.Outputs.Add(ProcessorConstants.COMAX_FAMILY_PREFIX);
            var encoder = new Encoder(settings, signer.GetPrivateKey());

            using var memoryStream = new MemoryStream();
            Serializer.Serialize(memoryStream, data);
            var byteArray = memoryStream.ToArray();

            return encoder.EncodeSingleTransaction(byteArray);
        }

        [Route("Increment")]
        [HttpPost]
        public async Task<object> Increment()
        {
            var data = new IntKeyEntity { Name = "ComaxFamily", Verb = "inc" };
            
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync("http://localhost:8008/batches", CreateContent(data));
            
            return await response.Content.ReadAsStringAsync();
        }

        [Route("Decrement")]
        [HttpPost]
        public async Task<object> Decrement()
        {
            var data = new IntKeyEntity { Name = "ComaxFamily", Verb = "dec" };

            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync("http://localhost:8008/batches", CreateContent(data));
            
            return await response.Content.ReadAsStringAsync();
        }
    }
}