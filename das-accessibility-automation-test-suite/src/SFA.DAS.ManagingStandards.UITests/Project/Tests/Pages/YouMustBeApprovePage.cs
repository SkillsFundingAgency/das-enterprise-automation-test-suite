namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class YouMustBeApprovePage(ScenarioContext context) : ManagingStandardsBasePage(context)
{
    protected override string PageTitle => "You must be approved by the regulator to deliver this standard";

    public ManageAStandard_TeacherPage ContinueToTeacher_ManageStandardPage()
    {
        Continue();
        return new ManageAStandard_TeacherPage(context);
    }
}
