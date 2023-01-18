using CommunAxiom.Ledger.ComaxProcessor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeterO.Cbor;
using Sawtooth.Sdk;
using Sawtooth.Sdk.Client;

namespace ComaxLedgerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComaxSample : ControllerBase
    {
        [Route("Set")]
        [HttpPost]
        public async Task<object> Set()
        {
            var obj = CBORObject.NewMap()
                .Add("Name", "set")
                .Add("Verb", 10);

            var signer = new Signer();

            var settings = new EncoderSettings()
            {
                BatcherPublicKey = signer.GetPublicKey().ToHexString(),
                SignerPublickey = signer.GetPublicKey().ToHexString(),
                FamilyName = ProcessorConstants.COMAX_FAMILY,
                FamilyVersion = "1.0",
            };
            settings.Inputs.Add(ProcessorConstants.COMAX_FAMILY_PREFIX);
            settings.Outputs.Add(ProcessorConstants.COMAX_FAMILY_PREFIX);
            var encoder = new Encoder(settings, signer.GetPrivateKey());

            var payload = encoder.EncodeSingleTransaction(obj.EncodeToBytes());

            var content = new ByteArrayContent(payload);
            content.Headers.Add("Content-Type", "application/octet-stream");

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync("http://localhost:8008/batches", content);
            return await response.Content.ReadAsStringAsync();
        }
        
        [Route("Increment")]
        [HttpPost]
        public async Task<object> Increment()
        {
            var obj = CBORObject.NewMap()
                .Add("Name", "inc");
            
            var signer = new Signer();

            var settings = new EncoderSettings()
            {
                BatcherPublicKey = signer.GetPublicKey().ToHexString(),
                SignerPublickey = signer.GetPublicKey().ToHexString(),
                FamilyName = ProcessorConstants.COMAX_FAMILY,
                FamilyVersion = "1.0"
            };
            settings.Inputs.Add(ProcessorConstants.COMAX_FAMILY_PREFIX);
            settings.Outputs.Add(ProcessorConstants.COMAX_FAMILY_PREFIX);
            var encoder = new Encoder(settings, signer.GetPrivateKey());

            var payload = encoder.EncodeSingleTransaction(obj.EncodeToBytes());

            var content = new ByteArrayContent(payload);
            content.Headers.Add("Content-Type", "application/octet-stream");

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync("http://localhost:8008/batches", content);
            return await response.Content.ReadAsStringAsync();
        }
        
        [Route("Decrement")]
        [HttpPost]
        public async Task<object> Decrement()
        {
            var obj = CBORObject.NewMap()
                .Add("Name", "dec");
            
            var signer = new Signer();

            var settings = new EncoderSettings()
            {
                BatcherPublicKey = signer.GetPublicKey().ToHexString(),
                SignerPublickey = signer.GetPublicKey().ToHexString(),
                FamilyName = ProcessorConstants.COMAX_FAMILY,
                FamilyVersion = "1.0"
            };
            settings.Inputs.Add(ProcessorConstants.COMAX_FAMILY_PREFIX);
            settings.Outputs.Add(ProcessorConstants.COMAX_FAMILY_PREFIX);
            var encoder = new Encoder(settings, signer.GetPrivateKey());

            var payload = encoder.EncodeSingleTransaction(obj.EncodeToBytes());

            var content = new ByteArrayContent(payload);
            content.Headers.Add("Content-Type", "application/octet-stream");

            var httpClient = new HttpClient();

            var response = await httpClient.PostAsync("http://localhost:8008/batches", content);
            return await response.Content.ReadAsStringAsync();
        }
        
    }
}
