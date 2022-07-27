namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class ManageAStandard_TeacherPage : VerifyBasePage
{
    protected override string PageTitle => "Teacher (Level 6)";

    public ManageAStandard_TeacherPage(ScenarioContext context) : base(context) => VerifyPage();

    public RegulatedStandardPage AccessApprovedByRegulationOrNot()
    {
        formCompletionHelper.ClickLinkByText("Change");
        return new RegulatedStandardPage(context);
    }

    public WhereWillThisStandardBeDeliveredPage AccessWhereYouWillDeliverThisStandard()
    {
        formCompletionHelper.ClickLinkByText("where you deliver this standard");
        return new WhereWillThisStandardBeDeliveredPage(context);
    }

    public WhereCanYouDeliverTrainingPage AccessEditTheseRegions()
    {
        formCompletionHelper.ClickLinkByText("Edit these regions");
        return new WhereCanYouDeliverTrainingPage(context);
    }
}
