
namespace SFA.DAS.FAAV2.UITests.Project.Helpers;

public class FAAStepsHelper(ScenarioContext context)
{
    private readonly TabHelper _tabHelper = context.Get<TabHelper>();
    private readonly FAADataHelper _faaDataHelper = context.Get<FAADataHelper>();
    private readonly ObjectContext _objectContext = context.Get<ObjectContext>();
    private readonly string _faaBaseUrl = UrlConfig.FAAV2_BaseUrl;

    public FAASearchApprenticeLandingPage GoToFAAHomePage()
    {
        _tabHelper.OpenInNewTab(_faaBaseUrl);

        new FAASignedOutLandingpage(context).GoToSignInPage().SubmitValidUserDetails(context.GetUser<FAAApplyUser>()).Continue();

        return new FAASearchApprenticeLandingPage(context);
    }

    //public string GetApplicationStatus()
    //{
    //    return OpenFAAHomePageinNewtab()
    //        .FindAnApprenticeship()
    //        .SearchByReferenceNumber()
    //        .View()
    //        .ApplicationStatus();
    //}

    //public FAA_ApprenticeSearchPage FindAnApprenticeship() => GoToFAAHomePage().FindAnApprenticeship();

    //public FAA_CreateAnAccountPage StartFAAAccountCreation()
    //{
    //    _tabHelper.GoToUrl(_faaBaseUrl);

    //    return new FAA_Indexpage(context)
    //        .GoToSignInPage()
    //        .ClickCreateAnAccountLink();
    //}

    //public static void CreateFAAAccount(FAA_CreateAnAccountPage accountCreationPage)
    //{
    //    accountCreationPage.CreateAccount()
    //        .EnterActivationCode()
    //        .ClickSaveAndContinue()
    //        .VerifyPhoneNumberVerificationText()
    //        .EnterVerificationCode()
    //        .VerifySuccessfulVerificationText();
    //}

    //public void CreateFAAAccountWithNoActivation(FAA_CreateAnAccountPage accountCreationPage)
    //{
    //    var (username, password, _, _) = _objectContext.GetFAALogin();
    //    accountCreationPage.CreateAccount()
    //        .ClickSignOut()
    //        .SubmitUnactivatedLoginDetails(username, password);
    //}

    //public void WithdrawVacancy()
    //{
    //    SearchByReferenceNumber()
    //        .View()
    //        .Withdraw()
    //        .YesWithdraw();
    //}

    //public void DismissNotification(string status)
    //{
    //    switch (status)
    //    {
    //        case "Successful":
    //            GoToFAAHomePage().DismissSuccessfulNotification();
    //            break;

    //        case "Unsccessful":
    //            GoToFAAHomePage().DismissUnsuccessfulNotification().ReadFeedback().VerifyReadFeedbackText();
    //            break;
    //    }
    //}

    //public void ApplyForAVacancy(string qualificationdetails, string workExperience, string trainingCourse, bool isSearchByCategory = false)
    //{
    //    var applicationFormPage = isSearchByCategory ? SearchByCategory().Apply() : SearchByReferenceNumber().Apply();

    //    if (_objectContext.IsApprenticeshipVacancyType())
    //    {
    //        applicationFormPage.EnterEducation();
    //        applicationFormPage.EnterStartedYear();
    //        applicationFormPage.EnterFinishedYear();
    //        applicationFormPage.EnterQualificationdetails(qualificationdetails);
    //        applicationFormPage.EnterWorkExperience(workExperience);
    //        applicationFormPage.EnterTrainingCourse(trainingCourse);
    //        applicationFormPage.AnswerAdditionalQuestions();
    //        applicationFormPage.EnterStrengths();
    //        applicationFormPage.EnterSkills();
    //        applicationFormPage.EnterHobbiesAndInterests();
    //        applicationFormPage.ClickSaveAndContinue();
    //        applicationFormPage.SelectAcceptSubmit();
    //        applicationFormPage.SubmitApprenticeshipApplication();
    //    }
    //    else
    //    {
    //        applicationFormPage.EnterWorkExperience(workExperience);
    //        applicationFormPage.EnterTrainingCourse(trainingCourse);
    //        applicationFormPage.EnterQualificationdetails(qualificationdetails);
    //        applicationFormPage.AnswerAdditionalQuestions();
    //        applicationFormPage.SubmitTraineeshipApplication();
    //    }
    //}

    //public void ApplyForTraineeship()
    //{
    //    ApplyForAVacancy(string.Empty, string.Empty, string.Empty, false);
    //}

    //public void CheckNationWideVacancies()
    //{
    //    FAA_ApprenticeSearchResultsPage _faaApprenticeshipSearchResultsPage = new(context);
    //    _faaApprenticeshipSearchResultsPage.CheckSortOrderAndDistance();
    //}

    //public void CreateDraftApplication() => SearchByReferenceNumber().Apply().ClickSave();

    //public FAA_ApprenticeSummaryPage ConfirmDraftVacancyDeletion() => new FAA_MyApplicationsHomePage(context).ConfirmVacancyDeletion().ConfirmDraftVacancyDeletion();

    //public void ChangePersonalSettings()
    //{
    //    var signInpage = GoToSettingsPage().ChangeTheEmailIdSettings().ChangeEmailAddress();

    //    signInpage.ConfirmEmailAddressUpdate();

    //    _objectContext.SetFAAUsername(_faaDataHelper.ChangedEmailId);

    //    GoToSettingsPage().ChangePhoneNumberSettings().EnterVerificationCode().VerifySuccessfulVerificationText();
    //}

    //private FAA_ApprenticeSummaryPage SearchByReferenceNumber()
    //{
    //    if (_objectContext.IsApprenticeshipVacancyType())
    //        return FindAnApprenticeship().SearchByReferenceNumber();
    //    else
    //        return FindATraineeship().SearchByReferenceNumber();
    //}

    //private FAA_MyApplicationsHomePage OpenFAAHomePageinNewtab()
    //{
    //    _tabHelper.OpenInNewTab(_faaBaseUrl);

    //    return new FAA_FindAnApprenticeshipHomePage(context).MyApplications();
    //}

    //private FAA_SettingsPage GoToSettingsPage() => GoToFAAHomePage().GoToSettings();

    //private FAA_ApprenticeSummaryPage SearchByCategory() => FindAnApprenticeship().BrowseVacancy().SelectBrowsedVacancy();
}