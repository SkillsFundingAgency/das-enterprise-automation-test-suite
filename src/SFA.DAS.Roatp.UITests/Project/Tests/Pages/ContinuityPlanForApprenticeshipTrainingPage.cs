using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Tests.Pages
{
    public class ContinuityPlanForApprenticeshipTrainingPage : RoatpBasePage
    {
        protected override string PageTitle => "Upload your organisation's continuity plan for apprenticeship training";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ContinuityPlanForApprenticeshipTrainingPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
        public ApplicationOverviewPage ContinuityPlanFileUploadAndContinue()
        {
            UploadFile();
            return new ApplicationOverviewPage(_context);
        }

    }

}
