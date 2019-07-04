using System;
using System.IO;
using System.Reflection;
using BoDi;
using ESFA.UI.Specflow.Framework.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using TechTalk.SpecFlow;

namespace ESFA.UI.Specflow.Framework.Project.Tests.TestSupport
{
    [Binding]
    public class BaseTest
    {
        private IWebDriver WebDriver;
        private static readonly string DriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        
        public static IServiceProvider InitializeContainer()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true)
                .AddJsonFile("appsettings.Development.json", true)
                .AddEnvironmentVariables()
                .Build();
            
            return new ServiceCollection()
                .Configure<ConfigurationOptions>(config)
                .AddSingleton(cfg => cfg.GetService<IOptions<ConfigurationOptions>>().Value)
                .AddSingleton(typeof(ScenarioContext))
                .AddSingleton(typeof(FeatureContext))
                .AddOptions()
                .BuildServiceProvider();

        }

        [BeforeScenario(Order = 0)]
        public void Setup(ScenarioContext scenarioContext)
        {
            var provider = InitializeContainer();
            var configuration = provider.GetService<IOptions<ConfigurationOptions>>().Value;
            scenarioContext.ScenarioContainer.RegisterInstanceAs(configuration);
        }

        [BeforeScenario(Order = 1)]
        public void SetUpWebDriver(ScenarioContext scenarioContext, ConfigurationOptions options)
        {
            switch (options.Browser)
            {
                case "firefox":
                    WebDriver = new FirefoxDriver(DriverPath);
                    WebDriver.Manage().Window.Maximize();
                    break;

                case "chrome":
                    WebDriver = new ChromeDriver(DriverPath);
                    break;

                case "ie":
                    WebDriver = new InternetExplorerDriver(DriverPath);
                    WebDriver.Manage().Window.Maximize();
                    break;

                case "zapProxyChrome":
                    InitialiseZapProxyChrome();
                    break;

                default:
                    throw new Exception("Driver name - " + options.Browser + " does not match OR this framework does not support the webDriver specified");
            }

            WebDriver.Manage().Window.Maximize();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var currentWindow = WebDriver.CurrentWindowHandle;
            WebDriver.SwitchTo().Window(currentWindow);
            WebDriver.Manage().Cookies.DeleteAllCookies();

            scenarioContext.ScenarioContainer.RegisterInstanceAs(WebDriver);
        }

        [BeforeScenario(Order = 2)]
        public void SetUpForEachTest()
        {
            WebDriver.Manage().Cookies.DeleteAllCookies();
            PageInteractionHelper.SetDriver(WebDriver);
        }

        [AfterScenario(Order = 1)]
        public void TakeScreenshotOnFailure(ScenarioContext scenarioContext, FeatureContext featureContext)
        {
            String featureTitle = featureContext.FeatureInfo.Title;
            String scenarioTitle = scenarioContext.ScenarioInfo.Title;

            if (scenarioContext.TestError != null)
            {
                try
                {
                    DateTime dateTime = DateTime.Now;
                    
                    String failureImageName = dateTime.ToString("HH-mm-ss")
                        + "_"
                        + scenarioTitle
                        + ".png";
                    String screenshotsDirectory = AppDomain.CurrentDomain.BaseDirectory
                        + "../../"
                        + "\\Project\\Screenshots\\"
                        + dateTime.ToString("dd-MM-yyyy")
                        + "\\";
                    if (!Directory.Exists(screenshotsDirectory))
                    {
                        Directory.CreateDirectory(screenshotsDirectory);
                    }
                
                    ITakesScreenshot screenshotHandler = WebDriver as ITakesScreenshot;
                    Screenshot screenshot = screenshotHandler.GetScreenshot();
                    String screenshotPath = Path.Combine(screenshotsDirectory, failureImageName);
                    screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
                    Console.WriteLine($"{scenarioTitle} -- Scenario under {featureTitle} feature failed and the screenshot is available at -- {screenshotPath}");
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Exception occurred while taking screenshot - " + exception);
                }
            }            
        }

        [AfterScenario(Order = 2)]
        public void DisposeOnTestRun()
        {
            WebDriver.Quit();
            WebDriver.Dispose();
        }

        [AfterTestRun]
        public static void TearDown()
        {
            
        }

        private void InitialiseZapProxyChrome()
        {
            const string PROXY = "localhost:8080";
            var chromeOptions = new ChromeOptions();
            var proxy = new Proxy
            {
                HttpProxy = PROXY,
                SslProxy = PROXY,
                FtpProxy = PROXY
            };
            chromeOptions.Proxy = proxy;

            WebDriver = new ChromeDriver(DriverPath,chromeOptions);
        }
    }
}