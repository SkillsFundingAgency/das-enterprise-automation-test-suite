using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.AuthPages
{
    public abstract class UnauthorisedAccessBasePage : BasePage
    {
        protected override string PageTitle { get; }

        protected override bool CaptureUrl => false;

        protected override By PageHeader => By.CssSelector("h1");

        protected abstract List<string> ExpectedPageTitles { get; }

        protected string SignInPageTitle => "Sign in";
        protected string PageNotFoundPageTitle => "Page not found";
        protected string AccessDeniedPageTitle => "Access denied";

        public UnauthorisedAccessBasePage(ScenarioContext context) : base(context) => VerifyPage(() => context.Get<PageInteractionHelper>().FindElement(PageHeader), ExpectedPageTitles);
    }
}
