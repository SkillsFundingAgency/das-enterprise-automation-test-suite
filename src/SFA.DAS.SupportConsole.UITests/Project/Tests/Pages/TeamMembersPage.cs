namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages;

public class TeamMembersPage : SupportConsoleBasePage
{
    protected override string PageTitle => "Team members";

    protected override By PageHeader => By.CssSelector(".heading-xlarge");

    private static By TeamMembersTable => By.CssSelector("table.responsive");

    private static By NameLink => By.CssSelector("[id='Name'] a");

    public TeamMembersPage(ScenarioContext context) : base(context)
    {
        MultipleVerifyPage(
        [
            () => VerifyPage(),
            () => VerifyPage(TeamMembersTable)
        ]);
    }

    public UserInformationOverviewPage GoToUserInformationOverviewPage()
    {
        formCompletionHelper.ClickElement(() => tableRowHelper.GetColumn(config.EmailAddress, NameLink));

        return new(context);
    }
}