using AccessSoftekCore.HttpClient;
using FluentAssertions;
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
            // arrange
            var coupon = "Test coupon";

            // act
            var discount = _client.GetCouponDiscount(coupon).Discount;

            // assert
            discount.Should().Be(coupon.Length, "Discount amount is the length of coupon string");
        }
    }
}