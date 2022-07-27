namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class ManageTheStandardsYouDeliverPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Manage the standards you deliver";

    public ManageTheStandardsYouDeliverPage(ScenarioContext context) : base(context) { }

    public ManageAStandard_DevopsPage AccessDevopsEngineerLevel4()
    {
        formCompletionHelper.ClickLinkByText("DevOps engineer (Level 4)");
        return new ManageAStandard_DevopsPage(context);
    }

    public ManageAStandard_TeacherPage AccessTeacherLevel6()
    {
        formCompletionHelper.ClickLinkByText("Teacher (Level 6)");
        return new ManageAStandard_TeacherPage(context);
    }

    public RegulatedStandardPage AccessRegulatorApprovalLinkFromTheSTandardsTable()
    {
        formCompletionHelper.ClickLinkByText("Regulator's approval needed");
        return new RegulatedStandardPage(context);
    }
}
