﻿using System;
using System.Reflection;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AccessSoftekCore.Extensions
{
    public static class DriverWaitElements
    {
        private const int DefaultTimeoutSeconds = 7;
        private const int DefaultNavigationTimeoutSeconds = 30;
        private const int DefaultNavigateTrasholdMilliseconds = 300;

        private static readonly TimeSpan PollingInterval = TimeSpan.FromSeconds(0.3);

        public static IWait<IWebDriver> Wait(this IWebDriver driver, int timeoutSeconds = DefaultTimeoutSeconds)
        {
            var wait = new WebDriverWait(new SystemClock(), driver, TimeSpan.FromSeconds(timeoutSeconds), PollingInterval);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException), typeof(TargetInvocationException), typeof(InvalidOperationException));

            return wait;
        }

        public static void WaitForBrowserReadyState(this IWebDriver driver, int waitTimeInSeconds = DefaultNavigationTimeoutSeconds)
        {
            Thread.Sleep(DefaultNavigateTrasholdMilliseconds); // wait for redirect starts
            driver.Wait(waitTimeInSeconds).Until(d => (bool)((IJavaScriptExecutor)d).ExecuteScript("return document && document.readyState == 'complete'"));
        }

        public static IWebElement WaitForElementToExist(this IWebDriver driver, By @by, int waitTimeInSeconds = DefaultTimeoutSeconds)
        {
            return driver.Wait(waitTimeInSeconds).Until(ExpectedConditions.ElementExists(by));
        }
    }
}