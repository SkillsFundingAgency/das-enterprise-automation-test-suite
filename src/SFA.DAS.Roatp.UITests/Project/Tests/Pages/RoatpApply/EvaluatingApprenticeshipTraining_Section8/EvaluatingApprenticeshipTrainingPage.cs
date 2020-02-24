using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.RoatpApply.EvaluatingApprenticeshipTraining_Section8
{
    public class EvaluatingApprenticeshipTrainingPage : RoatpApplyBasePage
    {
        protected override string PageTitle => "Evaluating apprenticeship training";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public EvaluatingApprenticeshipTrainingPage(ScenarioContext context) : base(context)
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
