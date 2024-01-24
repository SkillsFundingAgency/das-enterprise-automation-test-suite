using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.AuthPages
{
    public abstract class UnauthorisedAccessBasePage : VerifyBasePage
    {
        protected override string PageTitle { get; }

        protected override bool CaptureUrl => false;

        protected override By PageHeader => By.CssSelector("h1");

        protected abstract List<string> ExpectedPageTitles { get; }

        protected static string SignInPageTitle => "Sign in";
        protected static string PageNotFoundPageTitle => "Page not found";
        protected static string AccessDeniedPageTitle => "Access denied";

        public UnauthorisedAccessBasePage(ScenarioContext context, string url) : base(context)
        {
            void action() => tabHelper.GoToUrl(url);

            action();

            VerifyPage(() => pageInteractionHelper.FindElement(PageHeader), ExpectedPageTitles, action);
        }

        public string ScenarioTitle() => PageTitle;
    }
}
