using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    class DynamicHomePageSteps
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        private MFEmployerStepsHelper _reservationStepsHelper;
        private DynamicHomePage _dynamicHomePage;
        #endregion

        public DynamicHomePageSteps(ScenarioContext context)
        {
            _context = context;
            _reservationStepsHelper = new MFEmployerStepsHelper(context);
        }

        [Then(@"the employer continue to add an apprentices for reserved funding")]
        public void ThenTheEmployerContinueToAddAnApprenticesForReservedFunding()
        {
            _reservationStepsHelper.GoToAddAnApprentices();
        }
    }
}
