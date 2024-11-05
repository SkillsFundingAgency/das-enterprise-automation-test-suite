using Microsoft.Identity.Client;
using SFA.DAS.FAA.UITests.Project.Tests.Pages;
using SFA.DAS.Login.Service.Project;
using System.Collections.Generic;

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


    public FAASignedInLandingBasePage GoToFAAToCreateAnAccount(string idOrUserRef, string email)
    {
        if (string.IsNullOrEmpty(email))
        {
            email = context.Get<string>("UserEmail") ??
                    $"user{Guid.NewGuid()}@mailosaur.com";

            context.Set("UserEmail", email);
        }

        if (string.IsNullOrEmpty(idOrUserRef))
        {
            idOrUserRef = context.Get<string>("UserRef") ?? $"User-{Guid.NewGuid()}";

            context.Set("UserRef", idOrUserRef);
        }

        context.Get<TabHelper>().GoToUrl(UrlConfig.FAA_AppSearch);

        if (new CheckFAASignedOutLandingPage(context).IsPageDisplayed())
        {
            new FAASignedOutLandingpage(context)
                .GoToSignInPage().CreateAccount(idOrUserRef, email).Continue();
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
    public FAA_ApplicationOverviewPage GoToVacancyDetailsPageThenSaveBeforeApplying() => GoToFAAHomePage().SearchByReferenceNumber().SaveAndApplyForVacancy().Apply();
    public FAA_ApplicationOverviewPage GoToSearchResultsPagePageAndSaveBeforeApplying() => GoToFAAHomePage().SearchAndSaveVacancyByReferenceNumber().SaveFromSearchResultsAndApplyForVacancy();
    private FAA_ApplicationOverviewPage GoToFAAHomePageAndApply() => GoToFAAHomePage().SearchByReferenceNumber().Apply();


    public FAASignedInLandingBasePage CreateNewUserLogin()
    {
        string user = "user";
        string domain = "mailosaur.com";
        string idOrUserRef = $"User-{Guid.NewGuid()}";
        string email = RandomDataGenerator.GenerateRandomEmail(user, domain);

        context.Set(email, "UserEmail");

        return new FAAStepsHelper(context).GoToFAAToCreateAnAccount(idOrUserRef, email);
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
   
    public void DeleteAccountFromSettings()
    {
        var email = context.Get<string>("UserEmail");

        var apprenticeLandingPage = new FAASearchApprenticeLandingPage(context);
        apprenticeLandingPage.PerformDeleteAccount();
    }

}