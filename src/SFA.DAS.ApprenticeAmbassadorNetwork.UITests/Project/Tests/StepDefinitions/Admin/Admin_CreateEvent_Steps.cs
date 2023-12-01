using NUnit.Framework;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Admin;

[Binding, Scope(Tag = "@aanadmin")]
public class Admin_CreateEvent_Steps : Admin_BaseSteps
{
    private SucessfullyPublisedEventPage sucessfullyPublisedEventPage;
    private AanAdminDatahelper aanAdminDatahelper;

    public Admin_CreateEvent_Steps(ScenarioContext context) : base(context)
    {

    }

    [When(@"the user should be able to successfully create hybrid school event")]
    public void TheUserShouldBeAbleToSuccessfullyCreateHybridSchoolEvent() => SubmitHybridEvent(true, true);

    [When(@"the user should be able to successfully create hybrid event")]
    public void TheUserShouldBeAbleToSuccessfullyCreateHybridEvent() => SubmitHybridEvent(false, false);

    [When(@"the user should be able to successfully create inperson event")]
    public void TheUserShouldBeAbleToSuccessfullyCreateInpersonEvent() => SubmitInPersonEvent(true, false);

    [When(@"the user should be able to successfully create inperson school event")]
    public void TheUserShouldBeAbleToSuccessfullyCreateInpersonSchoolEvent() => SubmitInPersonEvent(false, true);

    [When(@"the user should be able to successfully create online event")]
    public void TheUserShouldBeAbleToSuccessfullyCreateOnlineEvent() => SubmitOnlineEvent(true);

    [Then(@"the system should confirm the event creation")]
    public void TheSystemShouldConfirmTheEventCreation()
    {
        aanAdminDatahelper = context.Get<AanAdminDatahelper>();

        SetAanAdminEventId(AssertEventStatus(true));
    }

    [Then(@"the user should be able to successfully cancel event")]
    public void TheUserShouldBeAbleToSuccessfullyCancelEvent()
    {
        sucessfullyPublisedEventPage.AccessManageEvents().FilterEventBy(aanAdminDatahelper).CancelEvent().CancelEvent();
    }

    [Then(@"the system should confirm the event cancellation")]
    public void TheSystemShouldConfirmTheEventCancellation() => AssertEventStatus(false);

    private string AssertEventStatus(bool status)
    {
        var expected = status ? "True" : "False";

        var (id, isActive) = context.Get<AANSqlHelper>().GetEventId(GetEventTitle());

        Assert.That(isActive, Is.EqualTo(expected), $"'{id}', '{GetEventTitle()}' - event Active status is not set as '{expected}' - Actual : '{isActive}'");

        return id;
    }

    private string GetEventTitle() => aanAdminDatahelper.EventTitle;

    private void SetAanAdminEventId(string id ) => objectContext.SetAanAdminEventId(id);

    private SucessfullyPublisedEventPage SubmitInPersonEvent(bool guestSpeakers, bool isSchoolEvent) => SubmitEvent(EventFormat.InPerson, guestSpeakers, isSchoolEvent);

    private SucessfullyPublisedEventPage SubmitOnlineEvent(bool guestSpeakers) => SubmitEvent(EventFormat.Online, guestSpeakers, false);

    private SucessfullyPublisedEventPage SubmitHybridEvent(bool guestSpeakers, bool isSchoolEvent) => SubmitEvent(EventFormat.Hybrid, guestSpeakers, isSchoolEvent);

    private SucessfullyPublisedEventPage SubmitEvent(EventFormat eventFormat, bool guestSpeakers, bool isSchoolEvent)
    {
        return sucessfullyPublisedEventPage = CheckYourEvent(eventFormat, guestSpeakers, isSchoolEvent).GoToEventPreviewPage(eventFormat).GoToCheckYourEventPage().SubmitEvent();
    }

    private CheckYourEventPage CheckYourEvent(EventFormat eventFormat, bool guestSpeakers, bool isSchoolEvent)
    {
        EventOrganiserNamePage eventOrganiserNamePage;

        var page = new InPersonOrOnlinePage(context, SubmitEventDate(eventFormat, guestSpeakers));

        if (eventFormat == EventFormat.Online) eventOrganiserNamePage = page.SubmitOnlineDetails();

        else if (eventFormat == EventFormat.InPerson) eventOrganiserNamePage = GetEventOrgNamePage(page.SubmitInPersonDetails(), isSchoolEvent);

        else eventOrganiserNamePage = GetEventOrgNamePage(page.SubmitHybridDetails(), isSchoolEvent);

        return eventOrganiserNamePage.SubmitOrganiserName().SubmitEventAttendees();
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