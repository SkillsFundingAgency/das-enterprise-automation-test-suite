using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;
namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Helpers
{
    public class AanAdminStepsHelper(ScenarioContext context)
    {
        protected SucessfullyPublisedEventPage sucessfullyPublisedEventPage;

        public CheckYourEventPage CheckYourEvent(EventFormat eventFormat, bool guestSpeakers, bool isSchoolEvent)
        {
            EventOrganiserNamePage eventOrganiserNamePage;

            var page = new InPersonOrOnlinePage(context, SubmitEventDate(eventFormat, guestSpeakers));

            if (eventFormat == EventFormat.Online) eventOrganiserNamePage = page.SubmitOnlineDetails();

            else if (eventFormat == EventFormat.InPerson) eventOrganiserNamePage = GetEventOrgNamePage(page.SubmitInPersonDetails(), isSchoolEvent);

            else eventOrganiserNamePage = GetEventOrgNamePage(page.SubmitHybridDetails(), isSchoolEvent);

            return eventOrganiserNamePage.SubmitOrganiserName().SubmitEventAttendees();
        }

        public EventFormat SubmitEventDate(EventFormat eventFormat, bool guestSpeakers)
        {
            EventDatePage eventDatePage;

            var page = new AdminAdministratorHubPage(context)
                .AccessManageEvents()
                .CreateEvent()
                .SubmitEventFormat(eventFormat)
                .SubmitEventTitle()
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
    }
}
