using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages;
using SFA.DAS.ApprenticeRedundancy.UITests.Project.Test.Pages.Apprentice;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeRedundancy.UITests.Project.Helpers
{
    public class ApprenticeHelper
    {
        private readonly ScenarioContext _context;

        public ApprenticeHelper(ScenarioContext context) => _context = context;
        internal ApprenticeConfirmationPage CompleteApprenticeForm_HappyPath(MainLandingPage mainLandingPage)
        {
            mainLandingPage.NavigateToFindAnotherApprenticeship()
             .SelectAprpenticesStartnow()
                 .CompleteApprenticeDetails()
                 .ConfirmApprenticeAnswers();
            return new ApprenticeConfirmationPage(_context);
        }

        internal ApprenticeDetailsPage ContinueWithoutAllMandatoryFieldsCompletedForApprenticeForm(MainLandingPage mainLandingPage)
        {
            mainLandingPage.NavigateToFindAnotherApprenticeship()
             .SelectAprpenticesStartnow()
             .ContinueToApprenticeCheckAnswersPage();
            return new ApprenticeDetailsPage(_context);
        }

        internal ApprenticeDetailsPage NavigateToApprenticeDetailsPage(MainLandingPage mainLandingPage)
        {
            mainLandingPage.NavigateToFindAnotherApprenticeship()
             .SelectAprpenticesStartnow()
             .CompleteApprenticeDetails();
            return new ApprenticeDetailsPage(_context);
        }
        internal Apprentice_CheckYourAnswersPage VerifyApprenticeChangelinks(Apprentice_CheckYourAnswersPage _CheckYourAnswersPage)
        {
            _CheckYourAnswersPage.ClickChangeYourDetailsLink()
                .NavigateBackToApprenticeCheckYourAnswerssPage()
                .ClickChangeYourLocationLink()
                .NavigateBackToApprenticeCheckYourAnswerssPage()
                .ClickChangePreviousApprenticeShipLink()
                .NavigateBackToApprenticeCheckYourAnswerssPage()
                .ClickChangeApprenticeshipsYouAreInterestedLink()
                .NavigateBackToApprenticeCheckYourAnswerssPage()
                .ClickChangeEthnicGroupLink()
                .NavigateBackToApprenticeCheckYourAnswerssPage()
                .ClickChangeGenderLink()
                .NavigateBackToApprenticeCheckYourAnswerssPage();
            return new Apprentice_CheckYourAnswersPage(_context);
        }
        internal Apprentice_CheckYourAnswersPage ClickChangeAndUpdatePreviousApprenticeshipDetails(Apprentice_CheckYourAnswersPage _CheckYourAnswersPage)
        {
            _CheckYourAnswersPage.ClickChangePreviousApprenticeShipLink()
                 .UpdatePreviousApprenticeshipDetails();
            return new Apprentice_CheckYourAnswersPage(_context);
        }
        internal Apprentice_CheckYourAnswersPage VerifyUpdatedPreviousApprenticeshipDetails(Apprentice_CheckYourAnswersPage _CheckYourAnswersPage)
        {
            _CheckYourAnswersPage.VerifyUpdatedPreviousApprenticeshipTrainingDetails("Regression test Information Technology");
            _CheckYourAnswersPage.VerifyUpdatedPreviousApprenticeshipEmployerDetails("Regression Test Apprentice Digital Education");
            _CheckYourAnswersPage.VerifyUpdatedPreviousApprenticeshipTrainingProviderDetails("Update TEST Regression");
            return new Apprentice_CheckYourAnswersPage(_context);
        }
    }
}
