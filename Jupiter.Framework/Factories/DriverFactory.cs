using Jupiter.Framework.Configuration;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
                    //driver = new ChromeDriver();
                    driver = new ChromeDriver(GetChromeOptions());
                    break;
                //case Browser.Firefox:
                //    new DriverManager().SetUpDriver(new FirefoxConfig());
                //    driver = new FirefoxDriver(GetFirefoxOptions());
                //    break;
                //case Browser.IE:
                //    new DriverManager().SetUpDriver(new InternetExplorerConfig());
                //    driver = new InternetExplorerDriver(GetInternetExplorerOptions());
                //    break;
                //case Browser.Edge:
                //    new DriverManager().SetUpDriver(new EdgeConfig());
                //    driver = new EdgeDriver(GetEdgeOptions());
                //    break;
                default:
                    Console.WriteLine($"Browser '{browser}' is not supported");
                    throw new ArgumentOutOfRangeException($"Browser '{browser}'" +
                        $" is not supported");
            }
            return driver;
        }
        private static ChromeOptions GetChromeOptions()
        {
            var options = new ChromeOptions();
            options.AddArguments("--no-sandbox", "--disable-gpu", "--disable-dev-shm-usage");
            options.AddUserProfilePreference("intl.accept_languages", ConfigInstance.Language);
            options.AddUserProfilePreference("disable-popup-blocking", "true");
            options.AddUserProfilePreference("download.prompt_for_download", "false");
            options.AddUserProfilePreference("download.default_directory", DownloadsDir);

            return options;
        }
    }
}