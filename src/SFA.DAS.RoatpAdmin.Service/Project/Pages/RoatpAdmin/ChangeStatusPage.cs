namespace SFA.DAS.RoatpAdmin.Service.Project.Pages.RoatpAdmin;

public class ChangeStatusPage(ScenarioContext context) : ChangeBasePage(context)
{
    protected override string PageTitle => "Update the status for this provider";

    protected override string AccessibilityPageTitle => "update provider status";

    private static By ActiveStatus => By.Id("OrganisationStatusId-1");

    private static By ActiveButNoApprenticeStatus => By.Id("OrganisationStatusId-2");

    protected override By ContinueButton => By.CssSelector(".govuk-button[value='Change']");

    public ResultsFoundPage ChangeStatusToActive() => ChangeStatus(ActiveStatus);

    public ResultsFoundPage ChangeStatusToActiveButNoApprentice() => ChangeStatus(ActiveButNoApprenticeStatus);

    private ResultsFoundPage ChangeStatus(By by)
    {
        formCompletionHelper.ClickElement(by);
        Continue();
        return new ResultsFoundPage(context);
    }
}