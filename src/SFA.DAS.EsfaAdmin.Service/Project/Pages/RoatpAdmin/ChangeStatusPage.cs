namespace SFA.DAS.EsfaAdmin.Service.Project.Pages.RoatpAdmin;

public class ChangeStatusPage : ChangeBasePage
{
    protected override string PageTitle => $"Change status for {objectContext.GetProviderName()}";

    private static By ActiveStatus => By.CssSelector("label[for='status-1']");

    private static By ActiveButNoApprenticeStatus => By.CssSelector("label[for='status-1']");

    protected override By ContinueButton => By.CssSelector(".govuk-button[value='Change']");

    public ChangeStatusPage(ScenarioContext context) : base(context) { }

    public ResultsFoundPage ChangeStatusToActive() => ChangeStatus(ActiveStatus);

    public ResultsFoundPage ChangeStatusToActiveButNoApprentice() => ChangeStatus(ActiveButNoApprenticeStatus);

    private ResultsFoundPage ChangeStatus(By by)
    {
        formCompletionHelper.ClickElement(by);
        Continue();
        return new ResultsFoundPage(context);
    }
}