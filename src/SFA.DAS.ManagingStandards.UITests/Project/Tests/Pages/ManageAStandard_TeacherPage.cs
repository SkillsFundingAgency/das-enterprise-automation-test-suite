namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class ManageAStandard_TeacherPage : ManagingStandardsBasePage
{
    protected override string PageTitle => managingStandardsDataHelpers.StandardsTestData.StandardName;

    public ManageAStandard_TeacherPage(ScenarioContext context) : base(context) { }

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

    public TrainingVenuesPage AccessEditTrainingLocations()
    {
        formCompletionHelper.ClickLinkByText("Edit training locations");
        return new TrainingVenuesPage(context);
    }
    public YourContactInformationForThisStandardPage UpdateTheseContactDetails()
    {
        formCompletionHelper.ClickLinkByText("Update these contact details");
        return new YourContactInformationForThisStandardPage(context);
    }
}
