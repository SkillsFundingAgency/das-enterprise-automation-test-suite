using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class MFEmployerSteps
    {
        private YourFundingReservationsPage _yourFundingReservationsPage;
        private readonly ScenarioContext _context;
        private readonly MFEmployerStepsHelper _reservationStepsHelper;
        private DynamicHomePageStepsHelper _dynamicHomePageStepsHelper;
        public MFEmployerSteps(ScenarioContext context)
        {
            _context = context;
            _reservationStepsHelper = new MFEmployerStepsHelper(context);
            _dynamicHomePageStepsHelper = new DynamicHomePageStepsHelper(context);           
        }

        [Then(@"The new reserved funding panel is shown to nonlevyemployer on the homepage")]
        public void ThenTheNewReservedFundingPanelIsShownToNonLevyEmployerOnTheHomepage()
        {   
            _dynamicHomePageStepsHelper.DynamicHomePageGoToHome();
            _dynamicHomePageStepsHelper.DynamicHomePageVerifyContinueOnHomePagePanel();
        }
            

        [When(@"The NonLevyEmployer reserves funding for an apprenticeship course from reserved panel")]
        public void WhenTheNonLevyEmployerReservesFundingForAnApprenticeshipCourseFromReservedPanel()
        {
            _dynamicHomePageStepsHelper.DynamicHomePageTriageJourney();
            _reservationStepsHelper.CreateReservation(_reservationStepsHelper.GoToReserveFunding());
        }

        
        [When(@"the Employer reserves funding for an apprenticeship course")]
        public void WhenTheEmployerReservesFundingForAnApprenticeshipCourse()
        {
            _reservationStepsHelper.ClickReserveFundingFromHomepage();
            _reservationStepsHelper.CreateReservation(_reservationStepsHelper.GoToReserveFunding());
        }

        [Then(@"The funding is successfully reserved")]
        public void ThenTheFundingIsSuccessfullyReserved()
        {
            _reservationStepsHelper.VerifySuccessfullyReservedFundingPage();
        }
        
        [When(@"the Employer deletes all unused funding for an apprenticeship course")]
        public void WhenTheEmployerDeletesAllUnusedFundingForAnApprenticeshipCourse() => _yourFundingReservationsPage = _reservationStepsHelper.DeleteAllUnusedFunding();

        [Then(@"all the unused funding are successfully deleted")]
        public void ThenAllTheUnusedFundingAreSuccessfullyDeleted() => Assert.IsFalse(_yourFundingReservationsPage.CheckIfDeleteLinkIsPresent(), $"Delete link is present in the Manage Reservations page");
    }
}