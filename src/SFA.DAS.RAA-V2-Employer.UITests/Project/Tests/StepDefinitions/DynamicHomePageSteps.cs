using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class DynamicHomePageSteps
    {
        private readonly ManageFundingEmployerStepsHelper _reservationStepsHelper;

        public DynamicHomePageSteps(ScenarioContext context) => _reservationStepsHelper = new ManageFundingEmployerStepsHelper(context);

        [Given(@"the employer reserves funding from the dynamic home page")]
        public void GivenTheUserReservesFundingFromTheDynamicHomePage() => _reservationStepsHelper.CreateReservationViaDynamicHomePageTriageJourney();
    }
}