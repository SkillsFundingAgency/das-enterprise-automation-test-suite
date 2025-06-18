namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class ManageTheStandardsYouDeliverPage(ScenarioContext context) : ManagingStandardsBasePage(context)
{
    protected override string PageTitle => "Manage the standards you deliver";

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
    public YourStandardsAndTrainingVenuesPage ReturnToYourStandardsAndTrainingVenues()
    {
        formCompletionHelper.Click(BackLink);
        return new YourStandardsAndTrainingVenuesPage(context);
    }
    public SelectAStandardPage AccessAddStandard()
    {
        formCompletionHelper.ClickLinkByText("Add a standard");
        return new SelectAStandardPage(context);
    }
    public ManageAStandardPage AccessActuaryLevel7(string standardName)
    {
        formCompletionHelper.ClickLinkByText(standardName);
        return new ManageAStandardPage(context, standardName);
    }
}
