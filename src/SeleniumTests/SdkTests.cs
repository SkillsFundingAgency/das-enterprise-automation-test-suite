using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumTests
{
    [TestFixture]
    public class SdkTests
    {
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            // You can swap ChromeOptions for FirefoxOptions, etc.
            var options = new ChromeOptions();
            // If running on BrowserStack/Selenium Grid, add capabilities here:
            // options.AddAdditionalOption("browserstack.user", "YOUR_USER");
            // options.AddAdditionalOption("browserstack.key", "YOUR_KEY");
            // options.AddAdditionalOption("os", "Windows");
            // options.AddAdditionalOption("os_version", "10");
            // options.AddAdditionalOption("browser", "Chrome");
            // options.AddAdditionalOption("browser_version", "latest");

            // If you're just testing locally, this URL should be your Selenium Grid/hub.
            driver = new RemoteWebDriver(
                new Uri("http://localhost:4444/wd/hub"),
                options.ToCapabilities(), // <--- Important: pass options, not DesiredCapabilities
                TimeSpan.FromSeconds(180)
            );
        }

        [Test]
        public void ShouldOpenGoogle()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            Assert.That(driver.Title, Does.Contain("Google"));
        }

        [TearDown]
        public void Cleanup()
        {
            driver?.Quit();
        }
    }
}
