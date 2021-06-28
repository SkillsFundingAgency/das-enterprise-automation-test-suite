using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class TransitionFromFrameworksToStandardPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "How will your organisation transition from apprenticeship frameworks to apprenticeship standards?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public TransitionFromFrameworksToStandardPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public EndPointAssesmentOrganisationsPage EnterTextForTransitionFromFramewordsToStandardsAndContinueEmployerRoute()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.TransitionFromFrameWorksToStandardsForEmployerRoute);
            return new EndPointAssesmentOrganisationsPage(_context);
        }

        public ApplicationOverviewPage EnterTextForTransitionFromFramewordsToStandardsAndContinueSupportingRoute()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.TransitionFromFrameWorksToStandards);
            return new ApplicationOverviewPage(_context);
        }
        public AwardingBodiesPage EnterTextForTransitionFromFramewordsToStandardsAndContinueIncludesFrameworks()
        {
            EnterLongTextAreaAndContinue(applydataHelpers.TransitionFromFrameWorksToStandards);
            return new AwardingBodiesPage(_context);
        }
    }
}
