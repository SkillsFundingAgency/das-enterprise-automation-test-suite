namespace SFA.DAS.ManagingStandards.UITests.Project.Tests.Pages.Moderation;

public class Moderation_HomePage : ManagingStandardsBasePage
{
    protected override string PageTitle => "Staff dashboard";

    private static By ProviderModeration => By.CssSelector("a.govuk-link[href*='providermoderation']");

    public Moderation_HomePage(ScenarioContext context) : base(context) { }

    public Moderation_SearchPage SearchForTrainingProvider()
    {
        formCompletionHelper.ClickElement(ProviderModeration);
        return new Moderation_SearchPage(context);
    }
}
