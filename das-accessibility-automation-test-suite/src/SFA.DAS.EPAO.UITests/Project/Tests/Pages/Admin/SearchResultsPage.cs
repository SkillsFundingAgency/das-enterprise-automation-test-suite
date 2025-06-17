namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class SearchResultsPage : EPAOAdmin_BasePage
{
    protected override string PageTitle => "Search results";

    private static By ViewLearner => By.CssSelector("tr.govuk-table__row td.govuk-table__cell:first-of-type");

    public SearchResultsPage(ScenarioContext context) : base(context) => VerifyPage();

    public CertificateDetailsPage SelectACertificate()
    {
        formCompletionHelper.ClickElement(ViewLearner);
        return new(context);
    }
}