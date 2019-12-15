using AccessSoftekPages.Models;
using Newtonsoft.Json;

namespace AccessSoftekCore.HttpClient.Models
{
    public sealed class CheckoutResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("event")]
        public CheckoutModel Event { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}