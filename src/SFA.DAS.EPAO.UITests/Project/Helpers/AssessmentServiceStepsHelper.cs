using SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails;
using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class AssessmentServiceStepsHelper
    {
        private readonly ScenarioContext _context;
        private AS_LoggedInHomePage _loggedInHomePage;
        private readonly TabHelper _tabHelper;
        private EPAOConfig _ePAOConfig;
        private readonly EPAOAdminDataHelper _ePAOAdminDataHelper;


        public AssessmentServiceStepsHelper(ScenarioContext context)
        {
            _context = context;
            _tabHelper = context.Get<TabHelper>();
            _ePAOConfig = context.GetEPAOConfig<EPAOConfig>();
            _ePAOAdminDataHelper = context.Get<EPAOAdminDataHelper>();
        }

        public AS_LandingPage LaunchAssessmentServiceApplication()
        {
            _tabHelper.GoToUrl(_ePAOConfig.AssessmentServiceUrl);
            return new AS_LandingPage(_context);
        }

        public AS_LoggedInHomePage LoginToAssessmentServiceApplication(LoginUser user) => _loggedInHomePage = new AS_LandingPage(_context).ClickStartButton().SignInWithValidDetails(user);   

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
        public void DeleteApprenticeCertificateRecord(string grade, string enrolledStandard)
        {
            new AS_LoggedInHomePage(_context).ClickOnRecordAGrade()
                .SearchApprentice(enrolledStandard)
                .ClickConfirmInConfirmApprenticePage(enrolledStandard)
                .ClickConfirmInDeclarationPage();

            if (enrolledStandard == "deleting")
                new AS_WhichLearningOptionPage(_context).SelectWhichLearningOptionAndContinue();

            new AS_WhatGradePage(_context).SelectGradeAndEnterDate(grade);

            if (grade == "Passed")
                new AS_SearchEmployerAddressPage(_context).ClickEnterAddressManuallyLinkInSearchEmployerPage()
                    .EnterEmployerAddressAndContinue()
                    .ClickContinueInConfirmEmployerAddressPage()
                    .EnterRecipientDetailsAndContinue();
        }

        public void ReRequestApprenticeCertificateRecord(string grade, string enrolledStandard)
        {
            new AS_LoggedInHomePage(_context).ClickOnRecordAGrade()
                .SearchApprentice(enrolledStandard)
                .ClickConfirmInConfirmApprenticePage(enrolledStandard)
                .ClickConfirmInDeclarationPage();

            if (enrolledStandard == "ReRequesting")
                new AS_WhichLearningOptionPage(_context).SelectWhichLearningOptionAndContinue();

            new AS_WhatGradePage(_context).SelectGradeAndEnterDate(grade);

            if (grade == "PassWithExcellence")
                new AS_ConfirmAddressPage(_context).ClickContinueInConfirmEmployerAddressPage()
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

        public string InviteAUser(AS_LoggedInHomePage _loggedInHomePage)
        {
            return _loggedInHomePage.ClickManageUsersLink()
                .ClickInviteNewUserButton()
                .EnterUserDetailsAndSendInvite();      
        }

        public void DeleteCertificate()
        {
            _tabHelper.GoToUrl(_ePAOConfig.AdminBaseUrl);
            GoToEpaoAdminHomePage().Search().SearchFor(_ePAOAdminDataHelper.DeleteIncorrectRecordUln).SelectACertificate()
               .ClickDeleteCertificateLink()
               .ClickYesAndContinue()
               .EnterAuditDetails()
               .ClickDeleteCertificateButton()
               .ClickReturnToDashboard();
        }
        private StaffDashboardPage GoToEpaoAdminHomePage()
        {
            new ServiceStartPage(_context).ClickStartNow().LoginToAccess1Staff();

            return new SignInPage(_context).SignInWithValidDetails();
        }
    }
}