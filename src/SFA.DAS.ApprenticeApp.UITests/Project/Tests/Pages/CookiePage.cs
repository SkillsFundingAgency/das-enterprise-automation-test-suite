using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeApp.UITests.Project.Tests.Pages
{
    public class CookiePage(ScenarioContext context) : AppBasePage(context)
    {
        protected static By cookiesBanner => By.CssSelector("h1.govuk-heading-l");
        protected static By acceptCookiesButton => By.CssSelector("input[name='action:AcceptCookies']");

        protected override string PageTitle => "Cookies on Your Apprenticeship";

        public HomePage AccessHomePage()
        {
            formCompletionHelper.Click(acceptCookiesButton);
            return new HomePage(context);
        }
    }
}
