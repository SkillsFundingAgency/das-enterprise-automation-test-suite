using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages.DeliveringApprenticeshipTraining_Section7
{
    public class DeliveringApprenticeshipTrainingPage : RoatpBasePage
    {
        protected override string PageTitle => "Delivering apprenticeship training";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public DeliveringApprenticeshipTrainingPage(ScenarioContext context) : base(context)
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
