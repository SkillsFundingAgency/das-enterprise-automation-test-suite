namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class BatchSearchPage : EPAOAdmin_BasePage
{
    protected override string PageTitle => "Batch search";

    protected override By PageHeader => By.CssSelector(".govuk-label--xl");

    private static By BatchNumber => By.CssSelector("#BatchNumber");

    public BatchSearchPage(ScenarioContext context) : base(context) => VerifyPage();

    public BatchSearchResultsPage SearchBatches()
    {
        formCompletionHelper.EnterText(BatchNumber, Helpers.DataHelpers.EPAOAdminDataHelper.BatchSearch);
        Continue();
        return new BatchSearchResultsPage(context);
    }
}
