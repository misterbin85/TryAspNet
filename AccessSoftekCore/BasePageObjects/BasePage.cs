using System;
using AccessSoftekCore.BasePageObjects.Interfaces;
using AccessSoftekCore.Extensions;
using AccessSoftekCore.WebDriver;
using OpenQA.Selenium;

namespace AccessSoftekCore.BasePageObjects
{
    /// <summary>
    /// All Page Object should inherit this base page to have access to Driver and page container verification
    /// </summary>
    public abstract class BasePage : IPageContainer, IPageUri
    {
        protected IWebDriver Driver => WebDriverFactory.WebDriver();

        public abstract By ContainerBy { get; }

        public abstract Uri PageUri { get; }

        protected BasePage()
        {
            this.LoadPage();
            this.VerifyPage();
        }

        public string GetCurrentUrl() => this.Driver.Url;

        protected virtual void LoadPage()
        {
            if (this.GetCurrentUrl().Contains(this.PageUri.ToString()))
            {
                return;
            }

            this.Driver.Navigate().GoToUrl(this.PageUri);
            Console.WriteLine($"Navigating to: '{this.PageUri}'");
            this.Driver.WaitForBrowserReadyState();
        }

        protected virtual void VerifyPage()
        {
            try
            {
                this.Driver.WaitForElementToExist(this.ContainerBy, 30);
            }
            catch (Exception e)
            {
                Console.WriteLine($"***The page container wasn't found. Encountered exception with message: {e.Message}***");
                throw;
            }
        }
    }
}