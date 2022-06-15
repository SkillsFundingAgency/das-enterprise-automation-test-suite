namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class FinancePage : SupportConsoleBasePage
{
    protected override string PageTitle => "Finance";

    protected override By PageHeader => By.CssSelector(".heading-xlarge");

    private static By TransactionsViewLink => By.LinkText("Transactions");

    private static By CurrentBalance => By.CssSelector(".data__purple-block");

    public FinancePage(ScenarioContext context) : base(context) => VerifyPage();

    public LevyDeclarationsPage ViewLevyDeclarations()
    {
        var paye = config.PayeScheme.ToCharArray();

        string obscurepaye = string.Empty;

        for (int i = 0; i < paye.Length; i++)
        {
            obscurepaye += ((i == 0 || i == paye.Length - 1 || paye[i].ToString() == "/") ? paye[i].ToString() : "*");
        }

        tableRowHelper.SelectRowFromTable("view", obscurepaye);

        return new (context);
    }

    public void ViewTransactions()
    {
        formCompletionHelper.Click(TransactionsViewLink);
        pageInteractionHelper.VerifyText(CurrentBalance, "Current balance");
    }

}