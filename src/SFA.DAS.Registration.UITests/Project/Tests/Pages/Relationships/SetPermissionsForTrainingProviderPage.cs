namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships;

public class SetPermissionsForTrainingProviderPage(ScenarioContext context) : PermissionBasePageForTrainingProviderPage(context)
{
    protected override By PageHeader => By.CssSelector(".govuk-heading-l");

    protected override string PageTitle => $"Set permissions";
}
