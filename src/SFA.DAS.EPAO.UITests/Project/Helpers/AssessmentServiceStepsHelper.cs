using NUnit.Framework;
using SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails;
using SFA.DAS.UI.FrameworkHelpers;
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

        public void VerifyApprenticeGrade(string grade, LeanerCriteria leanerCriteria)
        {
            bool gradeValidation;

            var recordAGradePage = GoToRecordAGradePage();

            if (leanerCriteria.HasMultiStandards)
                gradeValidation = recordAGradePage.SearchApprentice(false).ViewCertificateHistory().VerifyGrade(grade);
            else
            {
                if (grade.ContainsCompareCaseInsensitive("pass")) gradeValidation = recordAGradePage.GoToAssesmentAlreadyRecordedPage().VerifyGrade(grade);

                else gradeValidation = recordAGradePage.SearchApprentice(false).VerifyGrade(grade);
            }

            Assert.AreEqual(true, gradeValidation, $"Apprentice grade is not recorded as {grade}");
        }

        public AS_CheckAndSubmitAssessmentPage CertifyApprentice(string grade, LeanerCriteria leanerCriteria, bool deleteCertificate)
        {
            var confirmApprenticePage = GoToRecordAGradePage().SearchApprentice(deleteCertificate);

            AS_DeclarationPage decPage = CertifyApprentice(confirmApprenticePage, leanerCriteria);

            return SelectGrade(decPage, grade);
        }
   
        public AS_AssessmentRecordedPage CertifyPrivatelyFundedApprenticeValidDateScenario()
        {
            return CertifyPrivatelyFundedApprentice()
                .EnterAchievementGradeDateForPrivatelyFundedApprenticeAndContinue()
                .ClickEnterAddressManuallyLinkInSearchEmployerPage()
                .EnterEmployerAddressAndContinue()
                .ClickContinueInConfirmEmployerAddressPage()
                .EnterRecipientDetailsAndContinue()
                .ClickContinueInCheckAndSubmitAssessmentPage();   
        }

        public AS_AchievementDatePage CertifyPrivatelyFundedApprentice()
        {
            return SearchApprentice(true)
                .GoToWhichVersionPage(false)
                .ClickConfirmInConfirmVersionPageNoOption()
                .ClickConfirmInDeclarationPageForPrivatelyFundedApprentice()
                .SelectGradeAsPass();
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

        private AS_ConfirmApprenticePage SearchApprentice(bool deleteCertificate) => GoToRecordAGradePage().SearchApprentice(deleteCertificate);

        private AS_RecordAGradePage GoToRecordAGradePage() => new AS_LoggedInHomePage(_context).GoToRecordAGradePage();

        private AS_CheckAndSubmitAssessmentPage SelectGrade(AS_DeclarationPage decpage, string grade)
        {
            decpage.ClickConfirmInDeclarationPage();

            new AS_WhatGradePage(_context).SelectGradeAndEnterDate(grade);

            if (grade == "pass")
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

        private AS_DeclarationPage CertifyApprentice(AS_ConfirmApprenticePage confirmApprenticePage, LeanerCriteria leanerCriteria)
        {
            if (leanerCriteria.HasMultipleVersions)
            {
                var whichVersionPage = confirmApprenticePage.GoToWhichVersionPage(leanerCriteria.HasMultiStandards);

                if (leanerCriteria.WithOptions) return whichVersionPage.ClickConfirmInConfirmVersionPage().SelectLearningOptionAndContinue();

                else return whichVersionPage.ClickConfirmInConfirmVersionPageNoOption();
            }
            else
            {
                if (leanerCriteria.WithOptions) return confirmApprenticePage.GoToWhichLearningOptionPage(leanerCriteria.HasMultiStandards).SelectLearningOptionAndContinue();

                else return confirmApprenticePage.GoToDeclarationPage(leanerCriteria.HasMultiStandards);
            }
        }
    }
}