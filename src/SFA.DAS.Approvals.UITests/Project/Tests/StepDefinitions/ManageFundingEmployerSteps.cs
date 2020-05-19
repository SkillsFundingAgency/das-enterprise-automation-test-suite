using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{

    [Binding]
    public class ManageFundingEmployerSteps
    {
        private ManageFundingHomePage _yourFundingReservationsPage;
        private readonly ManageFundingEmployerStepsHelper _reservationStepsHelper;

        public ManageFundingEmployerSteps(ScenarioContext context) => _reservationStepsHelper = new ManageFundingEmployerStepsHelper(context);

        [When(@"The NonLevyEmployer reserves funding for an apprenticeship course from reserved panel")]
        public void WhenTheNonLevyEmployerReservesFundingForAnApprenticeshipCourseFromReservedPanel() => _reservationStepsHelper.CreateReservationViaDynamicHomePageTriageJourney();

        [Then(@"the Employer can reserve funding for an apprenticeship course")]
        public void ThenTheEmployerCanReserveFundingForAnApprenticeshipCourse() => _reservationStepsHelper.CreateReservation();
        
        [When(@"the Employer deletes all unused funding for an apprenticeship course")]
        public void WhenTheEmployerDeletesAllUnusedFundingForAnApprenticeshipCourse() => _yourFundingReservationsPage = _reservationStepsHelper.DeleteAllUnusedFunding();

        [Then(@"all the unused funding are successfully deleted")]
        public void ThenAllTheUnusedFundingAreSuccessfullyDeleted() => Assert.IsFalse(_yourFundingReservationsPage.CheckIfDeleteLinkIsPresent(), $"Delete link is present in the Manage Reservations page");
    }
}