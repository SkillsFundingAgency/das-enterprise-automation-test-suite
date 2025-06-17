using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply
{
    public class SigUpCompletePage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Your account has been created";

        protected override By PageHeader => By.CssSelector(".govuk-panel--confirmation");

        public SigUpCompletePage(ScenarioContext context) : base(context) => VerifyPage();
    }
}
