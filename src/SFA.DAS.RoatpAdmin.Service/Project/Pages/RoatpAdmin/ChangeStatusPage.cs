namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class ChangeStatusPage(ScenarioContext context) : ChangeBasePage(context)
{
    protected override string PageTitle => "Update the status for this provider";

    protected override string AccessibilityPageTitle => "update provider status";

    private static By ActiveStatus => By.CssSelector("label[for='OrganisationStatusId-1']");

    private static By ActiveButNoApprenticeStatus => By.CssSelector("label[for='OrganisationStatusId-2']");

    protected override By ContinueButton => By.Id("continue");

    public SuccessPage ChangeStatusToActive() => ChangeStatus(ActiveStatus);

    public SuccessPage ChangeStatusToActiveButNoApprentice() => ChangeStatus(ActiveButNoApprenticeStatus);

    private SuccessPage ChangeStatus(By by)
    {
        formCompletionHelper.ClickElement(by);
        Continue();
        return new SuccessPage(context);
    }
}