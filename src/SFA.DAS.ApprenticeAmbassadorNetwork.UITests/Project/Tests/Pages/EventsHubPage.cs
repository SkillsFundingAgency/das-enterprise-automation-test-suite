namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages
{
    public class EventsHubPage : SignInPage
    {
        protected override string PageTitle => "Events hub";

        public EventsHubPage(ScenarioContext context) : base(context) => VerifyPage();

        private By FirstEventInCalendarLink = By.CssSelector("a.app-calendar__event:nth-of-type(1)");

        public SearchNetworkEventsPage AccessAllNetworkEvents()
        {
            formCompletionHelper.ClickLinkByText("All network events");
            return new SearchNetworkEventsPage(context);
        }

        public EventPage AccessSignedUpEventFromCalendar()
        {
            formCompletionHelper.ClickElement(FirstEventInCalendarLink);
            return new EventPage(context);
        }

        public bool NoEventsInCalendar()
        {
            try
            {
                // Find the first event in the calendar link
                IWebElement firstEventLink = pageInteractionHelper.FindElement(FirstEventInCalendarLink);

                return false; // Event link found, indicating events in the calendar
            }
            catch (NoSuchElementException)
            {
                return true; // Event link not found, indicating no events in the calendar
            }
        }

    }
}