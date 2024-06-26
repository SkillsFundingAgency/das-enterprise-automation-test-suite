namespace SFA.DAS.FAAV2.UITests.Project.Pages.EducationHistory;

public class TrainingCoursePage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Training courses";

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

    public FAA_ApplicationOverviewPage SelectSectionCompleted()
    {
        SelectRadioOptionByForAttribute("IsSectionCompleted");
        Continue();
        return new(context);
    }
}
