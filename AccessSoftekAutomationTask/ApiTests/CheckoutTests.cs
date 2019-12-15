using System.Collections.Generic;
using AccessSoftekCore.HttpClient;
using AccessSoftekCore.HttpClient.Models;
using AccessSoftekPages.Models;
using Bogus;
using FluentAssertions;
using FluentAssertions.Execution;
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
        [TestCase("")]
        [TestCase("Test coupon")]
        [Description("API correctly calculates discount percent")]
        public void TC_01_VerifyDiscountPercentCalculation(string coupon)
        {
            // act
            var discount = _client.GetCouponDiscount(coupon).Discount;

            // assert
            discount.Should().Be(coupon.Length, "Discount amount is the length of coupon string");
        }

        private static IEnumerable<TestCaseData> TestDatas()
        {
            var faker = new Faker();

            yield return new TestCaseData(new CheckoutModel
            {
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                PaymentMethod = "Credit Card",
                NameOnCard = faker.Internet.UserName(),
                CreditCardNumber = faker.Random.Number(17, 99).ToString(),
                Expiration = faker.Date.Future(1).ToString("MM/yyyy"),
                Cvv = faker.Finance.CreditCardCvv()
            });
            yield return new TestCaseData(new CheckoutModel
            {
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                PaymentMethod = "Credit Card",
                NameOnCard = faker.Internet.UserName(),
                CreditCardNumber = faker.Random.Number(15).ToString(),
                Expiration = faker.Date.Future(1).ToString("MM/yyyy"),
                Cvv = faker.Finance.CreditCardCvv()
            });
        }

        [Test]
        [TestCaseSource(nameof(TestDatas))]
        [Description("API returns error when credit card number length not equals 16")]
        public void TC_02_VerifyErrorForInvalidCreditCard(CheckoutModel model)
        {
            // act
            var response = _client.Checkout(model);

            // assert
            using (new AssertionScope())
            {
                response.Should().NotBeNull();
                response.Should().BeOfType<CheckoutResponse>();
                response.Event.Should().BeOfType<CheckoutModel>();
                response.Success.Should().BeFalse();
                response.Message.Should().Be("Invalid Card Number");
            }
        }
    }
}