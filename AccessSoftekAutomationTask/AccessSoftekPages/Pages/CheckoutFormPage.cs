﻿using System;
using System.Collections.Generic;
using System.Linq;
using AccessSoftekCore.BasePageObjects;
using AccessSoftekCore.Configs.AppConfigs;
using AccessSoftekCore.Extensions;
using AccessSoftekPages.Components;
using OpenQA.Selenium;

namespace AccessSoftekPages.Pages
{
    public class CheckoutFormPage : BasePage
    {
        public sealed override By ContainerBy => By.CssSelector("div.container");
        public override Uri PageUri => TestAppConfig.MainPageUri;

        private readonly IWebElement _pageContainer;

        private Lazy<CartComponent> cartComponent => new Lazy<CartComponent>(() => new CartComponent());

        public CartComponent Cart => cartComponent.Value;

        private IWebElement SubmitForm => _pageContainer.FindElement(By.TagName("form"));

        private IEnumerable<IWebElement> ValidationElements => SubmitForm.FindElements(By.CssSelector("div.row .invalid-feedback"));

        #region Constructor

        public CheckoutFormPage()
        {
            this._pageContainer = Driver.FindElement(this.ContainerBy);
        }

        #endregion Constructor

        #region Methods

        public void PressContinueToCheckout() => this.SubmitForm.FindElement(By.CssSelector("button[type='submit']")).ClickWait();

        public bool AllValidationMessagesAreDisplayed()
        {
            return this.ValidationElements.All(el => el.Displayed);
        }

        public IEnumerable<string> GetValidationMessages => this.ValidationElements.Select(el => el.Text.Trim());

        public bool CartIsLoaded()
        {
            return this.Cart.Container.Displayed && this.Cart.IsCartLoaded();
        }

        #endregion Methods
    }
}