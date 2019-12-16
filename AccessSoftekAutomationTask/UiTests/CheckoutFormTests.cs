using System.Collections.Generic;
using AccessSoftekCore.BasePageObjects;
using AccessSoftekPages.Models;
using AccessSoftekPages.Pages;
using Bogus;
using Bogus.DataSets;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace AccessSoftekAutomationTask.UiTests
{
    [TestFixture]
    public class CheckoutFormTests : BaseTest
    {
        private CheckoutFormPage _checkoutFormPage;

        [OneTimeSetUp]
        public void OpenMainPage()
        {
            // arrange
            this._checkoutFormPage = PageFactory.OpenPage<CheckoutFormPage>();
        }

        [Test]
        [Description("All mandatory empty fields should have error description displayed after ‘Continue to checkout’ is pressed")]
        public void TC_01_VerifyMandatoryFieldsValidation()
        {
            // arrange
            var expectedMessages = new List<string>
            {
                "Valid first name is required.",
                "Valid last name is required.",
                "Name on card is required",
                "Credit card number is required",
                "Expiration date required",
                "Security code required"
            };

            // act
            this._checkoutFormPage.PressContinueToCheckout();

            // assert
            using (new AssertionScope())
            {
                this._checkoutFormPage.AllValidationMessagesAreDisplayed().Should().BeTrue("Required fields validations are expected if the inputs are empty");
                this._checkoutFormPage.GetValidationMessages.Should().BeEquivalentTo(expectedMessages);
            }
        }

        [Test]
        [Description("‘Cart’ successfully loaded when user opens the page")]
        public void TC_02_VerifyCartIsLoaded()
        {
            // assert
            this._checkoutFormPage.CartIsLoaded().Should().BeTrue("'Cart' should be loaded upon page open");
        }

        [Test]
        [TestCase("some code")] // can't use multiple TestCases - current implementation one PromoCode per page load
        [Description("Promo code correctly changes ‘Total’ field")]
        public void TC_03_VerifyPromoCodeWorks(string promoCode)
        {
            // assert
            this._checkoutFormPage.Cart.ApplyPromoCode(promoCode).Should().BeTrue("Promo Code calculation discount should be correct");
        }

        [Test]
        [Description("‘Your order was placed’ displayed after form submission")]
        public void TC_04_VerifySuccessfulSubmit()
        {
            // arrange
            var faker = new Faker();
            var model = new CheckoutFormModel
            {
                FirstName = faker.Name.FirstName(),
                LastName = faker.Name.LastName(),
                NameOnCard = faker.Internet.UserName(),
                CreditCardNumber = faker.Finance.CreditCardNumber(CardType.Mastercard).Replace("-", string.Empty),
                Expiration = faker.Date.Future(1).ToString("MM/yyyy"),
                Cvv = faker.Finance.CreditCardCvv()
            };

            // act
            _checkoutFormPage = this._checkoutFormPage.FillTheForm(model).PressContinueToCheckout();

            // assert
            _checkoutFormPage.GetSuccessMessage().Should().Be("Your order was placed. Thank you for purchasing.");
        }
    }
}