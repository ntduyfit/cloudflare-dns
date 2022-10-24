using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using cloudflare_client.DTOs;
using cloudflare_client.Utils;
using Newtonsoft.Json;

namespace cloudflare_client.Services
{
    public interface ICloudflareService
    {
        Task<Response> AddDnsRecord(string aName);
    }

    internal class CloudflareService : ICloudflareService
    {
        // private readonly string _apiKey;
        private readonly HttpClient _httpClient;

        public CloudflareService(string xAuthKey, string xAuthEmail, string zoneId)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress =
                new Uri($"https://api.cloudflare.com/client/v4/zones/{zoneId}/dns_records");
            _httpClient.DefaultRequestHeaders.Add("X-Auth-Key", xAuthKey);
            _httpClient.DefaultRequestHeaders.Add("X-Auth-Email", xAuthEmail);
        }

        public async Task<Response> AddDnsRecord(string aName)
        {
            var body = new RequestBody()
            {
                Type = DomainTypes.C,
                Name = aName,
                Content = "google.com",
                Ttl = 3600
            };
            var stringPayload = JsonConvert.SerializeObject(body);

            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("", httpContent);

            return JsonConvert.DeserializeObject<Response>(await response.Content.ReadAsStringAsync());
        }
    }
}