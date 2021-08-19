using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class UnauthorisedAccessPage : BasePage
    {
        protected override string PageTitle => string.Empty;

        protected override bool CaptureUrl => false;

        protected override By PageHeader => By.CssSelector("h1");

        public UnauthorisedAccessPage(ScenarioContext context) : base(context)
        {
            VerifyPage(() => context.Get<PageInteractionHelper>().FindElement(PageHeader),
                new List<string> { "Sign in", "Page not found", "Access denied" });
        }
    }
}
