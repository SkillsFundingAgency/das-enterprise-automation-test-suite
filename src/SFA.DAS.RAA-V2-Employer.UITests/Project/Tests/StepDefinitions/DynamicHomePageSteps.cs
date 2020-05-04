using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class DynamicHomePageSteps
    {
        private readonly ApprovalsStepsHelper _stepsHelper;
        private readonly MFEmployerStepsHelper _reservationStepsHelper;
        private readonly DynamicHomePageStepsHelper _dynamicHomePageStepsHelper;

        public DynamicHomePageSteps(ScenarioContext context)
        {
            _stepsHelper = new ApprovalsStepsHelper(context);
            _reservationStepsHelper = new MFEmployerStepsHelper(context);
            _dynamicHomePageStepsHelper = new DynamicHomePageStepsHelper(context);
        }

        [Given(@"the user reserves funding from the dynamic home page")]
        public void GivenTheUserReservesFundingFromTheDynamicHomePage()
        {
            _stepsHelper.CreatesAccountAndSignAnAgreement();
            _dynamicHomePageStepsHelper.DynamicHomePageTriageJourney();
            _reservationStepsHelper.CreateReservation(_reservationStepsHelper.GoToReserveFunding());
            _reservationStepsHelper.VerifySuccessfullyReservedFundingPage();
            _dynamicHomePageStepsHelper.DynamicHomePageGoToHome();
            _dynamicHomePageStepsHelper.DynamicHomePageVerifyContinueOnHomePagePanel();
        }
    }
}