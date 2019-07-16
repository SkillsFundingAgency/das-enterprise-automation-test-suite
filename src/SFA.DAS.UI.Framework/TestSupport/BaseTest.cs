using System;
using System.IO;
using System.Reflection;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.Project.Tests.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport
{

    [Binding]
    public class BaseTest 
    {
        private IWebDriver WebDriver;

        private static readonly string DriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private readonly ScenarioContext _context;

        public BaseTest(ScenarioContext context)
        {
            _context = context;
        }
        
        [BeforeScenario(Order = 0)]
        public void Setup()
        {
            var configuration = new JsonConfig
            { BaseUrl = Configurator.GetBaseUrl(), Browser = Configurator.GetBrowser(),
                BrowserstackServerName = Configurator.GetBrowserstackServerName(),
                BrowserstackUsername = Configurator.GetBrowserstackUsername(),
                BrowserstackPassword = Configurator.GetBrowserstackPassword(),
                BrowserstackBrowser = Configurator.GetBrowserstackBrowser(),
                BrowserstackOs = Configurator.GetBrowserstackOs(),
                BrowserstackBrowserVersion = Configurator.GetBrowserstackbrowserVersion(),
                BrowserstackOsversion = Configurator.GetBrowserstackOsversion(),
                Resolution = Configurator.GetResolution()
            };
            _context.Set(configuration);
        }


        [BeforeScenario(Order = 1)]
        public void SetUpWebDriver()
        {
            var options = _context.Get<JsonConfig>();

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
                case "browserstack":
                    WebDriver = BrowserStackService.Init(options);
                    break;
                default:
                    throw new Exception("Driver name - " + options.Browser + " does not match OR this framework does not support the webDriver specified");
            }

            WebDriver.Manage().Window.Maximize();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            var currentWindow = WebDriver.CurrentWindowHandle;
            WebDriver.SwitchTo().Window(currentWindow);
            WebDriver.Manage().Cookies.DeleteAllCookies();

            _context.Set(WebDriver, "webdriver");
        
        }

        [BeforeScenario(Order = 2)]
        public void SetUpForEachTest()
        {
            var WebDriver = _context.Get<IWebDriver>("webdriver");
            NUnit.Framework.TestContext.Progress.WriteLine($"Webdriver Instance form context {WebDriver.Title}");
            _context.Set(new PageInteractionHelper(WebDriver));
            _context.Set(new FormCompletionHelper(WebDriver));
        }

        [BeforeScenario(Order = 3)]
        public void SetObjectContext(ObjectContext objectContext)
        {
            _context.Set(objectContext);
        }

        [AfterScenario(Order = 1)]

        public void TakeScreenshotOnFailure()
        {
            String scenarioTitle = _context.ScenarioInfo.Title;
            var options = _context.Get<JsonConfig>();
            if (_context.TestError != null & options.Browser=="browserstack" )
            {
                RemoteWebDriver webDriver = _context.Get<RemoteWebDriver>("webdriver");
                TestFailures.MarkBrowsertackTestAsFailed(webDriver, options, _context, "Remote test failed" );
            }
            
            else
            {
                if (_context.TestError != null)
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
                        Console.WriteLine($"{scenarioTitle} -- Scenario under feature failed and the screenshot is available at -- {screenshotPath}");
                    }
                    catch (Exception exception)
                    {
                        Console.WriteLine("Exception occurred while taking screenshot - " + exception);
                    }
                }
            }
        }

        [AfterScenario(Order = 2)]
        public void DisposeOnTestRun()
        {
            var WebDriver = _context.Get<IWebDriver>("webdriver");
            WebDriver?.Quit();
            WebDriver?.Dispose();
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

            WebDriver = new ChromeDriver(DriverPath, chromeOptions);
        }
    }
}