using SFA.DAS.FAAV2.UITests.Project.Pages.ApplicationQuestions;
using SFA.DAS.FAAV2.UITests.Project.Pages.DisabilityConfident;
using SFA.DAS.FAAV2.UITests.Project.Pages.EducationHistory;
using SFA.DAS.FAAV2.UITests.Project.Pages.InterviewSupport;
using SFA.DAS.FAAV2.UITests.Project.Pages.WorkHistory;

namespace SFA.DAS.FAAV2.UITests.Project.Pages;

public class CheckYourApplicationBeforeSubmittingPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Check your application before submitting";

    public ApplicationSubmittedPage SubmitApplication()
    {
        SelectCheckBoxByText("I understand that I won't be able to make any changes after I submit my application");

        Continue();

        return new(context);
    }
}


public class ApplicationSubmittedPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Application submitted";

    protected override By PageHeader => By.CssSelector(".govuk-panel--confirmation");
}



public partial class FAA_ApplicationOverviewPage : FAABasePage
{
    protected override By TaskLists => By.CssSelector(".govuk-task-list");

    protected override By TaskItem => By.CssSelector(".govuk-task-list__item");

    protected override By TaskName => By.CssSelector(".govuk-task-list__name-and-hint > .govuk-link");

    protected override By TaskStatus => By.CssSelector(".govuk-task-list__status > .govuk-tag");

    private static By PreviewApplicaitonSelector => By.CssSelector("a.govuk-button[href*='preview']");

    #region Section-1 Education history

    public SchoolCollegeAndUniversityQualificationsPage Access_Section1_1SchoolCollegeQualifications()
    {
        NavigateToTask(EducationHistoryFirstQuestion, EducationHistory_1);
        return new(context);
    }

    public TrainingCoursePage Access_Section1_2TrainingCourse()
    {
        NavigateToTask(EducationHistoryFirstQuestion, EducationHistory_2);
        return new(context);
    }

    #endregion

    #region Section-2 Work history


    public JobsPage Access_Section2_1Jobs()
    {
        NavigateToTask(WorkHistoryFirstQuestion, WorkHistory_1);
        return new(context);
    }

    public VolunteeringAndWorkExperiencePage Access_Section2_2VolunteeringAndWorkExperience()
    {
        NavigateToTask(WorkHistoryFirstQuestion, WorkHistory_2);
        return new(context);
    }

    #endregion

    #region Section-3 Applications Questions

    public WhatAreYourSkillsAndStrengthsPage Access_Section3_1SkillsAndStrengths()
    {
        NavigateToTask(ApplicationQuestionsFirstQuestion, ApplicationQuestions_1);
        return new(context);
    }

    public WhatInterestsYouAboutTThisApprenticeshipPage Access_Section3_2Interests()
    {
        NavigateToTask(ApplicationQuestionsFirstQuestion, ApplicationQuestions_2);
        return new(context);
    }

    public AdditionQuestion1Page Access_Section3_3AdditionalQuestion1()
    {
        NavigateToTask(ApplicationQuestionsFirstQuestion, advertDataHelper.AdditionalQuestion1);
        return new(context);
    }

    public AdditionQuestion2Page Access_Section3_4AdditionalQuestion2()
    {
        NavigateToTask(ApplicationQuestionsFirstQuestion, advertDataHelper.AdditionalQuestion2);
        return new(context);
    }

    #endregion


    #region Section-4 Interview adjustments
    public AskForSupportAtAnInterviewPage Access_Section4_1Adjustment()
    {
        NavigateToTask(InterviewAdjustmentsFirstQuestion, InterviewAdjustments_1);
        return new(context);
    }

    #endregion

    #region Section-5 Disability Confidence
    public DisabilityConfidentSchemePage Access_Section5_1DisabilityConfidence()
    {
        NavigateToTask(DisabilityConfidenceFirstQuestion, DisabilityConfidence_1);
        return new(context);
    }

    #endregion

    public CheckYourApplicationBeforeSubmittingPage PreviewApplication()
    {
        formCompletionHelper.Click(PreviewApplicaitonSelector);

        return new (context);
    }

    private void NavigateToTask(string sectionName, string taskName) => NavigateToTask(sectionName, taskName, 0, null);

    public FAA_ApplicationOverviewPage VerifyWorkHistory_1() => Verify_Section1(WorkHistory_1, "Complete");
    public FAA_ApplicationOverviewPage VerifyWorkHistory_2() => Verify_Section1(WorkHistory_2, "Complete");

    public FAA_ApplicationOverviewPage VerifyEducationHistory_1() => Verify_Section1(EducationHistory_1, "Complete");
    public FAA_ApplicationOverviewPage VerifyEducationHistory_2() => Verify_Section1(EducationHistory_2, "Complete");

    public FAA_ApplicationOverviewPage VerifyApplicationsQuestions_1() => Verify_Section1(ApplicationQuestions_1, "Complete");
    public FAA_ApplicationOverviewPage VerifyApplicationsQuestions_2() => Verify_Section1(ApplicationQuestions_2, "Complete");
    public FAA_ApplicationOverviewPage VerifyApplicationsQuestions_3() => Verify_Section1(advertDataHelper.AdditionalQuestion1, "Complete");
    public FAA_ApplicationOverviewPage VerifyApplicationsQuestions_4() => Verify_Section1(advertDataHelper.AdditionalQuestion2, "Complete");

    public FAA_ApplicationOverviewPage VerifyInterviewAadjustments_1() => Verify_Section1(InterviewAdjustments_1, "Complete");
    public FAA_ApplicationOverviewPage VerifyDisabilityConfidence_1() => Verify_Section1(DisabilityConfidence_1, "Complete");

    private FAA_ApplicationOverviewPage Verify_Section1(string taskName, string status) => VerifySections(EducationHistoryFirstQuestion, taskName, status);

    private FAA_ApplicationOverviewPage VerifySections(string sectionName, string taskName, string status, int index = 0)
    {
        VerifySectionTaskStatus(sectionName, taskName, status, index, null);
        return new FAA_ApplicationOverviewPage(context);
    }

}
