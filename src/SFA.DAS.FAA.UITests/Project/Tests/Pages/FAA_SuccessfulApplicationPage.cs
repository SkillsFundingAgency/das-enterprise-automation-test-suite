namespace SFA.DAS.FAA.UITests.Project.Tests.Pages;

public class FAA_SuccessfulApplicationPage(ScenarioContext context) : FAA_ApplicationsPage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-m");

    protected override string PageTitle => "Successful";
}
