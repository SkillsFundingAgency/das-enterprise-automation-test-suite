namespace SFA.DAS.SupportTools.UITests.Project.Tests.Pages;

public class FinancePage : SupportConsoleBasePage
{
    protected override string PageTitle => "Finance";

    protected override By PageHeader => By.CssSelector(".heading-xlarge");

    private static By TransactionsViewLink => By.LinkText("Transactions");

    private static By CurrentBalance => By.CssSelector(".data__purple-block");

    public FinancePage(ScenarioContext context) : base(context) => VerifyPage();

    public LevyDeclarationsPage ViewLevyDeclarations()
    {
        var paye = Config.PayeScheme.ToCharArray();

        var obscurepaye = string.Empty;

        for (var index = 0; index < paye.Length; index++)
        {
            obscurepaye += index == 0 || index == paye.Length - 1 || paye[index].ToString() == "/" ? paye[index].ToString() : "*";
        }

        tableRowHelper.SelectRowFromTable("view", obscurepaye);

        return new(context);
    }

    public void ViewTransactions()
    {
        formCompletionHelper.Click(TransactionsViewLink);
        pageInteractionHelper.VerifyText(CurrentBalance, "Current balance");
    }
}