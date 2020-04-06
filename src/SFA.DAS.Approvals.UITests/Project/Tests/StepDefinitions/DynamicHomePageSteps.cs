using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    class DynamicHomePageSteps
    {
        #region Helpers and Context
        private readonly MFEmployerStepsHelper _reservationStepsHelper;
        #endregion

        public DynamicHomePageSteps(ScenarioContext context) => _reservationStepsHelper = new MFEmployerStepsHelper(context);
    
        [Then(@"the employer continue to add an apprentices for reserved funding")]
        public void ThenTheEmployerContinueToAddAnApprenticesForReservedFunding() => _reservationStepsHelper.GoToAddAnApprentices();
    }
}
