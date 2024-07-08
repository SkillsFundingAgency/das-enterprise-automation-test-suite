namespace SFA.DAS.FAA.UITests.Project.Tests.Pages;

public class FAA_SubmittedApplicationPage(ScenarioContext context) : FAA_ApplicationsPage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-m");

    protected override string PageTitle => "Submitted";
}
