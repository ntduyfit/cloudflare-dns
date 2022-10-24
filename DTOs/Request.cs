using Newtonsoft.Json;

namespace cloudflare_client.DTOs
{
    public class RequestBody
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("content")]
        public string Content { get; set; }
        
        [JsonProperty("ttl")]
        public int Ttl { get; set; }
    }
    
    
    public class Payload
    {
        public string name { get; set; }
    }
}