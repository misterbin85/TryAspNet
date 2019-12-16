using System;
using System.Collections.Generic;
using System.Linq;
using AccessSoftekCore.BasePageObjects;
using AccessSoftekCore.Configs.AppConfigs;
using AccessSoftekCore.Extensions;
using AccessSoftekPages.Components;
using AccessSoftekPages.Models;
using OpenQA.Selenium;

namespace AccessSoftekPages.Pages
{
    public class CheckoutFormPage : BasePage
    {
        public sealed override By ContainerBy => By.CssSelector("div.container");
        public override Uri PageUri => TestAppConfig.MainPageUri;

        private readonly IWebElement _pageContainer;

        #region Lazy

        private Lazy<CartComponent> cartComponent => new Lazy<CartComponent>(() => new CartComponent());

        public CartComponent Cart => cartComponent.Value;

        #endregion Lazy

        private IWebElement SubmitForm => _pageContainer.FindElement(By.TagName("form"));

        private IEnumerable<IWebElement> ValidationElements => SubmitForm.FindElements(By.CssSelector("div.row .invalid-feedback"));

        #region Form inputs

        private IWebElement FirstNameInput => SubmitForm.FindElement(By.Id("firstName"));
        private IWebElement LastNameNameInput => SubmitForm.FindElement(By.Id("lastName"));
        private IWebElement NameOnCardInput => SubmitForm.FindElement(By.Id("cc-name"));
        private IWebElement CreditCardNumberInput => SubmitForm.FindElement(By.Id("cc-number"));
        private IWebElement ExpirationInput => SubmitForm.FindElement(By.Id("cc-expiration"));
        private IWebElement CvvInput => SubmitForm.FindElement(By.Id("cc-cvv"));

        #endregion Form inputs

        #region Constructor

        public CheckoutFormPage()
        {
            this._pageContainer = Driver.FindElement(this.ContainerBy);
        }

        #endregion Constructor

        #region Methods

        public CheckoutFormPage PressContinueToCheckout()
        {
            this.SubmitForm.FindElement(By.CssSelector("button[type='submit']")).ClickWait();

            return this;
        }

        public string GetSuccessMessage()
        {
            return Driver.WaitForElementToBeVisible(By.Id("success")).Text;
        }

        public bool AllValidationMessagesAreDisplayed()
        {
            return this.ValidationElements.All(el => el.Displayed);
        }

        public IEnumerable<string> GetValidationMessages => this.ValidationElements.Select(el => el.Text.Trim());

        public bool CartIsLoaded()
        {
            return this.Cart.Container.Displayed && this.Cart.IsCartLoaded();
        }

        public CheckoutFormPage FillTheForm(CheckoutFormModel model)
        {
            this.FirstNameInput.ClearSendKeys(model.FirstName);
            this.LastNameNameInput.ClearSendKeys(model.LastName);
            this.NameOnCardInput.ClearSendKeys(model.NameOnCard);
            this.CreditCardNumberInput.ClearSendKeys(model.CreditCardNumber);
            this.ExpirationInput.ClearSendKeys(model.Expiration);
            this.CvvInput.ClearSendKeys(model.Cvv);

            return this;
        }

        #endregion Methods
    }
}