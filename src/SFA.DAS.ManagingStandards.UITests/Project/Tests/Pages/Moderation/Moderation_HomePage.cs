namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages.Moderation;

public class Moderation_HomePage(ScenarioContext context) : ManagingStandardsBasePage(context)
{
    protected override string PageTitle => "Staff dashboard";

    private static By ProviderModeration => By.CssSelector("a.govuk-link[href*='providermoderation']");

    public Moderation_SearchPage SearchForTrainingProvider()
    {
        formCompletionHelper.ClickElement(ProviderModeration);
        return new Moderation_SearchPage(context);
    }
}
