using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.DynamicHomePage;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
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
        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage GoToReserveFundingFromHomePage()
        {
            var reserveFunding = ClickReserveFundingLinkFromHomePagePanel();
            return reserveFunding.ClickReserveFundingButton();
        }

        public AddAnApprenitcePage GoToAddAnApprentices()
        {
            var addAnApprentices = ContinueToAddAnApprentices();
            return addAnApprentices.ClickNoRadioButtonTakesToAddAnApprentices();
        }

        public DoYouNeedToCreateAnAdverForThisApprenticeshipPage ContinueToAddAnApprentices()
        {
            return new DynamicHomePage(_context).ClickContinueToCreateAdvertOrAddAnApprentices();
        }

        public ReserveFundingToTrainAndAssessAnApprenticePage ClickReserveFundingLinkFromHomePagePanel()
        {
            return new DynamicHomePage(_context).ClickToReserveFunding();
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

        public HomePage GoToDynamicHomePage()
        {
            return new SuccessfullyReservedFundingPage(_context).GoToHomePage();
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
    }
}
