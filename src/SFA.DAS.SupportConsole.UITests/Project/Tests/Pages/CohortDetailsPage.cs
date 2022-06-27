namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class CohortDetailsPage : SupportConsoleBasePage
{
    private readonly CommitmentsSqlDataHelper commitmentSqlDataBaseHelper;

    protected override string PageTitle => "Cohort Details";

    #region Locators
    private static By ColumnIdentifier => By.CssSelector("a[href*='resource?key=CommitmentApprenticeDetail']");
    private static By CohortRefNumber => By.XPath("//td[text()='Cohort reference:']/following-sibling::td");
    #endregion

    public CohortDetailsPage(ScenarioContext context) : base(context)
    {
        VerifyPage();
        commitmentSqlDataBaseHelper = new CommitmentsSqlDataHelper(context.Get<DbConfig>());
    }

    public void ClickViewUlnLink()
    {
        formCompletionHelper.ClickElement(() => tableRowHelper.GetColumn(config.Uln, ColumnIdentifier, tableposition: 1));
        pageInteractionHelper.WaitforURLToChange("CommitmentApprenticeDetail");
    }

    public string GetCohortRefNumber() => pageInteractionHelper.GetText(CohortRefNumber);

    public void ClickViewUlnLinkWithPendingChanges(string cohortRef)
    {
        var uln = commitmentSqlDataBaseHelper.GetUlnWithPendingChanges(cohortRef);
        formCompletionHelper.ClickElement(() => tableRowHelper.GetColumn(uln, ColumnIdentifier, tableposition: 1));
        pageInteractionHelper.WaitforURLToChange("CommitmentApprenticeDetail");
    }

    public void ClickViewUlnLinkWithTrainingProviderHistory(string cohortRef)
    {
        var uln = commitmentSqlDataBaseHelper.GetUlnWithTrainingProviderHistory(cohortRef);
        formCompletionHelper.ClickElement(() => tableRowHelper.GetColumn(uln, ColumnIdentifier, tableposition: 1));
        pageInteractionHelper.WaitforURLToChange("CommitmentApprenticeDetail");
    }
}