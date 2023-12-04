using NUnit.Framework;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Admin;

public class Admin_CreateEvent_BaseSteps : Admin_BaseSteps
{

    protected SucessfullyPublisedEventPage sucessfullyPublisedEventPage;

    protected AanAdminCreateEventDatahelper aanAdminDatahelper;

    public Admin_CreateEvent_BaseSteps(ScenarioContext context) : base(context)
    {
        aanAdminDatahelper = context.Get<AanAdminCreateEventDatahelper>();
    }

    protected string AssertEventStatus(bool status)
    {
        string eventTitle = objectContext.GetAanEventTitle();

        var expected = status ? "True" : "False";

        var (id, isActive) = context.Get<AANSqlHelper>().GetEventId(eventTitle);

        Assert.That(isActive, Is.EqualTo(expected), $"'{id}', '{eventTitle}' - event Active status is not set as '{expected}' - Actual : '{isActive}'");

        return id;
    }

    protected SucessfullyPublisedEventPage SubmitInPersonEvent(bool guestSpeakers, bool isSchoolEvent) => SubmitEvent(EventFormat.InPerson, guestSpeakers, isSchoolEvent);

    protected SucessfullyPublisedEventPage SubmitOnlineEvent(bool guestSpeakers) => SubmitEvent(EventFormat.Online, guestSpeakers, false);

    protected SucessfullyPublisedEventPage SubmitHybridEvent(bool guestSpeakers, bool isSchoolEvent) => SubmitEvent(EventFormat.Hybrid, guestSpeakers, isSchoolEvent);

    protected CheckYourEventPage CheckYourEvent(EventFormat eventFormat, bool guestSpeakers, bool isSchoolEvent)
    {
        EventOrganiserNamePage eventOrganiserNamePage;

        var page = new InPersonOrOnlinePage(context, SubmitEventDate(eventFormat, guestSpeakers));

        if (eventFormat == EventFormat.Online) eventOrganiserNamePage = page.SubmitOnlineDetails();

        else if (eventFormat == EventFormat.InPerson) eventOrganiserNamePage = GetEventOrgNamePage(page.SubmitInPersonDetails(), isSchoolEvent);

        else eventOrganiserNamePage = GetEventOrgNamePage(page.SubmitHybridDetails(), isSchoolEvent);

        return eventOrganiserNamePage.SubmitOrganiserName().SubmitEventAttendees();
    }

    private SucessfullyPublisedEventPage SubmitEvent(EventFormat eventFormat, bool guestSpeakers, bool isSchoolEvent)
    {
        return sucessfullyPublisedEventPage = CheckYourEvent(eventFormat, guestSpeakers, isSchoolEvent).GoToEventPreviewPage(eventFormat).GoToCheckYourEventPage().SubmitEvent();
    }

    private static EventOrganiserNamePage GetEventOrgNamePage(IsEventAtSchoolPage isEventAtSchoolPage, bool isSchoolEvent)
    {
        if (isSchoolEvent) return isEventAtSchoolPage.SubmitIsEventAtSchoolAsYes().SubmitSchoolName();

        else return isEventAtSchoolPage.SubmitIsEventAtSchoolAsNo();
    }

    private EventFormat SubmitEventDate(EventFormat eventFormat, bool guestSpeakers)
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
}
