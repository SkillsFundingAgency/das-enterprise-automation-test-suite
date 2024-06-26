namespace SFA.DAS.FAAV2.UITests.Project.Pages.WorkHistory;

public class JobsPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Jobs";

    public AddAJobPage SelectYesAndContinue()
    {
        SelectRadioOptionByForAttribute("DoYouWantToAddAnyJobs");
        Continue();
        return new(context);
    }

    public FAA_ApplicationOverviewPage SelectNoAndContinue()
    {
        SelectRadioOptionByForAttribute("DoYouWantToAddAnyJobs-false");
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
