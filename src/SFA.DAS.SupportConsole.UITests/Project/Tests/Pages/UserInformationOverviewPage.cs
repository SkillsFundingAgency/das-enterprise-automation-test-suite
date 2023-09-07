namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class UserInformationOverviewPage : SupportConsoleBasePage
{
    protected override string PageTitle => config.Name;

    protected override string AccessibilityPageTitle => "User information overview page";

    protected override By PageHeader => By.CssSelector(".heading-large__equal-margins");

    public UserInformationOverviewPage(ScenarioContext context) : base(context) => VerifyPage();
}