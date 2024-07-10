using SFA.DAS.FAA.UITests.Project.Tests.Pages;

namespace SFA.DAS.FAA.UITests.Project.Pages.ApplicationOverview;

public partial class FAA_ApplicationOverviewPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => $"Apply for {vacancyTitleDataHelper.VacancyTitle}";

}

public partial class FAA_ApplicationOverviewPage : FAABasePage
{
    #region Questions
    private static string EducationHistory => "Education history";
    private static string EducationHistoryFirstQuestion => "School";
    private static string EducationHistory_1 => "School, college and university qualifications";
    private static string EducationHistory_2 => "Training courses";

    private static string WorkHistory => "Work history";
    private static string WorkHistoryFirstQuestion => "Jobs";
    private static string WorkHistory_1 => "Jobs";
    private static string WorkHistory_2 => "Volunteering and work experience";

    private static string ApplicationQuestions => "Application questions";

    private static string ApplicationQuestionsFirstQuestion => "What are your skills and strengths";
    private static string ApplicationQuestions_1 => "What are your skills and strengths?";
    private static string ApplicationQuestions_2 => "What interests you about this apprenticeship?";

    private static string InterviewAdjustments => "Interview adjustments";

    private static string InterviewAdjustmentsFirstQuestion => "Request adjustments";
    private static string InterviewAdjustments_1 => "Request adjustments on your application";


    private static string DisabilityConfidence => "Disability Confidence";

    private static string DisabilityConfidenceFirstQuestion => "Interview under the Disability";
    private static string DisabilityConfidence_1 => "Interview under the Disability Confident scheme";

    #endregion
}