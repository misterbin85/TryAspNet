using System;
using AccessSoftekCore.BasePageObjects.Interfaces;
using AccessSoftekCore.Extensions;
using AccessSoftekCore.WebDriver;
using OpenQA.Selenium;

namespace AccessSoftekCore.BasePageObjects.Components
{
    public abstract class AbstractPageComponent : IPageContainer
    {
        protected IWebDriver Driver => WebDriverFactory.WebDriver();

        public abstract By ContainerBy { get; }

        protected AbstractPageComponent()
        {
            this.VerifyComponent();
        }

        protected virtual void VerifyComponent()
        {
            try
            {
                this.Driver.WaitForElementToExist(this.ContainerBy, 30);
            }
            catch (Exception e)
            {
                Console.WriteLine($"The page container wasn't found. Encountered exception with message: {e.Message}");
                throw;
            }
        }
    }
}