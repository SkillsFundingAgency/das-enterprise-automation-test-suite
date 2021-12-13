using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class AwardingBodiesPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How will your organisation plan to engage and work with awarding bodies?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        public AwardingBodiesPage(ScenarioContext context) : base(context) => VerifyPage();

        public ApplicationOverviewPage EnterTextForEngageAndWorkWithAwardingBodies()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.EngageWithAwardingBodies);
            return new ApplicationOverviewPage(_context);
        }
    }
}
