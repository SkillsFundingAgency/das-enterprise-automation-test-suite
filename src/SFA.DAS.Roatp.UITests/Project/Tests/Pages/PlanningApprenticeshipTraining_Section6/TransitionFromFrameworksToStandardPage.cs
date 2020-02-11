using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.PlanningApprenticeshipTraining_Section6
{
    public class TransitionFromFrameworksToStandardPage : RoatpBasePage
    {
        protected override string PageTitle => "How will your organisation transition from apprenticeship frameworks to apprenticeship standards?";

        protected override By PageHeader => By.CssSelector(".govuk-label-wrapper");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTextArea => By.CssSelector(".govuk-fieldset .govuk-textarea");

        public TransitionFromFrameworksToStandardPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public EndPointAssesmentOrganisationsPage EnterTextForTransitionFromFramewordsToStandardsAndContinueEmployerRoute()
        {
            formCompletionHelper.EnterText(LongTextArea, applydataHelpers.TransitionFromFrameWorksToStandardsForEmployerRoute);
            Continue();
            return new EndPointAssesmentOrganisationsPage(_context);
        }

        public ApplicationOverviewPage EnterTextForTransitionFromFramewordsToStandardsAndContinueSupportingRoute()
        {
            formCompletionHelper.EnterText(LongTextArea, applydataHelpers.TransitionFromFrameWorksToStandards);
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
