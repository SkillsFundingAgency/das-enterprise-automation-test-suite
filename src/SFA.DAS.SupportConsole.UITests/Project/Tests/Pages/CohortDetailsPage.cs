namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class CohortDetailsPage : SupportConsoleBasePage
{
    protected override string PageTitle => "Cohort Details";

    #region Locators

    private static By ColumnIdentifier => By.CssSelector("a[href*='resource?key=CommitmentApprenticeDetail']");
    private static By CohortRefNumber => By.XPath("//td[text()='Cohort reference:']/following-sibling::td");
    #endregion

    public CohortDetailsPage(ScenarioContext context) : base(context) => VerifyPage();

    public void ClickViewUlnLink()
    {
        formCompletionHelper.ClickElement(() => tableRowHelper.GetColumn(config.Uln, ColumnIdentifier, tableposition: 1));
        pageInteractionHelper.WaitforURLToChange("CommitmentApprenticeDetail");
    }

    public string GetCohortRefNumber() => pageInteractionHelper.GetText(CohortRefNumber);
}