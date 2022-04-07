using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public abstract class WebdriverAddCapabilities
    {
        protected readonly ObjectContext objectContext;

        public WebdriverAddCapabilities(ScenarioContext context) => objectContext = context.Get<ObjectContext>();

        protected void AddChromeCapabilities(IWebDriver webDriver)
        {
            var cap = GetCapabilities(webDriver);

            AddBrowserCapabilities(cap);

            foreach (var item in cap["chrome"] as Dictionary<string, object>) objectContext.Replace(item.Key, item.Value);
        }

        protected void AddEdgeCapabilities(IWebDriver webDriver) => AddBrowserCapabilities(GetCapabilities(webDriver));

        protected void AddFireFoxCapabilities(IWebDriver webDriver) => AddBrowserCapabilities(GetCapabilities(webDriver));

        private void AddBrowserCapabilities(ICapabilities cap)
        {
            objectContext.SetBrowserName(cap["browserName"]);

            objectContext.SetBrowserVersion(cap["browserVersion"]);
        }

        private ICapabilities GetCapabilities(IWebDriver webDriver) => (webDriver as WebDriver).Capabilities;
    }
}
