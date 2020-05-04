using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using SFA.DAS.Registration.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class DynamicHomePageSteps
    {
        private readonly ApprovalsStepsHelper _stepsHelper;
        private readonly MFEmployerStepsHelper _reservationStepsHelper;
        private YourFundingReservationsPage _yourFundingReservationsPage;
        private SuccessfullyReservedFundingPage _successfullyReservedFundingPage;
        private readonly DynamicHomePageStepsHelper _dynamicHomePageStepsHelper;

        public DynamicHomePageSteps(ScenarioContext context) => _reservationStepsHelper = new ManageFundingEmployerStepsHelper(context);

        [Given(@"the employer reserves funding from the dynamic home page")]
        public void GivenTheUserReservesFundingFromTheDynamicHomePage()
        {
            _reservationStepsHelper.CreateReservationViaDynamicHomePageTriageJourney();

            _reservationStepsHelper.VerifyContinueOnHomePagePanel();
        }
    }
}