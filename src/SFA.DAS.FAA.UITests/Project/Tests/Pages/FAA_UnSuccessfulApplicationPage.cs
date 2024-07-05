namespace SFA.DAS.FAA.UITests.Project.Tests.Pages;

public class FAA_UnSuccessfulApplicationPage(ScenarioContext context) : FAA_ApplicationsPage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-m");

    protected override string PageTitle => "Unsuccessful";
}
