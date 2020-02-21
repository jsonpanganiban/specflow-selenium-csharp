using Jupiter.Framework.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;
using System;
using System.IO;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Jupiter.Framework.Factories
{
    public static class DriverFactory
    {
        private static Config ConfigInstance => Config.Instance;
        private static string DownloadsDir => $"{ConfigReader.BaseDirectory}" +
            $"{Path.DirectorySeparatorChar}downloads";

        public static IWebDriver GetWebDriver(string browser)
        {
            IWebDriver driver;
            switch (browser.ToLowerInvariant())
            {
                case "chrome":
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver(GetChromeOptions());
                    break;
                case "firefox":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver(GetFirefoxOptions());
                    break;
                case "ie":
                    new DriverManager().SetUpDriver(new InternetExplorerConfig());
                    driver = new InternetExplorerDriver(GetInternetExplorerOptions());
                    break;
                case "edge":
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver(GetEdgeOptions());
                    break;
                case "safari":
                    driver = new SafariDriver(GetSafariOptions());
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Browser '{browser}' is not supported");
            }
            return driver;
        }

        private static ChromeOptions GetChromeOptions()
        {
            var options = new ChromeOptions();
            options.AddArguments("--disable-gpu", "--disable-dev-shm-usage", "--start - maximized");
            options.AddArguments("--headless --no-sandbox", "--window-size=1920,1080");
            options.AddUserProfilePreference("intl.accept_languages", ConfigInstance.Language);
            options.AddUserProfilePreference("disable-popup-blocking", "true");
            options.AddUserProfilePreference("download.prompt_for_download", "false");
            options.AddUserProfilePreference("download.default_directory", DownloadsDir);

            return options;
        }
        private static FirefoxOptions GetFirefoxOptions()
        {
            var firefoxProfile = new FirefoxProfile();
            firefoxProfile.AcceptUntrustedCertificates = true;
            firefoxProfile.SetPreference("intl.accept_languages", ConfigInstance.Language);

            var options = new FirefoxOptions { Profile = firefoxProfile };
            options.SetLoggingPreference(LogType.Driver, LogLevel.Off);
            options.SetLoggingPreference(LogType.Browser, LogLevel.Off);
            options.LogLevel = FirefoxDriverLogLevel.Default;
            options.AddArgument("-headless");

            return options;
        }

        private static EdgeOptions GetEdgeOptions()
        {
            var options = new EdgeOptions()
            {
                PageLoadStrategy = PageLoadStrategy.Eager,
                UseInPrivateBrowsing = true,
            };

            return options;
        }

        private static InternetExplorerOptions GetInternetExplorerOptions()
        {
            var options = new InternetExplorerOptions
            {
                BrowserCommandLineArguments = "-private",
                ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom,
                EnableNativeEvents = true,
                EnsureCleanSession = true,
                IgnoreZoomLevel = true,
                IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                PageLoadStrategy = PageLoadStrategy.Eager,
                RequireWindowFocus = true
            };

            return options;
        }

        private static SafariOptions GetSafariOptions()
        {
            var options = new SafariOptions();
            options.AddAdditionalCapability("cleanSession", true);
            return options;
        }
    }
}