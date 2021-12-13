using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.ProtectingYourApprentices_Section4
{
    public class ContinuityPlanForApprenticeshipTrainingPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Upload your organisation's continuity plan for apprenticeship training";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        public ContinuityPlanForApprenticeshipTrainingPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage ContinuityPlanFileUploadAndContinue()
        {
            UploadFile();
            return new ApplicationOverviewPage(_context);
        }
    }
}
