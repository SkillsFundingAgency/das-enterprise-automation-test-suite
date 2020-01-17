using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails;
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
            return _loggedInHomePage = new AS_LandingPage(_context).ClickStartButton().SignInWithValidDetails(user);   
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

        public AS_OrganisationDetailsPage ChangeContactName(AS_OrganisationDetailsPage organisationDetailsPage, string selection)
        {
            return organisationDetailsPage.ClickContactNameChangeLink()
                .SelectContactNameRadioButtonAndClickSave(selection)
                .ClickConfirmButtonInConfirmContactNamePage()
                .ClickViewOrganisationDetailsLink();
        }

        public AS_OrganisationDetailsPage ChangePhoneNumber(AS_OrganisationDetailsPage organisationDetailsPage)
        {
            return organisationDetailsPage.ClickPhoneNumberChangeLink()
               .EnterRandomPhoneNumberAndClickUpdate()
               .ClickConfirmButtonInConfirmPhoneNumberPage()
               .ClickViewOrganisationDetailsLink();
        }

        public AS_OrganisationDetailsPage ChangeAddress(AS_OrganisationDetailsPage organisationDetailsPage)
        {
            return organisationDetailsPage.ClickAddressChangeLink()
                .ClickSearchForANewAddressLink()
                .ClickEnterTheAddressManuallyLink()
                .EnterEmployerAddressAndClickChangeAddressButton()
                .ClickConfirmAddressButtonInConfirmContactAddressPage()
                .ClickViewOrganisationDetailsLink();
        }

        public AS_OrganisationDetailsPage ChangeEmailAddress(AS_OrganisationDetailsPage organisationDetailsPage)
        {
            return organisationDetailsPage.ClickEmailChangeLink()
                .EnterRandomEmailAndClickChange()
                .ClickConfirmButtonInConfirmEmailAddressPage()
                .ClickViewOrganisationDetailsLink();
        }

        public AS_OrganisationDetailsPage ChangeWebsiteAddress(AS_OrganisationDetailsPage organisationDetailsPage)
        {
            return organisationDetailsPage.ClickWebsiteChangeLink()
                .EnterRandomWebsiteAddressAndClickUpdate()
                .ClickConfirmButtonInConfirmWebsiteAddressPage()
                .ClickViewOrganisationDetailsLink();
        }
    }
}
