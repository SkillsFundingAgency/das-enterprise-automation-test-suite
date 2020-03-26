using NUnit.Framework;
using SFA.DAS.EPAO.UITests.Project.Helpers;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.ManageUsers;
using SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService.OrganisationDetails;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AssessmentServiceSteps
    {
        private readonly ScenarioContext _context;
        private readonly AssessmentServiceStepsHelper _stepsHelper;
        private readonly EPAOConfig _ePAOConfig;
        private readonly EPAODataHelper _dataHelper;
        private AS_RecordAGradePage _recordAGradePage;
        private AS_AchievementDatePage _achievementDatePage;
        private AS_CheckAndSubmitAssessmentPage _checkAndSubmitAssessmentPage;
        private AS_LoggedInHomePage _loggedInHomePage;
        private AS_OrganisationDetailsPage _organisationDetailsPage;
        private AS_EditUserPermissionsPage _editUserPermissionsPage;
        private AS_UserDetailsPage _userDetailsPage;
        private readonly EPAOSqlDataHelper _ePAOSqlDataHelper;
        private bool _permissionsSelected;
        private string _newUserEmailId;

        public AssessmentServiceSteps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new AssessmentServiceStepsHelper(_context);
            _ePAOConfig = context.GetEPAOConfig<EPAOConfig>();
            _dataHelper = context.Get<EPAODataHelper>();
            _ePAOSqlDataHelper = context.Get<EPAOSqlDataHelper>();
        }

        [Given(@"the (Assessor User|Standard Apply User|Manage User|Apply User) is logged into Assessment Service Application")]
        [When(@"the (Assessor User|Standard Apply User|Manage User|Apply User) is logged into Assessment Service Application")]
        public void GivenTheUserIsLoggedIntoAssessmentServiceApplication(string user)
        {
            _stepsHelper.LaunchAssessmentServiceApplication();

            if (user.Equals("Assessor User"))
                _loggedInHomePage = _stepsHelper.LoginToAssessmentServiceApplication(_context.GetUser<EPAOAssessorUser>());            
            else if (user.Equals("Manage User"))
                _loggedInHomePage = _stepsHelper.LoginToAssessmentServiceApplication(_context.GetUser<EPAOManageUser>());
            else if (user.Equals("Standard Apply User"))
            {
                //_ePAOSqlDataHelper.DeleteStandardPreambleApplicication(_dataHelper.Standards, _dataHelper.StandardAssessorOrganisationEpaoId);
                _loggedInHomePage = _stepsHelper.LoginToAssessmentServiceApplication(_context.GetUser<EPAOStandardApplyUser>());
            }
            else if (user.Equals("Apply User"))
            {
                _ePAOSqlDataHelper.ResetApplyUser(_context.GetUser<EPAOApplyUser>().Username);
                new AS_LandingPage(_context).ClickStartButton().SignInAsApplyUser();
            }
        }

        [When(@"the User goes through certifying an Apprentice as '(.*)' who has enrolled for '(.*)' standard")]
        public void WhenTheUserGoesThroughCertifyingAnApprenticeAsWhoHasEnrolledForStandard(string grade, string enrolledStandard)
        {
            _stepsHelper.CertifyApprentice(grade, enrolledStandard);
            new AS_CheckAndSubmitAssessmentPage(_context).ClickContinueInCheckAndSubmitAssessmentPage();
        }

        [When(@"the User goes through certifying a Privately funded Apprentice")]
        public void WhenTheUserGoesThroughCertifyingAPrivatelyFundedApprentice() => _stepsHelper.CertifyPrivatelyFundedApprentice();

        [Then(@"the Assessment is recorded and the User is able to navigate back to certifying another Apprentice")]
        public void ThenTheAssessmentIsRecordedAndTheUserIsAbleToNavigateBackToCertifyingAnotherApprentice() => new AS_AssessmentRecordedPage(_context).ClickRecordAnotherGradeLinkInAssessmentRecordedPage();

        [When(@"the User goes through certifying an already assessed Apprentice")]
        public void WhenTheUserGoesThroughCertifyingAnAlreadyAssessedApprentice()
        {
            new AS_LoggedInHomePage(_context).ClickOnRecordAGrade();
            _recordAGradePage = new AS_RecordAGradePage(_context);
            _recordAGradePage.EnterApprentcieDetailsAndContinue(_ePAOConfig.EPAOAlreadyAssessedApprenticeName, _ePAOConfig.EPAOAlreadyAssessedApprenticeUln);
        }

        [Then(@"'(.*)' message is displayed")]
        public void ThenErrorMessageIsDisplayed(string errorMessage) => Assert.AreEqual(_recordAGradePage.GetPageTitle(), errorMessage);

        [Then(@"the '(.*)' is displayed")]
        public void ThenErrorIsDisplayed(string errorMessage)
        {
            switch (errorMessage)
            {
                case "Family name and ULN missing error":
                    Assert.IsTrue(_recordAGradePage.VerifyFamilyNameMissingErrorText(), "FamilyName missing Error Text is incorrect");
                    Assert.IsTrue(_recordAGradePage.VerifyULNMissingErrorText(), "ULN missing Error Text is incorrect");
                    break;
                case "Family name missing error":
                    Assert.IsTrue(_recordAGradePage.VerifyFamilyNameMissingErrorText(), "FamilyName missing Error Text is incorrect");
                    break;
                case "ULN missing error":
                    Assert.IsTrue(_recordAGradePage.VerifyULNMissingErrorText(), "ULN missing Error Text is incorrect");
                    break;
                case "ULN validation error":
                    Assert.IsTrue(_recordAGradePage.VerifyInvalidUlnErrorText(), "ULN validation Error Text is incorrect");
                    break;
            }
        }

        [When(@"the User clicks on the continue button '(.*)'")]
        public void WhenTheUserClicksOnTheContinueButton(string scenario)
        {
            _recordAGradePage = new AS_RecordAGradePage(_context);

            switch (scenario)
            {
                case "with out entering Any details":
                    _recordAGradePage.EnterApprentcieDetailsAndContinue("", "");
                    break;
                case "by entering valid Family name and blank ULN":
                    _recordAGradePage.EnterApprentcieDetailsAndContinue(_ePAOConfig.EPAOApprenticeNameWithSingleStandard, "");
                    break;
                case "by entering blank Family name and Valid ULN":
                    _recordAGradePage.EnterApprentcieDetailsAndContinue("", _ePAOConfig.EPAOApprenticeUlnWithSingleStandard);
                    break;
                case "by entering valid Family name but ULN less than 10 digits":
                    _recordAGradePage.EnterApprentcieDetailsAndContinue(_ePAOConfig.EPAOApprenticeNameWithSingleStandard, _dataHelper.GetRandomNumber(9));
                    break;
                case "by entering valid Family name and Invalid ULN":
                    _recordAGradePage.EnterApprentcieDetailsAndContinue(_ePAOConfig.EPAOApprenticeNameWithSingleStandard, _dataHelper.GetRandomNumber(11));
                    break;
            }
        }

        [Given(@"navigates to Assessment page")]
        public void GivenNavigatesToAssessmentPage() => new AS_LoggedInHomePage(_context).ClickOnRecordAGrade();

        [Given(@"the User is on the Apprenticeship achievement date page")]
        public void GivenTheUserIsOnTheApprenticeshipAchievementDatePage() => _stepsHelper.CertifyPrivatelyFundedApprentice(true);

        [When(@"the User enters the date before the Year 2017")]
        public void WhenTheUserEntersTheDateBeforeTheYear2017()
        {
            _achievementDatePage = new AS_AchievementDatePage(_context);
            _achievementDatePage.EnterAchievementGradeDateForPrivatelyFundedApprenticeAndContinue(2016);
        }

        [When(@"the User enters the future date")]
        public void WhenTheUserEntersTheFutureDate() => _achievementDatePage.EnterAchievementGradeDateForPrivatelyFundedApprenticeAndContinue(_dataHelper.CurrentYear + 1);

        [Then(@"(.*) is displayed in the Apprenticeship achievement date page")]
        public void ThenDateErrorIsDisplayedInTheApprenticeshipAchievementDatePage(string errorText) => Assert.AreEqual(_achievementDatePage.GetDateErrorText(), errorText);

        [When(@"the (.*) is on the Confirm Assessment Page")]
        public void WhenTheUserIsOnTheConfirmAssessmentPage(string user)
        {
            GivenTheUserIsLoggedIntoAssessmentServiceApplication(user);
            _stepsHelper.CertifyApprentice("Passed", "additional learning option");
        }

        [Then(@"the Change links navigate to the respective pages")]
        public void ThenTheChangeLinksNavigateToTheRespectivePages()
        {
            _checkAndSubmitAssessmentPage = new AS_CheckAndSubmitAssessmentPage(_context);

            _checkAndSubmitAssessmentPage = _checkAndSubmitAssessmentPage.ClickGradeChangeLink().ClickBackLink();
            _checkAndSubmitAssessmentPage = _checkAndSubmitAssessmentPage.ClickOptionChangeLink().ClickBackLink();
            _checkAndSubmitAssessmentPage = _checkAndSubmitAssessmentPage.ClickAchievementDateChangeLink().ClickBackLink();
            _checkAndSubmitAssessmentPage = _checkAndSubmitAssessmentPage.ClickNameChangeLink().ClickBackLink();
            _checkAndSubmitAssessmentPage = _checkAndSubmitAssessmentPage.ClickDepartmentChangeLink().ClickBackLink();
            _checkAndSubmitAssessmentPage = _checkAndSubmitAssessmentPage.ClickOrganisationChangeLink().ClickBackLink();
            _checkAndSubmitAssessmentPage = _checkAndSubmitAssessmentPage.ClickCertificateAddressChangeLink().ClickBackLink();
        }

        [When(@"the User navigates to the Completed assessments tab")]
        public void WhenTheUserNavigatesToTheCompletedAssessmentsTab() => _loggedInHomePage.ClickCompletedAssessmentsLink();

        [Then(@"the User is able to view the history of the assessments")]
        public void ThenTheUserIsAbleToViewTheHistoryOfTheAssessments() => new AS_CompletedAssessmentsPage(_context).VerifyTableHeaders();

        [When(@"the User navigates to Organisation details page")]
        public void WhenTheUserNavigatesToOrganisationDetailsPage()
        {
            _stepsHelper.RemoveChangeOrgDetailsPermissionForTheUser();
            _loggedInHomePage.ClickOrganisationDetailsTopMenuLink();
            new AS_ChangeOrganisationDetailsPage(_context).ClickAccessButton();
        }

        [Then(@"the User is able to change the Registered details")]
        public void ThenTheUserIsAbleToChangeTheRegisteredDetails()
        {
            _organisationDetailsPage = new AS_OrganisationDetailsPage(_context);

            _organisationDetailsPage = _stepsHelper.ChangeContactName(_organisationDetailsPage);
            _organisationDetailsPage = _stepsHelper.ChangePhoneNumber(_organisationDetailsPage);
            _organisationDetailsPage = _stepsHelper.ChangeAddress(_organisationDetailsPage);
            _organisationDetailsPage = _stepsHelper.ChangeEmailAddress(_organisationDetailsPage);
            _organisationDetailsPage = _stepsHelper.ChangeWebsiteAddress(_organisationDetailsPage);
        }

        [When(@"the User initiates editing permissions of another user")]
        public void WhenTheUserInitiatesEditingPermissionsOfAnotherUser()
        {
            _editUserPermissionsPage = _loggedInHomePage.ClickManageUsersLink()
                .ClickPermissionsEditUserLink()
                .ClickEditUserPermissionLink();

            _permissionsSelected = _editUserPermissionsPage.IsChangeOrganisationDetailsCheckBoxSelected();

            if (_permissionsSelected)
                _userDetailsPage = _editUserPermissionsPage.UnSelectAllPermissionCheckBoxes().ClickSaveButton();
            else
                _userDetailsPage = _editUserPermissionsPage.SelectAllPermissionCheckBoxes().ClickSaveButton();

            _permissionsSelected = _permissionsSelected ? false : true;
        }

        [Then(@"the User is able to change the permissions")]
        public void ThenTheUserIsAbleToChangeThePermissions()
        {
            if (_permissionsSelected)
            {
                Assert.IsTrue(_userDetailsPage.IsViewDashboardPermissionDisplayed(), "default 'View dashboard' " + AddAssertResultText(true));
                Assert.IsTrue(_userDetailsPage.IsChangeOrganisationDetailsPersmissionDisplayed(), "'Change organisation details' " + AddAssertResultText(true));
                Assert.IsTrue(_userDetailsPage.IsPipelinePermissionDisplayed(), "'Pipeline' " + AddAssertResultText(true));
                Assert.IsTrue(_userDetailsPage.IsCompletedAssessmentsPermissionDisplayed(), "'Completed assessments' " + AddAssertResultText(true));
                Assert.IsTrue(_userDetailsPage.IsApplyForAStandardPermissionDisplayed(), "'Apply for a Standard' " + AddAssertResultText(true));
                Assert.IsTrue(_userDetailsPage.IsManageUsersPermissionDisplayed(), "'Manage users' " + AddAssertResultText(true));
                Assert.IsTrue(_userDetailsPage.IsRecordGradesPermissionDisplayed(), "'Record grades and issue certificates' " + AddAssertResultText(true));
            }
            else
            {
                Assert.IsTrue(_userDetailsPage.IsViewDashboardPermissionDisplayed(), "default 'View dashboard' " + AddAssertResultText(true));
                Assert.IsFalse(_userDetailsPage.IsChangeOrganisationDetailsPersmissionDisplayed(), "'Change organisation details' " + AddAssertResultText(false));
                Assert.IsFalse(_userDetailsPage.IsPipelinePermissionDisplayed(), "'Pipeline' permission is displayed in 'User details' " + AddAssertResultText(false));
                Assert.IsFalse(_userDetailsPage.IsCompletedAssessmentsPermissionDisplayed(), "'Completed assessments' " + AddAssertResultText(false));
                Assert.IsFalse(_userDetailsPage.IsApplyForAStandardPermissionDisplayed(), "'Apply for a Standard' " + AddAssertResultText(false));
                Assert.IsFalse(_userDetailsPage.IsManageUsersPermissionDisplayed(), "'Manage users' " + AddAssertResultText(false));
                Assert.IsFalse(_userDetailsPage.IsRecordGradesPermissionDisplayed(), "'Record grades and issue certificates' " + AddAssertResultText(false));
            }
        }

        private string AddAssertResultText(bool condition) => condition ? "permission selected is not shown in 'User details' page" : "permission selected is not shown in 'User details' page";

        [When(@"the User initiates inviting a new user journey")]
        public void WhenTheUserInitiatesInvitingANewUserJourney() => _newUserEmailId = _stepsHelper.InviteAUser(_loggedInHomePage, _dataHelper);
    
        [Then(@"a new User is invited and able to initiate inviting another user")]
        public void ThenANewUserIsInvitedAndAbleToInitiateInvitingAnotherUser() => new AS_UserInvitedPage(_context).ClickInviteSomeoneElseLink();

        [Then(@"the User can remove newly invited user")]
        public void ThenTheUserCanRemoveNewlyInvitedUser()
        {
            _loggedInHomePage.ClickHomeTopMenuLink()
                .ClickManageUsersLink()
                .ClickOnNewlyAddedUserLink(_newUserEmailId)
                .ClicRemoveThisUserLinkInUserDetailPage()
                .ClickRemoveUserButtonInRemoveUserPage();
        }

        [Then(@"the user can apply to assess a standard")]
        public void ThenTheUserCanApplyToAssessAStandard()
        {
           var applyToStandard = _loggedInHomePage.ApplyToAssessStandard()
                .SelectApplication()
                .StartApplication()
                .Start()
                .EnterStandardName()
                .Apply()
                .ConfirmAndApply()
                .GoToApplyToStandard();

            applyToStandard = applyToStandard.AccessYourPolicies_01()
                .EnterRegNumber()
                .UploadAuditPolicy()
                .UploadPublicLiabilityInsurance()
                .UploadProfessionalIndemnityInsurance()
                .UploadEmployersLiabilityInsurance()
                .UploadSafeguardingPolicy()
                .UploadPreventAgendaPolicy()
                .UploadConflictOfinterestPolicy()
                .UploadMonitoringProcedure()
                .UploadModerationProcesses()
                .UploadComplaintsPolicy()
                .UploadFairAccess()
                .UploadConsistencyAssurance()
                .EnterImproveTheQuality()
                .EnterEngagement()
                .EnterMembershipDetails()
                .EnterHowManyAssessors()
                .EnterHowManyEndPointAssessment()
                .EnterVolume()
                .EnterHowRecruitAndTrainAssessors()
                .EnterExperience()
                .EnterOccupationalExpertise()
                .EnterDeliverEndPoint()
                .EnterIntendToOutsource()
                .EnterEngageWithEmployers()
                .EnterManageAnyPotentialConflict()
                .ChooseLocation()
                .EnterDayToStart()
                .EnterAssessmentPlan()
                .EnterReviewAndMaintainPlan()
                .EnterSecureITInfrastructurePlan()
                .EnterAssessmentAdministration()
                .EnterAssessmentProduct()
                .EnterAssessmentContent()
                .EnterCollationOutcome()
                .EnterAssessmentResutls()
                .EnterWebAddress();

            applyToStandard.ReturnToApplicationOverview().Submit();
        }
    }
}