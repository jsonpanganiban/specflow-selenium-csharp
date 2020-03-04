using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using Jupiter.Framework.Configuration;
using Jupiter.Framework.Factories;
using Jupiter.Tests.Dialogs;
using Jupiter.Tests.Model.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace Jupiter.Tests.Support
{
    [Binding]
    public class Hooks
    {
        private static IWebDriver driver;
        private readonly IObjectContainer objectContainer;

        private static ExtentTest feature;
        private static ExtentTest scenario;
        private static AventStack.ExtentReports.ExtentReports extent;

        private static readonly string actualPath = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
        private static readonly string reportDir = new Uri(actualPath.Substring(0, actualPath.LastIndexOf("bin"))).LocalPath;
        private static readonly string reportFile = string.Concat(reportDir, "\\TestResults\\Report\\ExtentReport.html");
        //private static readonly Browser BrowserType = Config.Instance.Browser;


        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Directory.CreateDirectory(string.Concat(reportDir, Path.Combine("\\TestResults\\Report")));
            Directory.CreateDirectory(string.Concat(reportDir, Path.Combine("\\TestResults\\Img")));
            var reporter = new ExtentHtmlReporter(reportFile);
            reporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(reporter);

            ConfigReader.SetConfig();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            feature = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            driver = DriverFactory.GetWebDriver(Config.Instance.Browser);
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(Config.Instance.Url);

            objectContainer.RegisterInstanceAs(new HomePage(driver));
            objectContainer.RegisterInstanceAs(new LoginDialog(driver));
            objectContainer.RegisterInstanceAs(new ShopPage(driver));
            objectContainer.RegisterInstanceAs(new CartPage(driver));
            objectContainer.RegisterInstanceAs(new CheckoutPage(driver));

            scenario = feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            scenario.AssignCategory(scenarioContext.ScenarioInfo.Tags);
        }

        [AfterStep]
        public static void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            var ScreenshotFilePath = Path.Combine(reportDir + "\\TestResults\\Img", Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".png");
            var mediaModel = MediaEntityBuilder.CreateScreenCaptureFromPath(ScreenshotFilePath).Build();

            if (scenarioContext.TestError != null)
            {
                driver.TakeScreenshot().SaveAsFile(ScreenshotFilePath, ScreenshotImageFormat.Png);
                switch (ScenarioStepContext.Current.StepInfo.StepDefinitionType)
                {
                    case TechTalk.SpecFlow.Bindings.StepDefinitionType.Given:
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message, mediaModel);
                        break;

                    case TechTalk.SpecFlow.Bindings.StepDefinitionType.When:
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message, mediaModel);
                        break;

                    case TechTalk.SpecFlow.Bindings.StepDefinitionType.Then:
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message, mediaModel);
                        break;
                }
            }
            else
            {
                switch (ScenarioStepContext.Current.StepInfo.StepDefinitionType)
                {
                    case TechTalk.SpecFlow.Bindings.StepDefinitionType.Given:
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Pass(string.Empty);
                        break;

                    case TechTalk.SpecFlow.Bindings.StepDefinitionType.When:
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Pass(string.Empty);
                        break;

                    case TechTalk.SpecFlow.Bindings.StepDefinitionType.Then:
                        driver.TakeScreenshot().SaveAsFile(ScreenshotFilePath, ScreenshotImageFormat.Png);
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Pass(string.Empty, mediaModel);
                        break;
                }
            }
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext scenarioContext)
        {
            extent.Flush();
            driver?.Quit();
            driver?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}