using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class OtherWaysToSupportApprenticesPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "What other ways will your organisation use to support its apprentices?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        public OtherWaysToSupportApprenticesPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage EnterTextForOtherWaysToSupportApprenticesAndContinue()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.OtherWaysToSupportApprentices);
            return new ApplicationOverviewPage(context);
        }
    }
}