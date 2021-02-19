using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class SigUpCompletePage : BasePage
    {
        protected override string PageTitle => "Your account has been created";

        protected override By PageHeader => By.CssSelector(".govuk-panel--confirmation");

        public SigUpCompletePage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
