namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class UlnSearchResultsPage : SupportConsoleBasePage
{
    protected override string PageTitle => "View ULN";

    public UlnSearchResultsPage(ScenarioContext context) : base(context) => VerifyPage();

    public UlnDetailsPage SelectULN(CohortDetails cohortDetails)
    {
        tableRowHelper.SelectRowFromTable("View", cohortDetails.UlnName);
        return new(context, cohortDetails);
    }
}