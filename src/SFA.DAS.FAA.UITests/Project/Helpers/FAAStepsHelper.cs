using SFA.DAS.FAA.UITests.Project.Tests.Pages;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.UI.FrameworkHelpers;


namespace SFA.DAS.FAA.UITests.Project.Helpers;

public class FAAStepsHelper(ScenarioContext context)
{
    public FAASignedInLandingBasePage GoToFAAHomePage()
    {
        context.Get<TabHelper>().GoToUrl(UrlConfig.FAA_AppSearch);

        if (new CheckFAASignedOutLandingPage(context).IsPageDisplayed())
        {
            new FAASignedOutLandingpage(context).GoToSignInPage().SubmitValidUserDetails(context.GetUser<FAAApplyUser>()).Continue();
        }

        return new FAASignedInLandingBasePage(context);
    }

    public FAASignedInLandingBasePage SubmitNewUserDetails()
    {
        context.Get<TabHelper>().GoToUrl(UrlConfig.FAA_AppSearch);

        if (new CheckFAASignedOutLandingPage(context).IsPageDisplayed())
        {
            var faaUser = context.Get<FAAUserNameDataHelper>();

            var faaApplyUser = new FAAApplyUser { Username = faaUser.FaaNewUserEmail, IdOrUserRef = faaUser.FaaNewUserPassword, MobilePhone = faaUser.FaaNewUserMobilePhone };

            new FAASignedOutLandingpage(context).GoToSignInPage().SubmitNewUserDetails(faaApplyUser).Continue();
        }

        return new FAASignedInLandingBasePage(context);
    }

    public void NavigateToClosedFAAVacancyDetails()
    {
        var tabHelper = context.Get<TabHelper>();
        var closedVacancyList = context.Get<FrameworkList<FAAConfig>>();
        var closedVacancyConfig = closedVacancyList?.FirstOrDefault();

        if (closedVacancyConfig == null)
        {
            throw new InvalidOperationException("ClosedVacancyConfig is missing.");
        }

        var vacancyReference = closedVacancyConfig.ClosedFaaVacancyReferenceNumber;

        var baseUrl = UrlConfig.FAA_AppSearch.Replace("apprenticeshipsearch", "apprenticeship");
        var closedVacancyUrl = $"{baseUrl}/{vacancyReference}";

        tabHelper.GoToUrl(closedVacancyUrl);
    }


    public void NavigateToClosedVacancyAndStoreTitle()
    {
        NavigateToClosedFAAVacancyDetails();

        var closedVacancyPage = new ClosedVacancyPage(context);

        var closedVacancyTitle = closedVacancyPage.GetClosedVacancyTitle();

        context["ClosedVacancyPageTitle"] = closedVacancyTitle;
    }

    public ClosedVacancyLoggedInUserPage GoToClosedVacancyLoggedInPage()
    {
        new FAASignedOutLandingpage(context).GoToSignInPage()
            .SubmitValidUserDetails(context.GetUser<FAAApplyUser>())
            .Continue();

        return new ClosedVacancyLoggedInUserPage(context);
    }

    public void VerifyApplicationStatus(bool IsSucessful)
    {
        var page = GoToFAAHomePage().GoToApplications();

        if (IsSucessful) page.OpenSuccessfulApplicationPage().ViewApplication();

        else page.OpenUnSuccessfulApplicationPage().ViewApplication();
    }

    public FAA_ApplicationOverviewPage ApplyForAVacancy(string numberOfQuestions)
    {
        var applicationFormPage = GoToFAAHomePageAndApply();

        applicationFormPage = applicationFormPage.Access_Section1_1SchoolCollegeQualifications().SelectSectionCompleted().VerifyEducationHistory_1();

        applicationFormPage = applicationFormPage.Access_Section1_2TrainingCourse().SelectSectionCompleted().VerifyEducationHistory_2();

        applicationFormPage = applicationFormPage.Access_Section2_1Jobs().SelectSectionCompleted().VerifyWorkHistory_1();

        applicationFormPage = applicationFormPage.Access_Section2_2VolunteeringAndWorkExperience().SelectSectionCompleted().VerifyWorkHistory_2();

        applicationFormPage = applicationFormPage.Access_Section3_1SkillsAndStrengths().SelectSectionCompleted().VerifyApplicationsQuestions_1();

        applicationFormPage = applicationFormPage.Access_Section3_2Interests().SelectSectionCompleted().VerifyApplicationsQuestions_2();

        switch (numberOfQuestions)
        {
            case "first":
                applicationFormPage = applicationFormPage.Access_Section3_3AdditionalQuestion1().SelectYesAndCompleteSection().VerifyApplicationsQuestions_3();
                break;

            case "second":
                applicationFormPage = applicationFormPage.Access_Section3_4AdditionalQuestion2().SelectYesAndCompleteSection().VerifyApplicationsQuestions_4();
                break;

            case "both":
                applicationFormPage = applicationFormPage.Access_Section3_3AdditionalQuestion1().SelectYesAndCompleteSection().VerifyApplicationsQuestions_3();
                applicationFormPage = applicationFormPage.Access_Section3_4AdditionalQuestion2().SelectYesAndCompleteSection().VerifyApplicationsQuestions_4();
                break;
        }

        applicationFormPage = applicationFormPage.Access_Section4_1Adjustment().SelectYesAndContinue().SelectSectionCompleted().VerifyInterviewAadjustments_1();

        applicationFormPage = applicationFormPage.Access_Section5_1DisabilityConfidence().SelectSectionCompleted().VerifyDisabilityConfidence_1();

        return applicationFormPage;
    }

    public FAA_ApplicationOverviewPage ApplyForAVacancyWithNewAccount(bool qualificationdetails, bool trainingCourse, bool job, bool workExperience, bool interviewSupport, bool disabilityConfident)
    {
        var applicationFormPage = GoToFAASearchResultsPageToSelectAVacancyAndApply();

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
            .RespondToAdditionalQuestion1()
            .SelectYesAndCompleteSection()
            .VerifyApplicationsQuestions_3()
            .RespondToAdditionalQuestion2()
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


    public FAA_ApplicationOverviewPage GoToVacancyDetailsPageThenSaveBeforeApplying() => GoToFAAHomePage().SearchByReferenceNumber().SaveAndApplyForVacancy().Apply();
    public FAA_ApplicationOverviewPage GoToSearchResultsPagePageAndSaveBeforeApplying() => GoToFAAHomePage().SearchAndSaveVacancyByReferenceNumber().SaveFromSearchResultsAndApplyForVacancy();
    private FAA_ApplicationOverviewPage GoToFAAHomePageAndApply() => GoToFAAHomePage().SearchByReferenceNumber().Apply();

    public FAA_SubmittedApplicationPage GoToYourApplicationsPageAndWithdrawAnApplication() => GoToFAAHomePage().GoToApplications().OpenSubmittedlApplicationPage().WithdrawSelectedApplication();

    private FAA_ApplicationOverviewPage GoToFAASearchResultsPageToSelectAVacancyAndApply()
    {
        var landingPage = new FAASignedInLandingBasePage(context);

        var searchResultsPage = landingPage.SearchRandomVacancyAndGetVacancyTitle();

        var apprenticeSummaryPage = searchResultsPage.ClickFirstApprenticeshipThatCanBeAppliedFor();

        return apprenticeSummaryPage.Apply();
    }


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
            .RespondToAdditionalQuestion1()
            .SelectYesAndCompleteSection()
            .VerifyApplicationsQuestions_3()
            .RespondToAdditionalQuestion2()
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
}
