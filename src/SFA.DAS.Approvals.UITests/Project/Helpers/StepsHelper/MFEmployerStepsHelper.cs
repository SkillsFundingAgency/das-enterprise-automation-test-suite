using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    public class MFEmployerStepsHelper
    {
        private readonly ScenarioContext _context;
        
        public MFEmployerStepsHelper(ScenarioContext context)
        {
            _context = context;
        }
        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage ClickReserveFundingFromHomepage() => GoToManageFunding().ClickReserveMoreFundingLink();
        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage GoToReserveFunding()
        {
            return new DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage(_context);
        }
        public AddAnApprenitcePage GoToAddAnApprentices()
        {
            ContinueToCreateAddAnApprentices();
            return new DoYouNeedToCreateAnAdvertPage(_context).ClickNoRadioButtonTakesToAddAnApprentices();
        }
        private  void ContinueToCreateAddAnApprentices() => new DynamicHomePages(_context).ContinueToCreateAdvert();
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
        public SuccessfullyReservedFundingPage VerifySuccessfullyReservedFundingPage()
        {

            return new SuccessfullyReservedFundingPage(_context);
        }
        private YourFundingReservationsPage GoToManageFunding() => new YourFundingReservationsHomePage(_context).OpenYourFundingReservations();
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
    }
}