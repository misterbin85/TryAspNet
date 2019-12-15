using AccessSoftekCore.BasePageObjects.Components;
using AccessSoftekCore.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;

namespace AccessSoftekPages.Components
{
    public class CartComponent : AbstractPageComponent
    {
        public override By ContainerBy => By.CssSelector("div.mb-4");

        public IWebElement Container => Driver.WaitForElementToExist(ContainerBy);

        public bool IsCartLoaded() => ((IWrapsDriver)Container).WrappedDriver.WaitElementNotVisible(By.CssSelector("li#loading"));
    }
}