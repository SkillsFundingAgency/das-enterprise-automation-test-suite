namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class UlnSearchResultsPage : SupportConsoleBasePage
{
    protected override string PageTitle => "View ULN";

    public UlnSearchResultsPage(ScenarioContext context) : base(context) => VerifyPage();

    public UlnDetailsPage SelectULN()
    {
        tableRowHelper.SelectRowFromTable("View", config.UlnName);
        return new (context);
    }
}