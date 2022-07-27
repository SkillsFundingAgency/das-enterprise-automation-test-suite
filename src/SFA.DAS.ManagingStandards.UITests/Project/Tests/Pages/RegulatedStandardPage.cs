namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class RegulatedStandardPage : ManagingStandardsBasePage
{
    protected override string PageTitle => "This is a regulated standard";

    private static By ApprovesYesRadio => By.Id("IsApprovedByRegulator");
    private static By ApprovesNoRadio => By.Id("IsApprovedByRegulator-No");
    public RegulatedStandardPage(ScenarioContext context) : base(context) { }

    public ManageTheStandardsYouDeliverPage ApproveStandard_FromStandardsPage()
    {
        formCompletionHelper.SelectCheckbox(ApprovesYesRadio);
        Continue();
        return new ManageTheStandardsYouDeliverPage(context);
    }

    public YouMustBeApprovePage DisApproveStandard()
    {
        formCompletionHelper.SelectCheckbox(ApprovesNoRadio);
        Continue();
        return new YouMustBeApprovePage(context);
    }
}
