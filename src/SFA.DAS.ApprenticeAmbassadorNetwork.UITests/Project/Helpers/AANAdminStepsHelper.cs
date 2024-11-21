using System.Collections.Generic;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Models;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;
namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Helpers
{
    public class AanAdminStepsHelper(ScenarioContext context)
    {
        private readonly SharedStepsHelper _sharedStepsHelper = new(context);

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

        public static EventOrganiserNamePage GetEventOrgNamePage(IsEventAtSchoolPage isEventAtSchoolPage, bool isSchoolEvent)
        {
            if (isSchoolEvent) return isEventAtSchoolPage.SubmitIsEventAtSchoolAsYes().SubmitSchoolName();

            else return isEventAtSchoolPage.SubmitIsEventAtSchoolAsNo();
        }

        public List<NetworkEventSearchResult> GetAllSearchResults()
        {
            var manageEvents = new ManageEventsPage(context);
            return _sharedStepsHelper.GetAllSearchResults(manageEvents);
        }

        public void ClearEventTitleCache() => _sharedStepsHelper.ClearSearchResultsCache();
    }
}
