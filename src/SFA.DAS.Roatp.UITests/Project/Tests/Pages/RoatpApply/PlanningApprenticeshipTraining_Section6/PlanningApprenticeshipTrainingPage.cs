using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.PlanningApprenticeshipTraining_Section6
{
    public class PlanningApprenticeshipTrainingPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Planning apprenticeship training";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public PlanningApprenticeshipTrainingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public ApplicationOverviewPage ClickSaveAndContinue()
        {
            Continue();
            return new ApplicationOverviewPage(_context);
        }
    }
}
