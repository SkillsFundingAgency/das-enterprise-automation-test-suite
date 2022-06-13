namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin;

public class SearchResultsPage : EPAOAdmin_BasePage
{
    protected override string PageTitle => "Search results";

    private static By ViewLearner => By.CssSelector(".govuk-link[href*='/select']");

    public SearchResultsPage(ScenarioContext context) : base(context) => VerifyPage();

    public CertificateDetailsPage SelectACertificate()
    {
        formCompletionHelper.ClickElement(ViewLearner);
        return new(context);
    }
}
