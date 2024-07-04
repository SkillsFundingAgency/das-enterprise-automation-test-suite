namespace SFA.DAS.FAAV2.UITests.Project.Tests.Pages.WorkHistory;

public class AddVolunteeringOrWorkExperiencePage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Add volunteering or work experience";

    private static By CompanyName => By.CssSelector("#CompanyName");

    private static By Description => By.CssSelector("#Description");

    private static By StartDateMonth => By.CssSelector("#StartDateMonth");

    private static By StartDateYear => By.CssSelector("#StartDateYear");

    public VolunteeringAndWorkExperiencePage SelectAVolunteeringAndWorkExperience()
    {
        formCompletionHelper.EnterText(CompanyName, faaDataHelper.WorkExperienceEmployer);

        formCompletionHelper.EnterText(Description, faaDataHelper.WorkExperienceMainDuties);

        formCompletionHelper.EnterText(StartDateMonth, faaDataHelper.WorkExperienceStarted.Month.ToString());

        formCompletionHelper.EnterText(StartDateYear, faaDataHelper.WorkExperienceStarted.Year.ToString());

        SelectRadioOptionByForAttribute("IsCurrentRole");

        formCompletionHelper.ClickButtonByText(ContinueButton, "Save and continue");

        return new(context);
    }
}




