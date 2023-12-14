namespace SFA.DAS.EPAO.UITests.Project.Tests.StepDefinitions;

[Binding]
public class AssessmentServiceSteps : EPAOBaseSteps
{
    private readonly ScenarioContext _context;
    private bool _permissionsSelected;
    private string _newUserEmailId;

    private AS_AssessmentRecordedPage assessmentRecordedPage;

    public AssessmentServiceSteps(ScenarioContext context) : base(context) => _context = context;

    [Given(@"the (Assessor User|Delete Assessor User|Standard Apply User|Manage User|EPAO Withdrawal User) is logged into Assessment Service Application")]
    public void GivenTheUserIsLoggedIn(Func<AS_LoggedInHomePage> userloginFunc) => loggedInHomePage = userloginFunc?.Invoke();

    [StepArgumentTransformation(@"(Assessor User|Delete Assessor User|Standard Apply User|Manage User|EPAO Withdrawal User)")]
    public Func<AS_LoggedInHomePage> GetProviderUserRole(string userRole)
    {
        return true switch
        {
            bool _ when (userRole == "Assessor User") => () => ePAOHomePageHelper.LoginInAsNonApplyUser(_context.GetUser<EPAOAssessorUser>()),
            bool _ when (userRole == "Delete Assessor User") => () => ePAOHomePageHelper.LoginInAsNonApplyUser(_context.GetUser<EPAODeleteAssessorUser>()),
            bool _ when (userRole == "Manage User") => () => ePAOHomePageHelper.LoginInAsNonApplyUser(_context.GetUser<EPAOManageUser>()),
            bool _ when (userRole == "Standard Apply User") => () => ePAOHomePageHelper.LoginInAsStandardApplyUser(_context.GetUser<EPAOStandardApplyUser>(), EPAOApplyStandardDataHelper.ApplyStandardCode, EPAOApplyStandardDataHelper.StandardAssessorOrganisationEpaoId),
            bool _ when (userRole == "EPAO Withdrawal User") => () => ePAOHomePageHelper.LoginInAsNonApplyUser(_context.GetUser<EPAOWithdrawalUser>()),
            _ => null,
        };
    }

    [When(@"the User certifies an Apprentice as '(pass|fail)' using '(employer|apprentice)' route")]
    public void WhenTheUserCertifiesAnApprenticeAsWhoHasEnrolledForStandard(string grade, string route) => RecordAGrade(grade, route, SetLearnerDetails(), true); 

    [When(@"the User provides the matching uln and invalid Family name for the existing certificate")]
    public void WhenTheUserProvidesTheMatchingUlnAndInvalidFamilyNameForTheExistingCertificate() => loggedInHomePage.GoToRecordAGradePage().EnterApprenticeDetailsForExistingCertificateAndContinue();

    [When(@"the User certifies same Apprentice as (pass|PassWithExcellence) using '(employer|apprentice)' route")]
    public void WhenTheUserCertifiesSameApprenticeAsPass(string grade, string route) => RecordAGrade(grade, route, GetLearnerCriteria(), false);

    [Then(@"the Assessment is recorded as '(pass|fail|pass with excellence)'")]
    public void ThenTheAssessmentIsRecordedAs(string grade) => assessmentServiceStepsHelper.VerifyApprenticeGrade(grade, GetLearnerCriteria());

    [Then(@"the Admin user can delete a certificate that has been incorrectly submitted")]
    public void ThenTheAdminUserCanDeleteACertificateThatHasBeenIncorrectlySubmitted() => assessmentServiceStepsHelper.DeleteCertificate(ePAOHomePageHelper.LoginToEpaoAdminHomePage(true));

    [Then(@"the User can navigates to record another grade")]
    public void ThenTheUserCanNavigatesToRecordAnotherGrade() => assessmentRecordedPage.ClickRecordAnotherGradeLink();

    [Given(@"the User should be able to Opt In for the new version of the Standard")]
    public void GivenTheUserShouldBeAbleToOptInForTheNewVersionOfTheStandard() =>
        loggedInHomePage.ApprovedStandardAndVersions().ClickOnAssociateProjectManagerLink().ClickOnAssociateProjectManagerOptInLinkForVersion1_1().ConfirmOptIn();

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
        string familyName = ePAOAdminDataHelper.FamilyName, uln = ePAOAdminDataHelper.LearnerUln;

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
                uln = EPAODataHelper.GetRandomNumber(9);
                break;
            case "by entering valid Family name and Invalid ULN":
                uln = EPAODataHelper.GetRandomNumber(11);
                break;
        }

        recordAGradePage.EnterApprenticeDetailsAndContinue(familyName, uln);
    }

    [Given(@"navigates to Assessment page")]
    public void GivenNavigatesToAssessmentPage() { SetLearnerDetails(); recordAGradePage = loggedInHomePage.GoToRecordAGradePage(); }

    [Given(@"the User certifies an Apprentice as '(pass|fail)' with '(employer|apprentice)' route and records a grade")]
    public void WhenTheUserCertifiesAnApprenticeAndRecordsAGrade(string grade, string route)
        => CertifyApprentice(grade, route, SetLearnerDetails(), true).ClickContinueInCheckAndSubmitAssessmentPage();

    [When(@"the User certifies an Apprentice as '(pass|fail)' with '(employer|apprentice)' route and lands on Confirm Assessment Page")]
    public void WhenTheUserCertifiesAnApprenticeAndLandsOnConfirmAssessmentPage(string grade, string route) 
        => checkAndSubmitAssessmentPage = CertifyApprentice(grade, route, SetLearnerDetails(), true);

    [Then(@"the Change links navigate to the respective pages")]
    public void ThenTheChangeLinksNavigateToTheRespectivePages()
    {
        CheckCommonLinks();
        checkAndSubmitAssessmentPage = checkAndSubmitAssessmentPage.ClickCertificateAddressChangeLinkvForApprenticeJourney().ClickBackLink();
    }

    [Then(@"the Change links navigate to employer pages")]
    public void ThenTheChangeLinksNavigateToTheEmployerPages()
    {
        CheckCommonLinks();
        checkAndSubmitAssessmentPage = checkAndSubmitAssessmentPage.ClickDepartmentChangeLinkForEmployerJourney().ClickBackLink();
        checkAndSubmitAssessmentPage = checkAndSubmitAssessmentPage.ClickCertificateAddressChangeLinkForEmployerJourney().ClickBackLink();
    }

    [When(@"the User navigates to the Completed assessments tab")]
    public void WhenTheUserNavigatesToTheCompletedAssessmentsTab() => loggedInHomePage.ClickCompletedAssessmentsLink();

    [Then(@"the User is able to view the history of the assessments")]
    public void ThenTheUserIsAbleToViewTheHistoryOfTheAssessments() => new AS_CompletedAssessmentsPage(_context).VerifyTableHeaders();

    [When(@"the User navigates to Organisation details page")]
    public void WhenTheUserNavigatesToOrganisationDetailsPage()
    {
        AssessmentServiceStepsHelper.RemoveChangeOrgDetailsPermissionForTheUser(loggedInHomePage);

        loggedInHomePage.ClickOrganisationDetailsTopMenuLink();

        new AS_ChangeOrganisationDetailsPage(_context).ClickAccessButton();
    }

    [Then(@"the User is able to change the Registered details")]
    public void ThenTheUserIsAbleToChangeTheRegisteredDetails()
    {
        aS_OrganisationDetailsPage = new AS_OrganisationDetailsPage(_context);
        aS_OrganisationDetailsPage = AssessmentServiceStepsHelper.ChangeContactName(aS_OrganisationDetailsPage);
        aS_OrganisationDetailsPage = AssessmentServiceStepsHelper.ChangePhoneNumber(aS_OrganisationDetailsPage);
        aS_OrganisationDetailsPage = AssessmentServiceStepsHelper.ChangeAddress(aS_OrganisationDetailsPage);
        aS_OrganisationDetailsPage = AssessmentServiceStepsHelper.ChangeEmailAddress(aS_OrganisationDetailsPage);
        aS_OrganisationDetailsPage = AssessmentServiceStepsHelper.ChangeWebsiteAddress(aS_OrganisationDetailsPage);
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

        _permissionsSelected = !_permissionsSelected;
    }

    [Then(@"the User is able to change the permissions")]
    public void ThenTheUserIsAbleToChangeThePermissions() => 
        Assert.Multiple(() => 
        { 
            IsViewDashboardPermissionDisplayed(true); 
            IsChangeOrganisationDetailsPersmissionDisplayed(_permissionsSelected); 
            IsPipelinePermissionDisplayed(_permissionsSelected); 
            IsCompletedAssessmentsPermissionDisplayed(_permissionsSelected);
            IsManageStandardsPermissionDisplayed(_permissionsSelected);
            IsManageUsersPermissionDisplayed(_permissionsSelected);
            IsRecordGradesPermissionDisplayed(_permissionsSelected);
        });


    [When(@"the User initiates inviting a new user journey")]
    public void WhenTheUserInitiatesInvitingANewUserJourney() => _newUserEmailId = AssessmentServiceStepsHelper.InviteAUser(loggedInHomePage);

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
    public void ThenTheUserCanApplyToAssessAStandard() => 
        applyStepsHelper.ApplyForAStandard(loggedInHomePage.ApplyToAssessStandard().SelectApplication().StartApplication(), EPAOApplyStandardDataHelper.ApplyStandardName);

    [Given(@"the certificate is printed")]
    public void GivenTheCertificateIsSentToPrinter() => ePAOAdminSqlDataHelper.UpdateCertificateToPrinted(ePAOAdminDataHelper.LearnerUln);

    private void CheckCommonLinks()
    {
        checkAndSubmitAssessmentPage = checkAndSubmitAssessmentPage.ClickGradeChangeLink().ClickBackLink();
        checkAndSubmitAssessmentPage = checkAndSubmitAssessmentPage.ClickOptionChangeLink().ClickBackLink();
        checkAndSubmitAssessmentPage = checkAndSubmitAssessmentPage.ClickAchievementDateChangeLink().ClickBackLink();
        checkAndSubmitAssessmentPage = checkAndSubmitAssessmentPage.ClickCertificateReceiverLink().ClickBackLink();
    }

    private AS_AssessmentRecordedPage RecordAGrade(string grade, string route, LearnerCriteria learnerCriteria, bool deleteCertificate) => 
        assessmentRecordedPage = CertifyApprentice(grade, route, learnerCriteria, deleteCertificate).ClickContinueInCheckAndSubmitAssessmentPage();

    private AS_CheckAndSubmitAssessmentPage CertifyApprentice(string grade, string route, LearnerCriteria learnerCriteria, bool deleteExistingCertificate) => 
        assessmentServiceStepsHelper.CertifyApprentice(grade, route, learnerCriteria, deleteExistingCertificate);

    private LearnerCriteria SetLearnerDetails() => SetLearnerDetails(() => ePAOAdminCASqlDataHelper.GetCATestData(ePAOAdminDataHelper.LoginEmailAddress, GetLearnerCriteria()));

    private LearnerCriteria SetLearnerDetails(Func<List<string>> func)
    {
        var learnerDetails = func();

        if (string.IsNullOrEmpty(learnerDetails[0])) Assert.Fail("No test data found in the db");

        ePAOAdminDataHelper.LearnerUln = learnerDetails[0];
        ePAOAdminDataHelper.StandardCode = learnerDetails[1];
        ePAOAdminDataHelper.StandardsName = learnerDetails[2];
        ePAOAdminDataHelper.GivenNames = learnerDetails[3];
        ePAOAdminDataHelper.FamilyName = learnerDetails[4];

        objectContext.SetLearnerDetails(learnerDetails[0], learnerDetails[1], learnerDetails[2], learnerDetails[3], learnerDetails[4]);

        return GetLearnerCriteria();
    }

    private LearnerCriteria GetLearnerCriteria() => _context.Get<LearnerCriteria>();

    private void IsViewDashboardPermissionDisplayed(bool expected) => Assert.AreEqual(expected, userDetailsPage.IsViewDashboardPermissionDisplayed(), "default 'View dashboard' " + AddAssertResultText(expected));
    private void IsChangeOrganisationDetailsPersmissionDisplayed(bool expected) => Assert.AreEqual(expected, userDetailsPage.IsChangeOrganisationDetailsPersmissionDisplayed(), "'Change organisation details' " + AddAssertResultText(expected));
    private void IsPipelinePermissionDisplayed(bool expected) => Assert.AreEqual(expected, userDetailsPage.IsPipelinePermissionDisplayed(), "'Pipeline' " + AddAssertResultText(expected));
    private void IsCompletedAssessmentsPermissionDisplayed(bool expected) => Assert.AreEqual(expected, userDetailsPage.IsCompletedAssessmentsPermissionDisplayed(), "'Completed assessments' " + AddAssertResultText(expected));
    private void IsManageStandardsPermissionDisplayed(bool expected) => Assert.AreEqual(expected, userDetailsPage.IsManageStandardsPermissionDisplayed(), "'Manage standards' " + AddAssertResultText(expected));
    private void IsManageUsersPermissionDisplayed(bool expected) => Assert.AreEqual(expected, userDetailsPage.IsManageUsersPermissionDisplayed(), "'Manage users' " + AddAssertResultText(expected));
    private void IsRecordGradesPermissionDisplayed(bool expected) => Assert.AreEqual(expected, userDetailsPage.IsRecordGradesPermissionDisplayed(), "'Record grades and issue certificates' " + AddAssertResultText(expected));

    private string AddAssertResultText(bool condition) => condition ? "permission selected is not shown in 'User details' page" : "permission selected is shown in 'User details' page";
}