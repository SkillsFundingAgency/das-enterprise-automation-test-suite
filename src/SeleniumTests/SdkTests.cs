using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;

namespace SeleniumTests
{
    [TestFixture]
    public class SdkTests
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            var caps = new DesiredCapabilities();
            driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), caps);
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
