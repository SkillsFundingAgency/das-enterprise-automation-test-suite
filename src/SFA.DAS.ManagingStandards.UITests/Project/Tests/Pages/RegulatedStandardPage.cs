namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages;

public class RegulatedStandardPage(ScenarioContext context) : ManagingStandardsBasePage(context)
{
    protected override string PageTitle => "This is a regulated standard";

    private static By ApprovesYesRadio => By.Id("ConfirmRegulatedStandard-Yes");
    private static By ApprovesNoRadio => By.Id("ConfirmRegulatedStandard-No");

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
