using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin.CreateEvent;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Admin;

[Binding, Scope(Tag = "@aanadmin")]
public class Admin_ChangeEvent_Steps(ScenarioContext context) : Admin_CreateEvent_BaseSteps(context)
{
    private CheckYourEventPage checkYourEventPage;

    [When(@"the user should be able to successfully enters all the details for InPerson event")]
    public void TheUserShouldBeAbleToSuccessfullyEntersAllTheDetailsForInPersonEvent()
    {
        checkYourEventPage = CheckYourEvent(EventFormat.InPerson, false, false);
    }

    [When(@"the user should be able to successfully enters all the details for hybrid event")]
    public void TheUserShouldBeAbleToSuccessfullyEntersAllTheDetailsForHybridEvent()
    {
        checkYourEventPage = CheckYourEvent(EventFormat.Hybrid, false, false);
    }

    [When(@"the user should be able to successfully enters all the details for an Online event")]
    public void TheUserShouldBeAbleToSuccessfullyEntersAllTheDetailsForAnOnlineEvent()
    {
        checkYourEventPage = CheckYourEvent(EventFormat.Online, false, false);
    }

    [When(@"changes the event to a in person event")]
    public void ChangesTheEventToAInPersonEvent() => ChangesTheEventTo(EventFormat.InPerson);

    [When(@"changes the event to a hybrid event")]
    public void ChangesTheEventToAHybridEvent() => ChangesTheEventTo(EventFormat.Hybrid);

    [When(@"changes the event to an online event")]
    public void ChangesTheEventToAnOnlineEvent() => ChangesTheEventTo(EventFormat.Online);

    [When(@"changes all the event details")]
    public void ChangesAllTheEventDetails()
    {
        checkYourEventPage.ChangeEventType().UpdateEventTitle()
            .ChangeEventDateandTime().UpdateEventDate()
            .ChangeEventDescription().UpdateEventOutline()
            .ChangeGuestSpeakers().SubmitGuestSpeakerAsYes().UpdateGuestSpeakers(3)
            .ChangeEventOrganiser().UpdateOrganiserName()
            .ChangeEventSchool().SubmitIsEventAtSchoolAsYes().UpdateSchoolName()
            .ChangeEventAttendees().UpdateEventAttendees();
    }

    private void ChangesTheEventTo(EventFormat eventFormat)
    {
        checkYourEventPage.ChangeEventFormat().ChangeEventFormat(eventFormat);

        sucessfullyPublisedEventPage = new InPersonOrOnlinePage(context, eventFormat).ContinueToCheckYourEventPage(eventFormat).GoToEventPreviewPage(eventFormat).GoToCheckYourEventPage().SubmitEvent();
    }
}
