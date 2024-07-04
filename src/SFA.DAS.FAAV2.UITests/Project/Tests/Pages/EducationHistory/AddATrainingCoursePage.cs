namespace SFA.DAS.FAAV2.UITests.Project.Tests.Pages.EducationHistory;

public class AddATrainingCoursePage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Add a training course";

    private static By CourseName => By.CssSelector("#CourseName");

    private static By YearAchieved => By.CssSelector("#YearAchieved");

    public TrainingCoursePage SelectATrainingCourseAndContinue()
    {
        formCompletionHelper.EnterText(CourseName, faaDataHelper.TrainingCoursesCourseTitle);

        formCompletionHelper.EnterText(YearAchieved, faaDataHelper.TrainingCoursesTo.Year.ToString());

        Continue();

        return new(context);
    }
}
