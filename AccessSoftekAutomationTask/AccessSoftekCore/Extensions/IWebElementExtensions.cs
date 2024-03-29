﻿using AccessSoftekCore.WebDriver;
using OpenQA.Selenium;

namespace AccessSoftekCore.Extensions
{
    public static class IWebElementExtensions
    {
        public static void ClickWait(this IWebElement element)
        {
            element.Click();
            WebDriverFactory.WebDriver().WaitJQuery();
        }

        public static IWebElement ClearSendKeys(this IWebElement element, string inputString)
        {
            element.Clear();
            element.SendKeys(inputString);

            return element;
        }
    }
}