using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class DynamicHomePageSteps
    {
        
        #region Helpers and Context
        private readonly MFEmployerStepsHelper _reservationStepsHelper;
        private readonly EmployerStepsHelper _employerStepsHelper;
        #endregion

        public DynamicHomePageSteps(ScenarioContext context)
        {
            _reservationStepsHelper = new MFEmployerStepsHelper(context);
            _employerStepsHelper = new EmployerStepsHelper(context);
        }

        [Then(@"The employer continues to add an apprentice for reserved funding")]
        public void ThenTheEmployerContinueToAddAnApprenticesForReservedFunding()
        {
            _reservationStepsHelper.GoToAddAnApprentices();
            _employerStepsHelper.DraftApprentice();
        }
    }
}
