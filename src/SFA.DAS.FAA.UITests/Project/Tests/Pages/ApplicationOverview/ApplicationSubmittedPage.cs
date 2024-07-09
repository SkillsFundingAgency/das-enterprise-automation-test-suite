using SFA.DAS.FAA.UITests.Project.Tests.Pages;

namespace SFA.DAS.FAA.UITests.Project.Pages.ApplicationOverview;

public class ApplicationSubmittedPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Application submitted";

    protected override By PageHeader => By.CssSelector(".govuk-panel--confirmation");
}

