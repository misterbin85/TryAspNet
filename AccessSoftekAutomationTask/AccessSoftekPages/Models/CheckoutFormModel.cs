namespace AccessSoftekPages.Models
{
    public sealed class CheckoutFormModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameOnCard { get; set; }
        public string CreditCardNumber { get; set; }
        public string Expiration { get; set; }
        public string Cvv { get; set; }
    }
}