using System;
using System.Collections.Generic;
using System.Threading;
using AccessSoftekCore.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace AccessSoftekCore.WebDriver
{
    public sealed class WebDriverFactory
    {
        private static readonly ThreadLocal<IWebDriver> Driver = new ThreadLocal<IWebDriver>();

        public static IWebDriver WebDriver()
        {
            return Driver.Value;
        }

        public static List<int> ChromeIds = new List<int>();

        public static void SetWebDriver()
        {
            Driver.Value = CreateWebDriver();
        }

        /// <summary>
        /// Creates a WebDriver instance for the desired browser
        /// </summary>
        /// <returns>Instance of WebDriver</returns>
        private static IWebDriver CreateWebDriver()
        {
            IWebDriver driver;
            switch (Configs.Config.Properties.Browser)
            {
                case "chrome":
                    var service = ChromeDriverService.CreateDefaultService(DirectoryUtils.Executables());
                    service.HideCommandPromptWindow = true;
                    driver = new ChromeDriver(service, ChromeDriverOptions());
                    ChromeIds.Add(service.ProcessId);
                    break;

                case "firefox":
                    driver = new FirefoxDriver(DirectoryUtils.Executables(), GeckoDriverOptions());
                    break;

                case "iexplore":
                    driver = new InternetExplorerDriver(DirectoryUtils.Executables(), IEDriverOptions());
                    break;

                default:
                    throw new ArgumentException(
                        $"'{Configs.Config.Properties.Browser}' is not a valid browser type");
            }

            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            return driver;
        }

        private static FirefoxOptions GeckoDriverOptions()
        {
            return new FirefoxOptions();
        }

        private static InternetExplorerOptions IEDriverOptions()
        {
            return new InternetExplorerOptions();
        }

        private static ChromeOptions ChromeDriverOptions()
        {
            var options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("--disable-default-apps");
            options.AddArgument("--enable-automation");
            options.AddArgument("test-type=browser");
            options.AddArgument("disable-infobars");
            options.AddArgument("disable-extensions");
            options.AddUserProfilePreference("download.default_directory", DirectoryUtils.Executables());
            options.AddAdditionalCapability("useAutomationExtension", false);

            return options;
        }
    }
}