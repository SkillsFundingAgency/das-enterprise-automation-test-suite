using System;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

public class EventsHubPage : AanBasePage
{
    protected override string PageTitle => "Events hub";

    public EventsHubPage(ScenarioContext context) : base(context) => VerifyPage();

    private static By EventInCalendarLinkSelector => By.CssSelector("a.app-calendar__event");

    private static By EventMonth => By.CssSelector(".app-calendar__row .govuk-heading-s");

    private static By NextMonth => By.CssSelector(".app-calendar__row .app-calendar-nav__next");

    public SearchNetworkEventsPage AccessAllNetworkEvents()
    {
        formCompletionHelper.ClickLinkByText("All network events");
        return new SearchNetworkEventsPage(context);
    }

    public EventsHubPage GoToEventMonth(DateTime date)
    {
        static string ToEventMonthFormat(DateTime date) => date.ToString("MMMM yyyy");

        for (int i = 0; i < 5; i++)
        {
            var eventMonth = pageInteractionHelper.GetText(EventMonth);

            if (eventMonth == ToEventMonthFormat(date))
            {
                break;
            }

            formCompletionHelper.Click(NextMonth);

            pageInteractionHelper.WaitForElementToChange(EventMonth, AttributeHelper.InnerText, ToEventMonthFormat(DateTime.Now.AddMonths(i + 1)));
        }

        return new EventsHubPage(context);
    }

    public EventPage AccessFirstEventFromCalendar()
    {
        formCompletionHelper.ClickElement(EventInCalendarLinkSelector);

        return new EventPage(context);
    }

    public int NoOfEventsFoundInCalender() => pageInteractionHelper.FindElements(EventInCalendarLinkSelector).ToList().Count;
}