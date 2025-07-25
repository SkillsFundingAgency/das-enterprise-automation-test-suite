using SFA.DAS.FAA.UITests.Project.Tests.Pages;
using SFA.DAS.FAA.UITests.Project.Tests.Pages.ApplicationQuestions;
using SFA.DAS.FAA.UITests.Project.Tests.Pages.DisabilityConfident;
using SFA.DAS.FAA.UITests.Project.Tests.Pages.EducationHistory;
using SFA.DAS.FAA.UITests.Project.Tests.Pages.InterviewSupport;
using SFA.DAS.FAA.UITests.Project.Tests.Pages.Locations;
using SFA.DAS.FAA.UITests.Project.Tests.Pages.WorkHistory;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.FAA.UITests.Project.Pages.ApplicationOverview;

public partial class FAA_ApplicationOverviewPage : FAABasePage
{
    protected override By TaskLists => By.CssSelector(".govuk-task-list");

    protected override By TaskItem => By.CssSelector(".govuk-task-list__item");

    protected override By TaskName => By.CssSelector(".govuk-task-list__name-and-hint > .govuk-link");

    protected override By TaskStatus => By.CssSelector(".govuk-task-list__status");

    private static By PreviewApplicaitonSelector => By.CssSelector("a.govuk-button[href*='preview']");
    private static By AdditionalQuestion1Link => By.Id("additionalquestion1");
    private static By AdditionalQuestion2Link => By.Id("additionalquestion2");
    private static By AdditionalQuestionTextBox => By.Id("AdditionalQuestionAnswer");

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

    public WhereDoYouWantToApplyForPage Access_Section6_1Locations()
    {
        NavigateToTask(LocationsFirstQuestion, Locations_1);
        return new(context);
    }

    #endregion

    public CheckYourApplicationBeforeSubmittingPage PreviewApplication()
    {
        formCompletionHelper.Click(PreviewApplicaitonSelector);

        return new(context);
    }

    public AdditionQuestion1Page RespondToAdditionalQuestion1()
    {
        formCompletionHelper.Click(AdditionalQuestion1Link);
        formCompletionHelper.EnterText(AdditionalQuestionTextBox, faaDataHelper.AdditionalQuestions1Answer);

        return new(context);
    }

    public AdditionQuestion2Page RespondToAdditionalQuestion2()
    {
        formCompletionHelper.Click(AdditionalQuestion2Link);
        formCompletionHelper.EnterText(AdditionalQuestionTextBox, faaDataHelper.AdditionalQuestions1Answer);

        return new(context);
    }
    private void NavigateToTask(string sectionName, string taskName) => NavigateToTask(sectionName, taskName, 0, null);

    public FAA_ApplicationOverviewPage VerifyEducationHistory_1() => Verify_Section1(EducationHistory_1, "Complete");
    public FAA_ApplicationOverviewPage VerifyEducationHistory_2() => Verify_Section1(EducationHistory_2, "Complete");

    public FAA_ApplicationOverviewPage VerifyWorkHistory_1() => Verify_Section2(WorkHistory_1, "Complete");
    public FAA_ApplicationOverviewPage VerifyWorkHistory_2() => Verify_Section2(WorkHistory_2, "Complete");

    public FAA_ApplicationOverviewPage VerifyApplicationsQuestions_1() => Verify_Section3(ApplicationQuestions_1, "Complete");
    public FAA_ApplicationOverviewPage VerifyApplicationsQuestions_2() => Verify_Section3(ApplicationQuestions_2, "Complete");
    public FAA_ApplicationOverviewPage VerifyApplicationsQuestions_3()
    {
        var additionalQuestion1Title = new FAA_ApplicationOverviewPage(context);
        return Verify_Section3(additionalQuestion1Title.GetAdditionalQuestion1TitleText(), "Complete");
    }

    public FAA_ApplicationOverviewPage VerifyApplicationsQuestions_4()
    {
        var additionalQuestion2Title = new FAA_ApplicationOverviewPage(context);
        return Verify_Section3(additionalQuestion2Title.GetAdditionalQuestion2TitleText(), "Complete");
    }

    public FAA_ApplicationOverviewPage VerifyInterviewAadjustments_1() => Verify_Section4(InterviewAdjustments_1, "Complete");
    public FAA_ApplicationOverviewPage VerifyDisabilityConfidence_1() => Verify_Section5(DisabilityConfidence_1, "Complete");
    public FAA_ApplicationOverviewPage VerifyLocations_1() => Verify_Section6(Locations_1, "Complete");

    private FAA_ApplicationOverviewPage Verify_Section1(string taskName, string status) => VerifySections(EducationHistoryFirstQuestion, taskName, status);

    private FAA_ApplicationOverviewPage Verify_Section2(string taskName, string status) => VerifySections(WorkHistoryFirstQuestion, taskName, status);

    private FAA_ApplicationOverviewPage Verify_Section3(string taskName, string status) => VerifySections(ApplicationQuestionsFirstQuestion, taskName, status);

    private FAA_ApplicationOverviewPage Verify_Section4(string taskName, string status) => VerifySections(InterviewAdjustmentsFirstQuestion, taskName, status);

    private FAA_ApplicationOverviewPage Verify_Section5(string taskName, string status) => VerifySections(DisabilityConfidenceFirstQuestion, taskName, status);
    private FAA_ApplicationOverviewPage Verify_Section6(string taskName, string status) => VerifySections(LocationsFirstQuestion, taskName, status);

    private FAA_ApplicationOverviewPage VerifySections(string sectionName, string taskName, string status, int index = 0)
    {
        VerifySectionTaskStatus(sectionName, taskName, status, index, null);
        return new FAA_ApplicationOverviewPage(context);
    }
    public string GetAdditionalQuestion1TitleText()
    {
        return pageInteractionHelper.FindElement(AdditionalQuestion1Link).Text;
    }
    public string GetAdditionalQuestion2TitleText()
    {
        return pageInteractionHelper.FindElement(AdditionalQuestion2Link).Text;
    }
}

