using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace cloudflare_client.DTOs
{
    public class Error
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        
        [JsonProperty("message")]
        public string Message { get; set; }
    }

    public class Result
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Response
    {
        [JsonProperty("result")]
        public Result Result { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
        
        [JsonProperty("errors")]
        public List<Error> Errors { get; set; }
        
    }
}