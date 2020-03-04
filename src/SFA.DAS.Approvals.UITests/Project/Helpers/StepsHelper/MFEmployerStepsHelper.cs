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

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage GoToReserveFunding() => GoToManageFunding().ClickReserveMoreFundingLink();

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage GoToReserveFundingFromHomePagePanel() => new DynamicHomePage(_context).StartNowToReserveFunding().ClickReserveFundingButton();

        public AddAnApprenitcePage GoToAddAnApprentices()
        {
            ContinueToCreateAddAnApprentices();
            return new DoYouNeedToCreateAnAdvertPage(_context).ClickNoRadioButtonTakesToAddAnApprentices();
        }

        private DoYouNeedToCreateAnAdvertBasePage ContinueToCreateAddAnApprentices() => new DynamicHomePage(_context).ContinueToCreateAdvert();

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
