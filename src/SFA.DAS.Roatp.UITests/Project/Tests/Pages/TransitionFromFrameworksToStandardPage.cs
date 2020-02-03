using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class TransitionFromFrameworksToStandardPage : RoatpBasePage
    {
        protected override string PageTitle => "How will your organisation transition from apprenticeship frameworks to apprenticeship standards?";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By LongTetArea_TransitionFromFrameWorksToStandardsForEmployerRoute => By.Id("PAT-52");
        private By LongTextArea_TransitionFromFrameWorksToStandards => By.Id("PAT-62");

        public TransitionFromFrameworksToStandardPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public EndPointAssesmentOrganisationsPage EnterTextForTransitionFromFramewordsToStandardsAndContinueEmployerRoute()
        {
            formCompletionHelper.EnterText(LongTetArea_TransitionFromFrameWorksToStandardsForEmployerRoute, applydataHelpers.TransitionFromFrameWorksToStandardsForEmployerRoute);
            Continue();
            return new EndPointAssesmentOrganisationsPage(_context);
        }

        public ApplicationOverviewPage EnterTextForTransitionFromFramewordsToStandardsAndContinueSupportingRoute()
        {
            formCompletionHelper.EnterText(LongTextArea_TransitionFromFrameWorksToStandards, applydataHelpers.TransitionFromFrameWorksToStandards);
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
