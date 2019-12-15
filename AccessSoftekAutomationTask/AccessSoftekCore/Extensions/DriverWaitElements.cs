using System;
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

        public static IWebElement WaitForElementToExist(this IWebDriver driver, By by, int waitTimeInSeconds = DefaultTimeoutSeconds)
        {
            return driver.Wait(waitTimeInSeconds).Until(ExpectedConditions.ElementExists(by));
        }

        /// <summary>
        /// Waits for jQuery to complete
        /// </summary>
        public static void WaitJQuery(this IWebDriver driver, int waitTimeInSeconds = DefaultTimeoutSeconds)
        {
            driver.WaitForBrowserReadyState();
            const string script = @" window.setTimeout(() => {
											console.log('Applied a delay for start an action');
											}, 500);
								     return jQuery.active==0;";

            driver.Wait(waitTimeInSeconds).Until(d => (bool)((IJavaScriptExecutor)d).ExecuteScript(script));
        }

        public static bool WaitElementNotVisible(this IWebDriver driver, By by, int timeoutSeconds = DefaultTimeoutSeconds)
        {
            Thread.Sleep(500); // wait for element  to appear
            driver.WaitForBrowserReadyState();

            return driver.Wait(timeoutSeconds).Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }
    }
}