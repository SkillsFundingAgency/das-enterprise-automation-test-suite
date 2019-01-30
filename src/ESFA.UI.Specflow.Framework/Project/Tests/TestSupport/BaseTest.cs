using System;
using System.IO;
using BoDi;
using ESFA.UI.Specflow.Framework.Project.Framework.Helpers;
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
        private IWebDriver webDriver;
        private readonly IObjectContainer objectContainer;
        private ScenarioContext currentScenario;

        public BaseTest(IObjectContainer _objectContainer, ScenarioContext _currentScenario)
        {
            objectContainer = _objectContainer;
            currentScenario = _currentScenario;
        }

       [Before]
        public void SetUpWebDriver()
        {
            Configurator c = new Configurator();

            switch (c.browser)
            {
                case "firefox":
                    webDriver = new FirefoxDriver();
                    break;

                case "chrome":
                    webDriver = new ChromeDriver();
                    break;

                case "ie":
                    webDriver = new InternetExplorerDriver();
                    break;

                //--- This driver is not supported at this moment. This will be revisited in future ---
                //case "htmlunit" :
                //    webDriver = new RemoteWebDriver(DesiredCapabilities.HtmlUnitWithJavaScript());
                //    break;

                //case "phantomjs":
                //    webDriver = new PhantomJSDriver();
                //    break;

                case "zapProxyChrome":
                    InitialiseZapProxyChrome();
                    break;

                default:
                    throw new Exception("Driver name - " + c.browser + " does not match OR this framework does not support the webDriver specified");
            }
            objectContainer.RegisterInstanceAs<IWebDriver>(webDriver);
            webDriver.Manage().Window.Maximize();
            webDriver.Manage().Cookies.DeleteAllCookies();
            webDriver.Url = c.baseUrl;
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            String currentWindow = webDriver.CurrentWindowHandle;
            webDriver.SwitchTo().Window(currentWindow);
        }

       [After]
        public void QuitDriver()
        {
            Exception error = currentScenario.TestError;
            if (error != null)
            {
                Console.WriteLine("Error Message is " + currentScenario.TestError.Message);
                Console.WriteLine("Screenshot is ");
                FormCompletionHelper f = new FormCompletionHelper(webDriver);
                f.TakeScreenshotOnFailure();
            }
            webDriver.Quit();
        }

        private void InitialiseZapProxyChrome()
        {
            const string PROXY = "localhost:8080";
            var chromeOptions = new ChromeOptions();
            var proxy = new Proxy();
            proxy.HttpProxy = PROXY;
            proxy.SslProxy = PROXY;
            proxy.FtpProxy = PROXY;
            chromeOptions.Proxy = proxy;

            webDriver = new ChromeDriver(chromeOptions);
        }
    }
}