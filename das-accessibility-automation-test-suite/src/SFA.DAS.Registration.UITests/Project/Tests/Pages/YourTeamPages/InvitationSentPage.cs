namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.YourTeamPages;

public class InvitationSentPage(ScenarioContext context) : InterimHomeBasePage(context, false)
{
    protected override string PageTitle => "Invitation sent";

    protected override By PageHeader => By.CssSelector(".das-notification__heading");
}
