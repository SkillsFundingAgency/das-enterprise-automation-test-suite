using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using SFA.DAS.Registration.UITests.Project.Helpers;
using System;
using TechTalk.SpecFlow;


namespace SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper
{
    public class MFEmployerStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly EmployerPortalLoginHelper _loginHelper;

        public MFEmployerStepsHelper(ScenarioContext context)
        {
            _context = context;
            _loginHelper = new EmployerPortalLoginHelper(_context);
        }

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage GoToReserveFunding()
        {
            var yourFundingReservationsPage = GoToManageFunding();
            return yourFundingReservationsPage.ClickReserveMoreFundingLink();
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

        public AddAnApprenitcePage AddAnApprentice(SuccessfullyReservedFundingPage successfullyReservedFundingPage)
        {
            return successfullyReservedFundingPage.AddApprentice();
        }

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage AddAnotherReservation(ReviewYourCohortPage reviewYourCohortPage)
        {
            return reviewYourCohortPage.SelectAddAnApprenticeUsingReservation()
                .ChooseCreateANewReservationRadioButton()
                .ClickSaveAndContinueButton();
        }

        public YourFundingReservationsPage GoToManageFunding()
        {
            return new YourFundingReservationsHomePage(_context).OpenYourFundingReservations();
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

        public DynamicHomePage ClickToReserveFunding(ReserveFundingToTrainAndAssessAnApprenticePage reserveFundingToTrainAndAssessAnApprenticePag)
        {
            return reserveFundingToTrainAndAssessAnApprenticePage
        }

    }
}
