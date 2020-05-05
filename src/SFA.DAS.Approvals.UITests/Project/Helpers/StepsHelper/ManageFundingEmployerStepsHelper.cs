using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    public class ManageFundingEmployerStepsHelper
    {
        private readonly ScenarioContext _context;
        
        public ManageFundingEmployerStepsHelper(ScenarioContext context) => _context = context;

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage GoToReserveFunding() => GoToManageFunding().ClickReserveMoreFundingLink();

        public DynamicHomePages CreateReservationViaDynamicHomePageTriageJourney()
        {
            var reservedPage = CreateReservation(GoToDynamicHomePage()
                .StartNowToReserveFunding()
                 .YesToCourse()
                 .YesToTrainingProviderToDeliver()
                 .YesWillTrainingStartInSixMonths()
                 .YesSetupForExistingEmployee()
                 .YesContinueToReserveFunding()
                 .ClickReserveFundingButton());

            return VerifyContinueOnHomePagePanel(reservedPage);
        }

        public DynamicHomePages VerifyContinueOnHomePagePanel(SuccessfullyReservedFundingPage successfullyReservedFundingPage) => successfullyReservedFundingPage.GoToDynamicHomePage().VerifyReserveFundingPanel();

        public AddAnApprenitcePage GoToAddAnApprentices()
        {
            GoToDynamicHomePage().ContinueToCreateAdvert();

            return new DoYouNeedToCreateAnAdvertPage(_context).ClickNoRadioButtonTakesToAddAnApprentices();
        }

        public SuccessfullyReservedFundingPage CreateReservation() => CreateReservation(GoToReserveFunding());
        
        public SuccessfullyReservedFundingPage CreateReservation(DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage doYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage)
        {
            return doYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage
                .ClickYesRadioButton()
                .EnterSelectForACourseAndSubmit()
                .ClickSaveAndContinueButton()
                .ClickMonthRadioButton()
                .ClickSaveAndContinueButton()
                .ClickYesReserveFundingNowRadioButton()
                .ClickConfirmButton();
        }

        public YourFundingReservationsPage DeleteAllUnusedFunding()
        {
            var yourFundingReservationsPage = GoToManageFunding();

            while (yourFundingReservationsPage.CheckIfDeleteLinkIsPresent())
            {
                yourFundingReservationsPage.DeleteUnusedFunding()
                    .ChooseDeleteReservationRadioButton()
                    .ClickConfirmButton()
                    .ChooseReturnToManageReservationRadioButton()
                    .ClickConfirmButton();
            }
            return yourFundingReservationsPage;
        }

        private YourFundingReservationsPage GoToManageFunding() => new YourFundingReservationsHomePage(_context).OpenYourFundingReservations();

        private DynamicHomePages GoToDynamicHomePage() => new DynamicHomePages(_context);
    }
}