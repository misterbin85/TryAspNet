using System.Collections.Generic;
using AccessSoftekCore.BasePageObjects;
using AccessSoftekPages.Pages;
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
    }
}