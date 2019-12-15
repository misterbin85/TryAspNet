using System;
using System.Linq;
using AccessSoftekCore.Extensions;
using AccessSoftekCore.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AccessSoftekAutomationTask
{
    public class BaseTest
    {
        protected internal IWebDriver Driver { get; private set; }

        [OneTimeSetUp]
        public void Setup()
        {
            // Instantiate WebDriver
            WebDriverFactory.SetWebDriver();
            this.Driver = WebDriverFactory.WebDriver();
        }

        [OneTimeTearDown]
        protected void TearDown()
        {
            this.CloseAll();
        }

        private void CloseAll()
        {
            this.Driver?.WaitForBrowserReadyState();
            this.Driver?.Quit();
        }
    }
}