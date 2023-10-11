using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Admin;

[Binding, Scope(Tag = "@aanadmin")]
public class Admin_CreateEvent_Steps : Admin_BaseSteps
{
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
    public void TheUserShouldBeAbleToSuccessfullyCreateInpersonSchoolEvent() => SubmitInPersonEvent(true, true);

    [When(@"the user should be able to successfully create online event")]
    public void TheUserShouldBeAbleToSuccessfullyCreateOnlineEvent() => SubmitOnlineEvent(true);

    [Then(@"the system should confirm the event creation")]
    public void TheSystemShouldConfirmTheEventCreation()
    {
        var data = context.Get<AanAdminDatahelper>();

        var id = context.Get<AANSqlHelper>().GetEventId(data.EventTitle);

        objectContext.SetAanAdminEventId(id);
    }

    private void SubmitInPersonEvent(bool guestSpeakers, bool isSchoolEvent) => SubmitEvent(EventFormat.InPerson, guestSpeakers, isSchoolEvent);

    private void SubmitOnlineEvent(bool guestSpeakers) => SubmitEvent(EventFormat.Online, guestSpeakers, false);

    private void SubmitHybridEvent(bool guestSpeakers, bool isSchoolEvent) => SubmitEvent(EventFormat.Hybrid, guestSpeakers, isSchoolEvent);

    private void SubmitEvent(EventFormat eventFormat, bool guestSpeakers, bool isSchoolEvent)
    {
        EventOrganiserNamePage eventOrganiserNamePage;

        var page = new InPersonOrOnlinePage(context, SubmitEventDate(eventFormat, guestSpeakers));

        if (eventFormat == EventFormat.Online) eventOrganiserNamePage = page.SubmitOnlineDetails();

        else if (eventFormat == EventFormat.InPerson) eventOrganiserNamePage = GetEventOrgNamePage(page.SubmitInPersonDetails(), isSchoolEvent);

        else eventOrganiserNamePage = GetEventOrgNamePage(page.SubmitHybridDetails(), isSchoolEvent);

        eventOrganiserNamePage.SubmitOrganiserName().SubmitEventAttendees().SubmitEvent();
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