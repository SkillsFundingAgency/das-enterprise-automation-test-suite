using System;
using SFA.DAS.CreateAccount.UITests.Project.Framework.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Finance
{
    public class TransactionBasePage : BasePage
    {
        [FindsBy(How = How.CssSelector, Using = "h1.heading-xlarge")] private IWebElement _pageheadings;

        public TransactionBasePage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        public bool IsPagePresented()
        {
            return _pageheadings.Text.ContainsCompareCaseInsensitive(DateTime.Now.Year.ToString());
        }
    }
}