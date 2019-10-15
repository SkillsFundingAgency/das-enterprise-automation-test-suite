using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
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
            //_loginHelper.Login(_context.GetUser<EoiUser>(), false);

            return new YourFundingReservationsHomePage(_context).OpenYourFundingReservations()
                .ClickReserveMoreFundingLink()
                .ClickReserveFundingButton();
        }

        public MakingChangesPage CreateReservation(DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage doYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage)
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

        public AddAnApprenitcePage AddAnApprentice(MakingChangesPage makingChangesPage)
        {
            return makingChangesPage.AddApprentice();
        }

        public DoYouKnowWhichApprenticeshipTrainingYourApprenticeWillTakePage AddAnotherReservation(ReviewYourCohortPage reviewYourCohortPage)
        {
            return reviewYourCohortPage.SelectAddAnApprenticeUsingReservation()
                .ChooseCreateANewReservationRadioButton()
                .ClickSaveAndContinueButton();
        }
    }
}
