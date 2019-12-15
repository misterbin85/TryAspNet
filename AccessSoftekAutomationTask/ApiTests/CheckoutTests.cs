using AccessSoftekCore.HttpClient;
using NUnit.Framework;

namespace AccessSoftekAutomationTask.ApiTests
{
    [TestFixture]
    public class CheckoutTests
    {
        private CheckoutClient _client;

        [OneTimeSetUp]
        public void CreateClient()
        {
            _client = new CheckoutClient();
        }

        [Test]
        [Description("API correctly calculates discount percent")]
        public void TC_01_VerifyDiscountPercentCalculation()
        {
            var a = _client.GetCouponDiscount("bla").Discount;
        }
    }
}