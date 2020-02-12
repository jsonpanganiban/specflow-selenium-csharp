using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using BoDi;
using Jupiter.Tests.Contracts;
using Jupiter.Tests.Factories;
using Jupiter.Tests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TechTalk.SpecFlow;

namespace Jupiter.Tests.StepDefinitions
{
    [Binding]
    public class Hooks
    {
        private static IWebDriver driver;
        private static DriverFactory driverFactory;
        private readonly IObjectContainer objectContainer;

        private static ExtentTest feature;
        private static ExtentTest scenario;
        private static ExtentReports extent;

        private static readonly string reportDir = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\net472\\", "");
        private static readonly string reportFile = string.Concat(reportDir, "\\TestResults\\Report\\ExtentReport.html");

        public Hooks(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Directory.CreateDirectory(string.Concat(reportDir, Path.Combine("\\TestResults\\Report")));
            Directory.CreateDirectory(string.Concat(reportDir, Path.Combine("\\TestResults\\Img")));
            driverFactory = new DriverFactory();
            var reporter = new ExtentHtmlReporter(reportFile);
            reporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(reporter);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            feature = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            driver = driverFactory.GetWebDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            //objectContainer.RegisterInstanceAs<IWebDriver>(driver);
            objectContainer.RegisterInstanceAs<IHome>(new HomePage(driver));
            objectContainer.RegisterInstanceAs<IShop>(new ShopPage(driver));
            objectContainer.RegisterInstanceAs<ICart>(new CartPage(driver));
            objectContainer.RegisterInstanceAs<ICheckout>(new CheckoutPage(driver));

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
                //driver.TakeScreenshot().SaveAsFile(ScreenshotFilePath, ScreenshotImageFormat.Png);
                switch (ScenarioStepContext.Current.StepInfo.StepDefinitionType)
                {
                    case TechTalk.SpecFlow.Bindings.StepDefinitionType.Given:
                        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Pass(string.Empty);
                        break;

                    case TechTalk.SpecFlow.Bindings.StepDefinitionType.When:
                        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Pass(string.Empty);
                        break;

                    case TechTalk.SpecFlow.Bindings.StepDefinitionType.Then:
                        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Pass(string.Empty);
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