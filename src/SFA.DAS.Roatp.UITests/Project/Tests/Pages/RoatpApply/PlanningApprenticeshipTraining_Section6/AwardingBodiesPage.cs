using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class AwardingBodiesPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How does your organisation plan to engage and work with awarding bodies?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public AwardingBodiesPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage EnterTextForEngageAndWorkWithAwardingBodies()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.EngageWithAwardingBodies);
            return new ApplicationOverviewPage(_context);
        }
    }
}
