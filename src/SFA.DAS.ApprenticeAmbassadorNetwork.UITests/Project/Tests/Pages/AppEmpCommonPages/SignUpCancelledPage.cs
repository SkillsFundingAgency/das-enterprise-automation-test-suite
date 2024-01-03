namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public class SignUpCancelledPage(ScenarioContext context) : AanBasePage(context)
{
    protected override string PageTitle => "You have successfully cancelled your attendance at this event";

    public EventsHubPage AccessEventsHubFromCancelledAttendancePage()
    {
        formCompletionHelper.ClickLinkByText("Events hub");
        return new EventsHubPage(context);
    }
}