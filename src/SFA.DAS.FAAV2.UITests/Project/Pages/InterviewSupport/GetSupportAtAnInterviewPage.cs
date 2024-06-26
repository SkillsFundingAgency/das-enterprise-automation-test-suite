namespace SFA.DAS.FAAV2.UITests.Project.Pages.InterviewSupport;

public class GetSupportAtAnInterviewPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Get support at an interview";

    public FAA_ApplicationOverviewPage SelectSectionCompleted()
    {
        SelectRadioOptionByForAttribute("IsSectionCompleted");
        Continue();
        return new(context);
    }
}
