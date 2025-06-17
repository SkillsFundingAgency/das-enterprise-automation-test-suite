namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Tests.Pages.Provider;

public class WeHaveSharedYourDetailsPage(ScenarioContext context) : RatProjectBasePage(context)
{
    protected override string PageTitle => "We've shared your details";

    protected override By PageHeader => By.CssSelector(".govuk-panel--confirmation");
}