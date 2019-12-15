using AccessSoftekCore.BasePageObjects;
using AccessSoftekPages.Pages;
using FluentAssertions;
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
            // act
            this._checkoutFormPage.ClickContinueToCheckout();

            // assert
            this._checkoutFormPage.AllValidationMessagesAreDisplayed().Should().BeTrue("Required fields validations are expected if the inputs are empty");
        }
    }
}