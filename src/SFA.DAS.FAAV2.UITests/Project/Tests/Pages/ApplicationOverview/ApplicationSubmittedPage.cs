using SFA.DAS.FAAV2.UITests.Project.Tests.Pages;

namespace SFA.DAS.FAAV2.UITests.Project.Pages.ApplicationOverview;

public class ApplicationSubmittedPage(ScenarioContext context) : FAABasePage(context)
{
    protected override string PageTitle => "Application submitted";

    protected override By PageHeader => By.CssSelector(".govuk-panel--confirmation");
}

