using SFA.DAS.FAAV2.UITests.Project.Tests.Pages;

namespace SFA.DAS.FAAV2.UITests.Project.Helpers;

public class FAAStepsHelper(ScenarioContext context)
{
    private readonly TabHelper _tabHelper = context.Get<TabHelper>();
    private readonly FAADataHelper _faaDataHelper = context.Get<FAADataHelper>();
    private readonly ObjectContext _objectContext = context.Get<ObjectContext>();
    private readonly string _faaBaseUrl = UrlConfig.FAAV2_AppSearch;

    public FAASignedInLandingBasePage GoToFAAHomePage()
    {
        _tabHelper.GoToUrl(_faaBaseUrl);

        if (new CheckFAASignedOutLandingPage(context).IsPageDisplayed())
        {
            new FAASignedOutLandingpage(context).GoToSignInPage().SubmitValidUserDetails(context.GetUser<FAAApplyUser>()).Continue();
        }

        return new FAASignedInLandingBasePage(context);
    }

    public void VerifyApplicationStatus(bool IsSucessful)
    {
        var page = GoToFAAHomePage().GoToApplications();
         
        if (IsSucessful) page.OpenSuccessfulApplicationPage().ViewApplication();

        else page.OpenUnSuccessfulApplicationPage().ViewApplication();
    }

    public FAA_ApplicationOverviewPage ApplyForAVacancy()
    {
        var applicationFormPage = GoToFAAHomePageAndApply();

        applicationFormPage = applicationFormPage.Access_Section1_1SchoolCollegeQualifications().SelectSectionCompleted().VerifyEducationHistory_1();

        applicationFormPage = applicationFormPage.Access_Section1_2TrainingCourse().SelectSectionCompleted().VerifyEducationHistory_2();

        applicationFormPage = applicationFormPage.Access_Section2_1Jobs().SelectSectionCompleted().VerifyWorkHistory_1();

        applicationFormPage = applicationFormPage.Access_Section2_2VolunteeringAndWorkExperience().SelectSectionCompleted().VerifyWorkHistory_2();

        applicationFormPage = applicationFormPage.Access_Section3_1SkillsAndStrengths().SelectSectionCompleted().VerifyApplicationsQuestions_1();

        applicationFormPage = applicationFormPage.Access_Section3_2Interests().SelectSectionCompleted().VerifyApplicationsQuestions_2();

        applicationFormPage = applicationFormPage.Access_Section3_3AdditionalQuestion1().SelectYesAndCompleteSection().VerifyApplicationsQuestions_3();

        applicationFormPage = applicationFormPage.Access_Section3_4AdditionalQuestion2().SelectYesAndCompleteSection().VerifyApplicationsQuestions_4();

        applicationFormPage = applicationFormPage.Access_Section4_1Adjustment().SelectYesAndContinue().SelectSectionCompleted().VerifyInterviewAadjustments_1();

        applicationFormPage = applicationFormPage.Access_Section5_1DisabilityConfidence().SelectSectionCompleted().VerifyDisabilityConfidence_1();

        return applicationFormPage;
    }

    private FAA_ApplicationOverviewPage GoToFAAHomePageAndApply() => GoToFAAHomePage().SearchByReferenceNumber().Apply();


    public FAA_ApplicationOverviewPage ApplyForFirstVacancy(bool qualificationdetails, bool trainingCourse, bool job, bool workExperience, bool interviewSupport, bool disabilityConfident)
    {
        var applicationFormPage = GoToFAAHomePageAndApply();

        if (qualificationdetails)
        {
            applicationFormPage = applicationFormPage.Access_Section1_1SchoolCollegeQualifications()
                .SelectYesAndContinue()
                .SelectAQualificationAndContinue()
                .AddQualificationDetailsAndContinue()
                .SelectSectionCompleted()
                .VerifyEducationHistory_1();
        }
        else
        {
            applicationFormPage = applicationFormPage.Access_Section1_1SchoolCollegeQualifications().SelectNoAndContinue().VerifyEducationHistory_1();
        }

        if (trainingCourse)
        {
            applicationFormPage = applicationFormPage.Access_Section1_2TrainingCourse()
                .SelectYesAndContinue()
                .SelectATrainingCourseAndContinue()
                .SelectSectionCompleted()
                .VerifyEducationHistory_2();
        }
        else
        {
            applicationFormPage = applicationFormPage.Access_Section1_2TrainingCourse()
                .SelectNoAndContinue()
                .VerifyEducationHistory_2();
        }

        if (job)
        {
            applicationFormPage = applicationFormPage.Access_Section2_1Jobs()
                .SelectYesAndContinue()
                .SelectAJobAndContinue()
                .SelectSectionCompleted()
                .VerifyWorkHistory_1();
        }
        else
        {
            applicationFormPage = applicationFormPage.Access_Section2_1Jobs()
                .SelectNoAndContinue()
                .VerifyWorkHistory_1();
        }

        if (workExperience)
        {
            applicationFormPage = applicationFormPage.Access_Section2_2VolunteeringAndWorkExperience()
                .SelectYesAndContinue()
                .SelectAVolunteeringAndWorkExperience()
                .SelectSectionCompleted()
                .VerifyWorkHistory_2();
        }
        else
        {
            applicationFormPage = applicationFormPage.Access_Section2_2VolunteeringAndWorkExperience()
                .SelectNoAndContinue()
                .VerifyEducationHistory_2();
        }

        applicationFormPage = applicationFormPage.Access_Section3_1SkillsAndStrengths()
            .SelectYesAndCompleteSection()
            .VerifyApplicationsQuestions_1()
            .Access_Section3_2Interests()
            .SelectYesAndCompleteSection()
            .VerifyApplicationsQuestions_2()
            .Access_Section3_3AdditionalQuestion1()
            .SelectYesAndCompleteSection()
            .VerifyApplicationsQuestions_3()
            .Access_Section3_4AdditionalQuestion2()
            .SelectYesAndCompleteSection()
            .VerifyApplicationsQuestions_4();

        if (interviewSupport)
        {
            applicationFormPage = applicationFormPage.Access_Section4_1Adjustment()
                .SelectYesAndContinue()
                .SelectSectionCompleted()
                .VerifyInterviewAadjustments_1();
        }
        else
        {
            applicationFormPage = applicationFormPage.Access_Section4_1Adjustment()
                .SelectNoAndContinue()
                .SelectSectionCompleted()
                .VerifyInterviewAadjustments_1();
        }

        if (disabilityConfident)
        {
            applicationFormPage = applicationFormPage.Access_Section5_1DisabilityConfidence()
                .SelectYesAndContinue()
                .SelectSectionCompleted()
                .VerifyDisabilityConfidence_1();
        }
        else
        {
            applicationFormPage = applicationFormPage.Access_Section5_1DisabilityConfidence()
                .SelectNoAndContinue()
                .SelectSectionCompleted()
                .VerifyDisabilityConfidence_1();
        }


        return applicationFormPage;
    }

    //    applicationFormPage.EnterEducation();
    //    applicationFormPage.EnterStartedYear();
    //    applicationFormPage.EnterFinishedYear();
    //    applicationFormPage.EnterQualificationdetails(qualificationdetails);
    //    applicationFormPage.EnterWorkExperience(workExperience);
    //    applicationFormPage.EnterTrainingCourse(trainingCourse);
    //    applicationFormPage.AnswerAdditionalQuestions();
    //    applicationFormPage.EnterStrengths();
    //    applicationFormPage.EnterSkills();
    //    applicationFormPage.EnterHobbiesAndInterests();
    //    applicationFormPage.ClickSaveAndContinue();
    //    applicationFormPage.SelectAcceptSubmit();
    //    applicationFormPage.SubmitApprenticeshipApplication();
    //}

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