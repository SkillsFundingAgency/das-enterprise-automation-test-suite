namespace SFA.DAS.FAA.UITests.Project.Tests.Pages.EducationHistory;

public class TrainingCoursePage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Training courses";

    protected override By SubmitSectionButton => By.CssSelector("button.govuk-button[type='submit']");

    public AddATrainingCoursePage SelectYesAndContinue()
    {
        SelectRadioOptionByForAttribute("DoYouWantToAddAnyTrainingCourses");
        Continue();
        return new(context);
    }

    public FAA_ApplicationOverviewPage SelectNoAndContinue()
    {
        SelectRadioOptionByForAttribute("add-qualifications-false-No");
        Continue();
        return new(context);
    }

    public new FAA_ApplicationOverviewPage SelectSectionCompleted()
    {
        SelectRadioOptionByForAttribute("IsSectionComplete");

        formCompletionHelper.Click(SubmitSectionButton);

        return new(context);
    }
}
