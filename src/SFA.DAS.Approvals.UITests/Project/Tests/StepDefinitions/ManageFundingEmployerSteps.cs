using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ManageFundingEmployerSteps : BaseSteps
    {
        private ManageFundingHomePage _yourFundingReservationsPage;
        private readonly ManageFundingEmployerStepsHelper _reservationStepsHelper;

        public ManageFundingEmployerSteps(ScenarioContext context) => _reservationStepsHelper = new ManageFundingEmployerStepsHelper(context);

        [When(@"The NonLevyEmployer reserves funding for an apprenticeship course from reserved panel")]
        public void WhenTheNonLevyEmployerReservesFundingForAnApprenticeshipCourseFromReservedPanel() => _reservationStepsHelper.CreateReservationViaDynamicHomePageTriageJourney();

        [Then(@"the Employer can reserve funding for an apprenticeship course")]
        public void ThenTheEmployerCanReserveFundingForAnApprenticeshipCourse() => _reservationStepsHelper.CreateReservation();

        [When(@"the Employer creates a reservation")]
        public void WhenTheEmployerCreatesAReservation() =>
            _reservationStepsHelper.StartCreateReservationAndGoToStartTrainingPage();

        [Then(@"the Employer is told that funding can be reserved from (.*)")]
        public void ThenTheEmployerIsPresentedWithFirstMonthSecondMonthAndThirdMonthForTheApprenticeshipStart(string monthReserveFrom) =>
            _reservationStepsHelper.VerifyReserveFromMonth(ParseMonth(monthReserveFrom));

        [Then(@"the Employer is given options (.*), (.*) and (.*) to select start date")]
        public void ThenGivenOptionsToSelectStartDate(string firstMonth, string secondMonth, string thirdMonth) =>
            _reservationStepsHelper.VerifySuggestedStartMonthOptions(ParseMonth(firstMonth), ParseMonth(secondMonth), ParseMonth(thirdMonth));

        [Then(@"the Employer is (able|not able) to reserve funding for an apprenticeship course")]
        public void ThenTheEmployerCanOrCannotReserveFundingForAnApprenticeshipCourse(string ableOrNotAble)
        {
            if (ableOrNotAble == "able") _reservationStepsHelper.CompleteCreateReservationFromStartTrainingPage();
            else if (ableOrNotAble == "not able") _reservationStepsHelper.VerifyCreateReservationCannotBeCompleted();
        }

        [When(@"the Employer deletes all unused funding for an apprenticeship course")]
        public void WhenTheEmployerDeletesAllUnusedFundingForAnApprenticeshipCourse() => _yourFundingReservationsPage = _reservationStepsHelper.DeleteAllUnusedFunding();

        [Then(@"all the unused funding are successfully deleted")]
        public void ThenAllTheUnusedFundingAreSuccessfullyDeleted() => Assert.IsFalse(_yourFundingReservationsPage.CheckIfDeleteLinkIsPresent(), $"Delete link is present in the Manage Reservations page");
    }
}