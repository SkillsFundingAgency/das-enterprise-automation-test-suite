namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public class EventsHubPage : AanBasePage
{
    protected override string PageTitle => "Events hub";

    public EventsHubPage(ScenarioContext context) : base(context) => VerifyPage();

    private static By EventInCalendarLinkSelector => By.CssSelector("a.app-calendar__event");

    public SearchNetworkEventsPage AccessAllNetworkEvents()
    {
        formCompletionHelper.ClickLinkByText("All network events");
        return new SearchNetworkEventsPage(context);
    }

    public EventPage AccessSignedUpEventFromCalendar()
    {
        formCompletionHelper.ClickElement(EventInCalendarLinkSelector);
        return new EventPage(context);
    }

    public int NoOfEventsFoundInCalender() => pageInteractionHelper.FindElements(EventInCalendarLinkSelector).ToList().Count;
}