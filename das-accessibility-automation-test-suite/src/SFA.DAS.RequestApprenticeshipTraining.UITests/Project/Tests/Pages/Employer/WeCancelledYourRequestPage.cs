namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.Employer;

public class WeCancelledYourRequestPage(ScenarioContext context) : RatProjectBasePage(context)
{
    protected override string PageTitle => "We've cancelled your request";

    protected override By PageHeader => By.CssSelector(".govuk-panel--confirmation");
}