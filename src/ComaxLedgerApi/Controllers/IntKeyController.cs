using CommunAxiom.Ledger.Api.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ComaxLedgerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntKeyController : ControllerBase
    {
        private readonly HttpClientHelper _httpClient;
        private readonly IConfigurationSection _sawtoothConfig;
        
        public IntKeyController(HttpClientHelper httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _sawtoothConfig = configuration.GetSection("SawtoothConfig:BatchUrl");
        }

        [Route("Set")]
        [HttpPost]
        public async Task<object> Set()
        {
            var data = new IntKeyEntity { Name = "ComaxFamily", Verb = "set", Value = 10 };

            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(_sawtoothConfig.Value, _httpClient.CreateContent(data));
            
            return await response.Content.ReadAsStringAsync();
        }
        
        [Route("Increment")]
        [HttpPost]
        public async Task<object> Increment()
        {
            var data = new IntKeyEntity { Name = "ComaxFamily", Verb = "inc" };
            
            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(_sawtoothConfig.Value, _httpClient.CreateContent(data));
            
            return await response.Content.ReadAsStringAsync();
        }

        [Route("Decrement")]
        [HttpPost]
        public async Task<object> Decrement()
        {
            var data = new IntKeyEntity { Name = "ComaxFamily", Verb = "dec" };

            var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(_sawtoothConfig.Value, _httpClient.CreateContent(data));
            
            return await response.Content.ReadAsStringAsync();
        }
    }
}