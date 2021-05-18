using SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class AssessmentServiceStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly EPAOAdminDataHelper _ePAOAdminDataHelper;

        public AssessmentServiceStepsHelper(ScenarioContext context)
        {
            _context = context;
            _ePAOAdminDataHelper = context.Get<EPAOAdminDataHelper>();
        }

        public AS_CheckAndSubmitAssessmentPage CertifyApprentice(string grade, string enrolledStandard, bool hasMultipleVersions, bool withOptions, bool hasMultiStandards)
        {
            var whichVersionPage = SearchApprentice(enrolledStandard).GoToWhichVersionPage(hasMultiStandards);

            AS_DeclarationPage decPage = CertifyApprentice(whichVersionPage, hasMultipleVersions, withOptions);

            return SelectGrade(decPage, grade);
        }

        private AS_DeclarationPage CertifyApprentice(AS_WhichVersionPage whichVersionPage, bool hasMultipleVersions, bool withOptions)
        {
            if (!(hasMultipleVersions)) return whichVersionPage.ClickConfirmInConfirmVersionPageNoOption();
            else
            {
                if (withOptions) return whichVersionPage.ClickConfirmInConfirmVersionPage().SelectLearningOptionAndContinue();
                else return whichVersionPage.ClickConfirmInConfirmVersionPageNoOption();
            }
        }

        public AS_CheckAndSubmitAssessmentPage ApprenticeCertificateRecord(string grade, string enrolledStandard)
        {
            var decPage = SearchApprentice(enrolledStandard).GoToWhichLearningOptionPage().SelectLearningOptionAndContinue();

            return SelectGrade(decPage, grade);
        }
            
        public void CertifyPrivatelyFundedApprentice(bool invalidDateScenario)
        {
            SearchApprentice("PrivatelyFundedApprentice")
                .GoToWhichVersionPage(false)
                .ClickConfirmInConfirmVersionPageNoOption()
                .ClickConfirmInDeclarationPageForPrivatelyFundedApprentice()
                .SelectGradeForPrivatelyFundedAprrenticeAndContinue();               

            if (invalidDateScenario == false)
            {
                new AS_AchievementDatePage(_context).EnterAchievementGradeDateForPrivatelyFundedApprenticeAndContinue()
                .ClickEnterAddressManuallyLinkInSearchEmployerPage()
                .EnterEmployerAddressAndContinue()
                .ClickContinueInConfirmEmployerAddressPage()
                .EnterRecipientDetailsAndContinue()
                .ClickContinueInCheckAndSubmitAssessmentPage();
            }
        }

        public void RemoveChangeOrgDetailsPermissionForTheUser(AS_LoggedInHomePage loggedInHomePage)
        {
            loggedInHomePage.ClickManageUsersLink()
                .ClickManageUserNameLink()
                .ClickEditUserPermissionLink()
                .UnSelectChangeOrganisationDetailsCheckBox()
                .ClickSaveButton();
        }

        public AS_OrganisationDetailsPage ChangeContactName(AS_OrganisationDetailsPage organisationDetailsPage)
        {
            return organisationDetailsPage.ClickContactNameChangeLink()
                .SelectContactNameRadioButtonAndClickSave()
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

        public string InviteAUser(AS_LoggedInHomePage _loggedInHomePage) => _loggedInHomePage.ClickManageUsersLink().ClickInviteNewUserButton().EnterUserDetailsAndSendInvite(); 

        public void DeleteCertificate(StaffDashboardPage staffDashboardPage)
        {
            staffDashboardPage
                .Search()
                .SearchFor(_ePAOAdminDataHelper.DeleteIncorrectRecordUln)
                .SelectACertificate()
                .ClickDeleteCertificateLink()
                .ClickYesAndContinue()
                .EnterAuditDetails()
                .ClickDeleteCertificateButton()
                .ClickReturnToDashboard();
        }

        private AS_ConfirmApprenticePage SearchApprentice(string enrolledStandard) => new AS_LoggedInHomePage(_context).ClickOnRecordAGrade().SearchApprentice(enrolledStandard);

        private AS_CheckAndSubmitAssessmentPage SelectGrade(AS_DeclarationPage decpage, string grade)
        {
            decpage.ClickConfirmInDeclarationPage();

            new AS_WhatGradePage(_context).SelectGradeAndEnterDate(grade);

            if (grade == "Passed" || grade == "pass")
            {
                return new AS_SearchEmployerAddressPage(_context)
                .ClickEnterAddressManuallyLinkInSearchEmployerPage()
                .EnterEmployerAddressAndContinue()
                .ClickContinueInConfirmEmployerAddressPage()
                .EnterRecipientDetailsAndContinue();
            }
            else if (grade == "PassWithExcellence")
            {
                return new AS_ConfirmAddressPage(_context)
                    .ClickContinueInConfirmEmployerAddressPage()
                    .EnterRecipientDetailsAndContinue();
            }

            return new AS_CheckAndSubmitAssessmentPage(_context);
        }
    }
}