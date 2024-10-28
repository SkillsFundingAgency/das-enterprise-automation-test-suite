using System.Collections.Generic;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;
namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Helpers
{
    public class AanAdminStepsHelper(ScenarioContext context)
    {
        private string EventTitlesKey = "AanAdminStepsHelper.EventTitlesKey";

        protected SucessfullyPublisedEventPage sucessfullyPublisedEventPage;
        public CheckYourEventPage CheckYourEvent(EventFormat eventFormat, bool guestSpeakers, bool isSchoolEvent, string pageTitle = null, string location = null)
        {
            EventOrganiserNamePage eventOrganiserNamePage;
            var page = new InPersonOrOnlinePage(context, SubmitEventDate(eventFormat, guestSpeakers, pageTitle));

            if (eventFormat == EventFormat.Online)
            {
                eventOrganiserNamePage = page.SubmitOnlineDetails();
            }
            else if (eventFormat == EventFormat.InPerson)
            {
                eventOrganiserNamePage = GetEventOrgNamePage(page.SubmitInPersonDetails(location), isSchoolEvent);
            }
            else
            {
                eventOrganiserNamePage = GetEventOrgNamePage(page.SubmitHybridDetails(location), isSchoolEvent);
            }

            return eventOrganiserNamePage.SubmitOrganiserName().SubmitEventAttendees();
        }


        public EventFormat SubmitEventDate(EventFormat eventFormat, bool guestSpeakers, string pageTitle = null)
        {
            EventDatePage eventDatePage;

            var page = new AdminAdministratorHubPage(context)
                .AccessManageEvents()
                .CreateEvent()
                .SubmitEventFormat(eventFormat)
                .SubmitEventTitle(pageTitle)
                .SubmitEventOutline();

            if (guestSpeakers) eventDatePage = page.SubmitGuestSpeakerAsYes().AddAndDeleteGuestSpeakers(5);

            else eventDatePage = page.SubmitGuestSpeakerAsNo();

            eventDatePage.SubmitEventDate();

            return eventFormat;
        }

        public SucessfullyPublisedEventPage SubmitEvent(EventFormat eventFormat, bool guestSpeakers, bool isSchoolEvent)
        {
            return sucessfullyPublisedEventPage = CheckYourEvent(eventFormat, guestSpeakers, isSchoolEvent).GoToEventPreviewPage(eventFormat).GoToCheckYourEventPage().SubmitEvent();
        }

        public static EventOrganiserNamePage GetEventOrgNamePage(IsEventAtSchoolPage isEventAtSchoolPage, bool isSchoolEvent)
        {
            if (isSchoolEvent) return isEventAtSchoolPage.SubmitIsEventAtSchoolAsYes().SubmitSchoolName();

            else return isEventAtSchoolPage.SubmitIsEventAtSchoolAsNo();
        }

        public List<string> GetAllEventTitles()
        {
            if (context.ContainsKey(EventTitlesKey))
            {
                return context.Get<List<string>>(EventTitlesKey);
            }

            var manageEvents = new ManageEventsPage(context);
            var eventTitles = manageEvents.GetEventTitles();

            while (manageEvents.HasNextPage())
            {
                manageEvents.ClickNextPage();
                var titles = manageEvents.GetEventTitles();
                eventTitles.AddRange(titles);
            }

            context.Add(EventTitlesKey, eventTitles);
            return eventTitles;
        }

        public void ClearEventTitleCache()
        {
            if (context.ContainsKey(EventTitlesKey))
            {
                context.Remove(EventTitlesKey);
            }
        }
    }
}
