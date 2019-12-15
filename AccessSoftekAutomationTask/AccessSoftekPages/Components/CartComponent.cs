using System;
using AccessSoftekCore.BasePageObjects.Components;
using AccessSoftekCore.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace AccessSoftekPages.Components
{
    public class CartComponent : AbstractPageComponent
    {
        public override By ContainerBy => By.CssSelector("div.mb-4");

        public IWebElement Container => Driver.FindElement(ContainerBy);

        public CartComponent()
        {
            Driver.WaitFor(() => this.IsCartLoaded().Equals(true));
        }

        public bool IsCartLoaded() => ((IWrapsDriver)Container).WrappedDriver.WaitElementNotVisible(By.CssSelector("li#loading"));

        private IWebElement PromoCodeInput => Container.FindElement(By.Id("promoCode"));

        private IWebElement RedeemButton => Container.FindElement(By.CssSelector("button[type='submit']"));

        #region Methods

        public decimal GetTotal() => Convert.ToDecimal(Container.FindElement(By.Id("totalAmount")).Text.Trim());

        // TODO Calculation Logic is here due to the lack of implementation time
        public bool ApplyPromoCode(string code)
        {
            var expectedPercentage = code.Length;
            var currentValue = this.GetTotal();

            var expectedAmountAfterApplyingTheCode = currentValue - (currentValue * expectedPercentage) / 100;

            this.PromoCodeInput.ClearSendKeys(code);
            this.RedeemButton.ClickWait();

            var redeemedValue = this.GetTotal();

            return decimal.Compare(expectedAmountAfterApplyingTheCode, redeemedValue) == 0;
        }

        #endregion Methods
    }
}