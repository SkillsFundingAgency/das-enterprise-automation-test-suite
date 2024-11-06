namespace SFA.DAS.FAA.UITests.Project.Tests.Pages;

public class FAASearchApprenticeLandingPage(ScenarioContext context) : FAASignedInLandingBasePage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

    protected override string PageTitle => "Search apprenticeships";
}
