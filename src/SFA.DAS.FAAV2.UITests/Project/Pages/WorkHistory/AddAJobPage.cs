namespace SFA.DAS.FAAV2.UITests.Project.Pages.WorkHistory;

public class AddAJobPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Add a job";

    private static By JobTitle => By.CssSelector("#JobTitle");

    private static By EmployerName => By.CssSelector("#EmployerName");

    private static By JobDescription => By.CssSelector("#JobDescription");

    private static By StartDateMonth => By.CssSelector("#StartDateMonth");
    private static By StartDateYear => By.CssSelector("#StartDateYear");

    public JobsPage SelectAJobAndContinue()
    {
        formCompletionHelper.EnterText(JobTitle, faaDataHelper.WorkExperienceJobTitle);

        formCompletionHelper.EnterText(EmployerName, faaDataHelper.WorkExperienceEmployer);

        formCompletionHelper.EnterText(JobDescription, faaDataHelper.WorkExperienceMainDuties);

        formCompletionHelper.EnterText(StartDateMonth, faaDataHelper.WorkExperienceStarted.Month.ToString());

        formCompletionHelper.EnterText(StartDateYear, faaDataHelper.WorkExperienceStarted.Year.ToString());

        SelectRadioOptionByForAttribute("IsCurrentRole");

        formCompletionHelper.ClickButtonByText(ContinueButton, "Save and continue");

        return new(context);
    }
}
