using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using SFA.DAS.ConfigurationBuilder;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    public class ManageFundingEmployerStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly ReservationsSqlDataHelper _reservationsSqlDataHelper;
        
        private WhenWillTheApprenticeStartTheirApprenticeshipTrainingPage _whenWillTheApprenticeStartTheirApprenticeshipTrainingPage;

        public ManageFundingEmployerStepsHelper(ScenarioContext context)
        {
            _context = context;
            _reservationsSqlDataHelper = new ReservationsSqlDataHelper(context.Get<DbConfig>());
        }

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage GoToReserveFunding() => GoToManageFundingHomePage().ClickReserveMoreFundingLink();

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

        public void AddDynamicPauseGlobalRule(DateTime activeFrom, DateTime activeTo)
        {
            var id = _reservationsSqlDataHelper.InsertDynamicPauseGlobalRule(activeFrom, activeTo, _context.ScenarioInfo.Title);
            _context.Set(id, "DynamicPauseGlobalRuleId");
        }

        public void RemoveDynamicPauseGlobalRule()
        {
            if (_context.TryGetValue("DynamicPauseGlobalRuleId", out int id))
            {
                _reservationsSqlDataHelper.DeleteDynamicPauseGlobalRule(id);
            }
        }

        public SuccessfullyReservedFundingPage CreateReservation() => CreateReservation(GoToReserveFunding());
        
        public void StartCreateReservationAndGoToStartTrainingPage()
        {
            _whenWillTheApprenticeStartTheirApprenticeshipTrainingPage = GoToReserveFunding()
                .ClickYesRadioButton()
                .EnterSelectForACourseAndSubmit()
                .ClickSaveAndContinueButton();
        }

        public void VerifyReserveFromMonth(DateTime? reserveFromMonth)
        {
            _whenWillTheApprenticeStartTheirApprenticeshipTrainingPage.VerifyReserveFromMonth(reserveFromMonth);
        }

        public void VerifySuggestedStartMonthOptions(DateTime? firstMonth, DateTime? secondMonth, DateTime? thirdMonth)
        {
            _whenWillTheApprenticeStartTheirApprenticeshipTrainingPage.VerifySuggestedStartMonthOptions(firstMonth, secondMonth, thirdMonth);
        }

        public void CompleteCreateReservationFromStartTrainingPage()
        {
            _whenWillTheApprenticeStartTheirApprenticeshipTrainingPage
                .ClickMonthRadioButton()
                .ClickSaveAndContinueButton()
                .ClickYesReserveFundingNowRadioButton()
                .ClickConfirmButton();
        }

        public void VerifyCreateReservationCannotBeCompleted()
        {
            _whenWillTheApprenticeStartTheirApprenticeshipTrainingPage
                .ClickSaveAndContinueButtonAndExpectProblem()
                .VerifyProblem("You must select a start date");
        }

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

        public ManageFundingHomePage DeleteAllUnusedFunding()
        {
            var yourFundingReservationsPage = GoToManageFundingHomePage();

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

        private ManageFundingHomePage GoToManageFundingHomePage() => new ManageFundingHomePage(_context, true);

        private DynamicHomePages GoToDynamicHomePage() => new DynamicHomePages(_context);
    }
}