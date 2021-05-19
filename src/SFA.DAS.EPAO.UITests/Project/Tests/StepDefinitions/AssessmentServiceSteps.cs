using NUnit.Framework;
using SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AssessmentServiceSteps : EPAOBaseSteps
    {
        private readonly ScenarioContext _context;
        private bool _permissionsSelected;
        private string _newUserEmailId;

        private AS_AssessmentRecordedPage assessmentRecordedPage;

        public AssessmentServiceSteps(ScenarioContext context) : base(context) => _context = context;

        [Given(@"the (Assessor User|Delete Assessor User|Standard Apply User|Manage User|EPAO Withdrawal User) is logged into Assessment Service Application")]
        [When(@"the (Assessor User|Delete Assessor User|Standard Apply User|Manage User|Standard Withdrawal User) is logged into Assessment Service Application")]
        public void GivenTheUserIsLoggedIntoAssessmentServiceApplication(string user)
        {
            if (user.Equals("Assessor User"))
                loggedInHomePage = ePAOHomePageHelper.LoginInAsNonApplyUser(_context.GetUser<EPAOAssessorUser>());

            else if (user.Equals("Delete Assessor User"))
                loggedInHomePage = ePAOHomePageHelper.LoginInAsNonApplyUser(_context.GetUser<EPAODeleteAssessorUser>());

            else if (user.Equals("Manage User"))
                loggedInHomePage = ePAOHomePageHelper.LoginInAsNonApplyUser(_context.GetUser<EPAOManageUser>());

            else if (user.Equals("Standard Apply User"))
                loggedInHomePage = ePAOHomePageHelper.LoginInAsStandardApplyUser(_context.GetUser<EPAOStandardApplyUser>(), ePAOApplyStandardData.ApplyStandardCode, ePAOApplyStandardData.StandardAssessorOrganisationEpaoId);

            else if (user.Equals("EPAO Withdrawal User"))
                loggedInHomePage = ePAOHomePageHelper.LoginInAsNonApplyUser(_context.GetUser<EPAOWithdrawalUser>());
        }

        [When(@"the User certifies an Apprentice as '(pass|fail)'")]
        public void WhenTheUserCertifiesAnApprenticeAsWhoHasEnrolledForStandard(string grade) => assessmentRecordedPage = RecordAGrade(grade, SetLearnerDetails(), true);

        [When(@"the User certifies same Apprentice as pass")]
        public void WhenTheUserCertifiesSameApprenticeAsPass() => assessmentRecordedPage = RecordAGrade("pass", GetLearnerCriteria(), false);

        [When(@"the User requests wrong certificate certifying an Apprentice as '(.*)' which needs '(.*)'")]
        public void WhenTheUserRequestsWrongCertificateCertifyingAnApprenticeAsWhichNeeds(string grade, string enrolledStandard)
        {
            var page = assessmentServiceStepsHelper.ApprenticeCertificateRecord(grade, enrolledStandard);

            page.ClickContinueInCheckAndSubmitAssessmentPage();
        }

        [Then(@"the Assessment is recorded as '(pass|fail)'")]
        public void ThenTheAssessmentIsRecordedAs(string grade) => assessmentServiceStepsHelper.VerifyApprenticeGrade(grade, GetLearnerCriteria());


        [Then(@"the Admin user can delete a certificate that has been incorrectly submitted")]
        public void ThenTheAdminUserCanDeleteACertificateThatHasBeenIncorrectlySubmitted()
        {
            var staffdashboard = ePAOHomePageHelper.LoginToEpaoAdminHomePage(true);

            assessmentServiceStepsHelper.DeleteCertificate(staffdashboard);
        }

        [Then(@"the User is able to rerequest the certificate certifying an Apprentice as '(.*)' which was'(.*)'")]
        public void ThenTheUserIsAbleToRerequestTheCertificateCertifyingAnApprenticeAsWhichWas(string grade, string enrolledStandard)
        {
            var page = assessmentServiceStepsHelper.ApprenticeCertificateRecord(grade, enrolledStandard);

            page.ClickContinueInCheckAndSubmitAssessmentPage();
        }
        
        [When(@"the User goes through certifying a Privately funded Apprentice")]
        public void WhenTheUserGoesThroughCertifyingAPrivatelyFundedApprentice() => assessmentServiceStepsHelper.CertifyPrivatelyFundedApprentice(false);

        [Then(@"the User can navigates to record another grade")]
        public void ThenTheUserCanNavigatesToRecordAnotherGrade() => assessmentRecordedPage.ClickRecordAnotherGradeLink();

        [Then(@"'(.*)' message is displayed")]
        public void ThenErrorMessageIsDisplayed(string errorMessage) => Assert.AreEqual(recordAGradePage.GetPageTitle(), errorMessage);

        [Then(@"the '(.*)' is displayed")]
        public void ThenErrorIsDisplayed(string errorMessage)
        {
            switch (errorMessage)
            {
                case "Family name and ULN missing error":
                    Assert.IsTrue(recordAGradePage.VerifyFamilyNameMissingErrorText(), "FamilyName missing Error Text is incorrect");
                    Assert.IsTrue(recordAGradePage.VerifyULNMissingErrorText(), "ULN missing Error Text is incorrect");
                    break;
                case "Family name missing error":
                    Assert.IsTrue(recordAGradePage.VerifyFamilyNameMissingErrorText(), "FamilyName missing Error Text is incorrect");
                    break;
                case "ULN missing error":
                    Assert.IsTrue(recordAGradePage.VerifyULNMissingErrorText(), "ULN missing Error Text is incorrect");
                    break;
                case "ULN validation error":
                    Assert.IsTrue(recordAGradePage.VerifyInvalidUlnErrorText(), "ULN validation Error Text is incorrect");
                    break;
            }
        }

        [When(@"the User clicks on the continue button '(.*)'")]
        public void WhenTheUserClicksOnTheContinueButton(string scenario)
        {
            string familyName = ePAOAdminDataHelper.LastName, uln = ePAOAdminDataHelper.LearnerUln;

            switch (scenario)
            {
                case "with out entering Any details":
                    familyName = string.Empty; uln = string.Empty; 
                    break;
                case "by entering valid Family name and blank ULN":
                    uln = string.Empty;
                    break;
                case "by entering blank Family name and Valid ULN":
                    familyName = string.Empty;
                    break;
                case "by entering valid Family name but ULN less than 10 digits":
                    uln = ePAOAssesmentServiceDataHelper.GetRandomNumber(9);
                    break;
                case "by entering valid Family name and Invalid ULN":
                    uln = ePAOAssesmentServiceDataHelper.GetRandomNumber(11);
                    break;
            }

            recordAGradePage.EnterApprenticeDetailsAndContinue(familyName, uln);

        }

        [Given(@"navigates to Assessment page")]
        public void GivenNavigatesToAssessmentPage()
        {
            SetLearnerDetails();

            recordAGradePage = loggedInHomePage.GoToRecordAGradePage();
        }

        [Given(@"the User is on the Apprenticeship achievement date page")]
        public void GivenTheUserIsOnTheApprenticeshipAchievementDatePage() => assessmentServiceStepsHelper.CertifyPrivatelyFundedApprentice(true);

        [When(@"the User enters the date before the Year 2017")]
        public void WhenTheUserEntersTheDateBeforeTheYear2017()
        {
            achievementDatePage = new AS_AchievementDatePage(_context);
            achievementDatePage.EnterAchievementGradeDateForPrivatelyFundedApprenticeAndContinue(2016);
        }

        [When(@"the User enters the future date")]
        public void WhenTheUserEntersTheFutureDate() => achievementDatePage.EnterAchievementGradeDateForPrivatelyFundedApprenticeAndContinue(ePAOAssesmentServiceDataHelper.CurrentYear + 1);

        [Then(@"(.*) is displayed in the Apprenticeship achievement date page")]
        public void ThenDateErrorIsDisplayedInTheApprenticeshipAchievementDatePage(string errorText) => Assert.AreEqual(achievementDatePage.GetDateErrorText(), errorText);

        [When(@"the User certifies an Apprentice as '(pass|fail)' and lands on Confirm Assessment Page")]
        public void WhenTheUserCertifiesAnApprenticeAsAndLandsOnConfirmAssessmentPage(string grade) 
            => checkAndSubmitAssessmentPage = CertifyApprentice(grade, SetLearnerDetails(), true);

        [Then(@"the Change links navigate to the respective pages")]
        public void ThenTheChangeLinksNavigateToTheRespectivePages()
        {
            checkAndSubmitAssessmentPage = checkAndSubmitAssessmentPage.ClickGradeChangeLink().ClickBackLink();
            checkAndSubmitAssessmentPage = checkAndSubmitAssessmentPage.ClickOptionChangeLink().ClickBackLink();
            checkAndSubmitAssessmentPage = checkAndSubmitAssessmentPage.ClickAchievementDateChangeLink().ClickBackLink();
            checkAndSubmitAssessmentPage = checkAndSubmitAssessmentPage.ClickNameChangeLink().ClickBackLink();
            checkAndSubmitAssessmentPage = checkAndSubmitAssessmentPage.ClickDepartmentChangeLink().ClickBackLink();
            checkAndSubmitAssessmentPage = checkAndSubmitAssessmentPage.ClickOrganisationChangeLink().ClickBackLink();
            checkAndSubmitAssessmentPage = checkAndSubmitAssessmentPage.ClickCertificateAddressChangeLink().ClickBackLink();
        }

        [When(@"the User navigates to the Completed assessments tab")]
        public void WhenTheUserNavigatesToTheCompletedAssessmentsTab() => loggedInHomePage.ClickCompletedAssessmentsLink();

        [Then(@"the User is able to view the history of the assessments")]
        public void ThenTheUserIsAbleToViewTheHistoryOfTheAssessments() => new AS_CompletedAssessmentsPage(_context).VerifyTableHeaders();

        [When(@"the User navigates to Organisation details page")]
        public void WhenTheUserNavigatesToOrganisationDetailsPage()
        {
            assessmentServiceStepsHelper.RemoveChangeOrgDetailsPermissionForTheUser(loggedInHomePage);

            loggedInHomePage.ClickOrganisationDetailsTopMenuLink();

            new AS_ChangeOrganisationDetailsPage(_context).ClickAccessButton();
        }

        [Then(@"the User is able to change the Registered details")]
        public void ThenTheUserIsAbleToChangeTheRegisteredDetails()
        {
            aS_OrganisationDetailsPage = new AS_OrganisationDetailsPage(_context);
            aS_OrganisationDetailsPage = assessmentServiceStepsHelper.ChangeContactName(aS_OrganisationDetailsPage);
            aS_OrganisationDetailsPage = assessmentServiceStepsHelper.ChangePhoneNumber(aS_OrganisationDetailsPage);
            aS_OrganisationDetailsPage = assessmentServiceStepsHelper.ChangeAddress(aS_OrganisationDetailsPage);
            aS_OrganisationDetailsPage = assessmentServiceStepsHelper.ChangeEmailAddress(aS_OrganisationDetailsPage);
            aS_OrganisationDetailsPage = assessmentServiceStepsHelper.ChangeWebsiteAddress(aS_OrganisationDetailsPage);
        }

        [When(@"the User initiates editing permissions of another user")]
        public void WhenTheUserInitiatesEditingPermissionsOfAnotherUser()
        {
            editUserPermissionsPage = loggedInHomePage.ClickManageUsersLink()
                .ClickPermissionsEditUserLink()
                .ClickEditUserPermissionLink();

            _permissionsSelected = editUserPermissionsPage.IsChangeOrganisationDetailsCheckBoxSelected();

            if (_permissionsSelected)
                userDetailsPage = editUserPermissionsPage.UnSelectAllPermissionCheckBoxes().ClickSaveButton();
            else
                userDetailsPage = editUserPermissionsPage.SelectAllPermissionCheckBoxes().ClickSaveButton();

            _permissionsSelected = _permissionsSelected ? false : true;
        }

        [Then(@"the User is able to change the permissions")]
        public void ThenTheUserIsAbleToChangeThePermissions()
        {
            if (_permissionsSelected)
            {
                Assert.IsTrue(userDetailsPage.IsViewDashboardPermissionDisplayed(), "default 'View dashboard' " + AddAssertResultText(true));
                Assert.IsTrue(userDetailsPage.IsChangeOrganisationDetailsPersmissionDisplayed(), "'Change organisation details' " + AddAssertResultText(true));
                Assert.IsTrue(userDetailsPage.IsPipelinePermissionDisplayed(), "'Pipeline' " + AddAssertResultText(true));
                Assert.IsTrue(userDetailsPage.IsCompletedAssessmentsPermissionDisplayed(), "'Completed assessments' " + AddAssertResultText(true));
                Assert.IsTrue(userDetailsPage.IsApplyForAStandardPermissionDisplayed(), "'Apply for a Standard' " + AddAssertResultText(true));
                Assert.IsTrue(userDetailsPage.IsManageUsersPermissionDisplayed(), "'Manage users' " + AddAssertResultText(true));
                Assert.IsTrue(userDetailsPage.IsRecordGradesPermissionDisplayed(), "'Record grades and issue certificates' " + AddAssertResultText(true));
            }
            else
            {
                Assert.IsTrue(userDetailsPage.IsViewDashboardPermissionDisplayed(), "default 'View dashboard' " + AddAssertResultText(true));
                Assert.IsFalse(userDetailsPage.IsChangeOrganisationDetailsPersmissionDisplayed(), "'Change organisation details' " + AddAssertResultText(false));
                Assert.IsFalse(userDetailsPage.IsPipelinePermissionDisplayed(), "'Pipeline' permission is displayed in 'User details' " + AddAssertResultText(false));
                Assert.IsFalse(userDetailsPage.IsCompletedAssessmentsPermissionDisplayed(), "'Completed assessments' " + AddAssertResultText(false));
                Assert.IsFalse(userDetailsPage.IsApplyForAStandardPermissionDisplayed(), "'Apply for a Standard' " + AddAssertResultText(false));
                Assert.IsFalse(userDetailsPage.IsManageUsersPermissionDisplayed(), "'Manage users' " + AddAssertResultText(false));
                Assert.IsFalse(userDetailsPage.IsRecordGradesPermissionDisplayed(), "'Record grades and issue certificates' " + AddAssertResultText(false));
            }
        }

        private string AddAssertResultText(bool condition) => condition ? "permission selected is not shown in 'User details' page" : "permission selected is not shown in 'User details' page";

        [When(@"the User initiates inviting a new user journey")]
        public void WhenTheUserInitiatesInvitingANewUserJourney() => _newUserEmailId = assessmentServiceStepsHelper.InviteAUser(loggedInHomePage);
    
        [Then(@"a new User is invited and able to initiate inviting another user")]
        public void ThenANewUserIsInvitedAndAbleToInitiateInvitingAnotherUser() => new AS_UserInvitedPage(_context).ClickInviteSomeoneElseLink();

        [Then(@"the User can remove newly invited user")]
        public void ThenTheUserCanRemoveNewlyInvitedUser()
        {
            loggedInHomePage.ClickHomeTopMenuLink()
                .ClickManageUsersLink()
                .ClickOnNewlyAddedUserLink(_newUserEmailId)
                .ClicRemoveThisUserLinkInUserDetailPage()
                .ClickRemoveUserButtonInRemoveUserPage();
        }

        [Then(@"the user can apply to assess a standard")]
        public void ThenTheUserCanApplyToAssessAStandard() => applyStepsHelper.ApplyForAStandard(loggedInHomePage.ApplyToAssessStandard().SelectApplication().StartApplication(), ePAOApplyStandardData.ApplyStandardName);

        private AS_AssessmentRecordedPage RecordAGrade(string grade, LeanerCriteria leanerCriteria, bool deleteCertificate) => CertifyApprentice(grade, leanerCriteria, deleteCertificate).ClickContinueInCheckAndSubmitAssessmentPage();

        private AS_CheckAndSubmitAssessmentPage CertifyApprentice(string grade, LeanerCriteria leanerCriteria, bool deleteCertificate) => assessmentServiceStepsHelper.CertifyApprentice(grade, leanerCriteria, deleteCertificate);

        private LeanerCriteria SetLearnerDetails()
        {
            var leanerCriteria = GetLearnerCriteria();

            var leanerDetails = ePAOAdminCASqlDataHelper.GetCATestData(ePAOAdminDataHelper.LoginEmailAddress, leanerCriteria);

            if (string.IsNullOrEmpty(leanerDetails[0])) Assert.Fail("No test data found in the db");

            ePAOAdminDataHelper.LearnerUln = leanerDetails[0];
            ePAOAdminDataHelper.StandardCode = leanerDetails[1];
            ePAOAdminDataHelper.StandardsName = leanerDetails[2];
            ePAOAdminDataHelper.FirstName = leanerDetails[3];
            ePAOAdminDataHelper.LastName = leanerDetails[4];

            objectContext.SetLearnerDetails(leanerDetails[0], leanerDetails[1], leanerDetails[2], leanerDetails[3], leanerDetails[4]);

            return leanerCriteria;
        }

        private LeanerCriteria GetLearnerCriteria() => _context.Get<LeanerCriteria>();
    }
}