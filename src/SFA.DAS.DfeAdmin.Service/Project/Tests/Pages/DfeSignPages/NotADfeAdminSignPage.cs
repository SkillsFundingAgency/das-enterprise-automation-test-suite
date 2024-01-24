namespace SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.DfeSignPages;

public class NotADfeAdminSignPage(ScenarioContext context) : NotADfeSignPage(context)
{
    protected override By Identifier => By.CssSelector($"{PageHeaderSelector}, {DfeAfterSignIdentifiers.Reviewer_HomePageIdentifierCss}, {DfeAfterSignIdentifiers.SupportConsole_HomePageidentifierCss}");
}
