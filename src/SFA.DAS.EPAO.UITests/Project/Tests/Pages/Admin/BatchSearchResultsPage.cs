namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class BatchSearchResultsPage : EPAOAdmin_BasePage
{
    protected override string PageTitle => "Search results";

    protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

    private static By BatchDetailsHeader => By.CssSelector(".govuk-heading-l");

    public BatchSearchResultsPage(ScenarioContext context) : base(context) => VerifyPage();

    public BatchSearchResultsPage VerifyingBatchDetails()
    {
        VerifyElement(BatchDetailsHeader, "Batch details");
        return new BatchSearchResultsPage(context);
    }
}

