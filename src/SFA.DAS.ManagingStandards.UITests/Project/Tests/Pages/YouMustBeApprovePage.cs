namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class YouMustBeApprovePage : VerifyBasePage
{
    protected override string PageTitle => "You must be approved by the regulator to deliver this standard";

    public YouMustBeApprovePage(ScenarioContext context) : base(context) => VerifyPage();

    public ManageAStandard_TeacherPage ContinueToTeacher_ManageStandardPage()
    {
        Continue();
        return new ManageAStandard_TeacherPage(context);
    }
}
