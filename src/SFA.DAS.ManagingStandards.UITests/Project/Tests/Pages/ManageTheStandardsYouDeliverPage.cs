namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class ManageTheStandardsYouDeliverPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Manage the standards you deliver";

    public ManageTheStandardsYouDeliverPage(ScenarioContext context) : base(context) { }

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
    public ManageAStandard_ActuaryPage AccessActuaryLevel7()
    {
        formCompletionHelper.ClickLinkByText(managingStandardsDataHelpers.Standard_ActuaryLevel7);
        return new ManageAStandard_ActuaryPage(context);
    }
}
