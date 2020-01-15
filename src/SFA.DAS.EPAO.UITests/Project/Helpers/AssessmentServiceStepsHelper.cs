using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class AssessmentServiceStepsHelper
    {
        private readonly ScenarioContext _context;
        private AS_LoggedInHomePage _loggedInHomePage;

        public AssessmentServiceStepsHelper(ScenarioContext context)
        {
            _context = context;
        }

        public AS_LoggedInHomePage LoginToAssessmentServiceApplication(string user)
        {
            _loggedInHomePage = new AS_LandingPage(_context).ClickStartButton().SignInWithValidDetails(user);
            return new AS_LoggedInHomePage(_context);
        }

        public void CertifyApprentice(string grade, string enrolledStandard)
        {
            new AS_LoggedInHomePage(_context).ClickOnRecordAGrade()
                .SearchApprentice(enrolledStandard)
                .ClickConfirmInConfirmApprenticePage(enrolledStandard)
                .ClickConfirmInDeclarationPage();

            if (enrolledStandard == "additional learning option")
                new AS_WhichLearningOptionPage(_context).SelectLearningOptionAndContinue();

            new AS_WhatGradePage(_context).SelectGradeAndEnterDate(grade);

            if (grade == "Passed")
            new AS_SearchEmployerAddressPage(_context).ClickEnterAddressManuallyLinkInSearchEmployerPage()
                .EnterEmployerAddressAndContinue()
                .ClickContinueInConfirmEmployerAddressPage()
                .EnterRecipientDetailsAndContinue();
        }

        public void CertifyPrivatelyFundedApprentice(bool invalidDateScenario = false)
        {
            new AS_LoggedInHomePage(_context).ClickOnRecordAGrade()
                .SearchPrivatelyFundedApprentice()
                .ClickConfirmInDeclarationPageForPrivatelyFundedApprentice()
                .EnterGivenNameAndContinue()
                .SelectStandardAndContinue()
                .SelectGradeForPrivatelyFundedAprrenticeAndContinue()
                .EnterApprenticshipStartDateAndContinue()
                .EnterUkprnAndContinue();

            if (!invalidDateScenario)
            {
                new AS_AchievementDatePage(_context).EnterAchievementGradeDateForPrivatelyFundedApprenticeAndContinue()
                .ClickEnterAddressManuallyLinkInSearchEmployerPage()
                .EnterEmployerAddressAndContinue()
                .ClickContinueInConfirmEmployerAddressPage()
                .EnterRecipientDetailsAndContinue()
                .ClickContinueInCheckAndSubmitAssessmentPage();
            }
        }

        public void RemoveChangeOrgDetailsPermissionForTheUser()
        {
            _loggedInHomePage.ClickManageUsersLink()
                .ClickManageUserNameLink()
                .ClickEditUserPermissionLink()
                .UnSelectChangeOrganisationDetailsCheckBox()
                .ClickSaveButton();
        }
    }
}
