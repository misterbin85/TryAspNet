using Newtonsoft.Json;

namespace AccessSoftekPages.Models
{
    public sealed class CheckoutModel
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("paymentMethod")]
        public string PaymentMethod { get; set; }

        [JsonProperty("cc-name")]
        public string NameOnCard { get; set; }

        [JsonProperty("cc-number")]
        public string CreditCardNumber { get; set; }

        [JsonProperty("cc-expiration")]
        public string Expiration { get; set; }

        [JsonProperty("cc-cvv")]
        public string Cvv { get; set; }
    }
}