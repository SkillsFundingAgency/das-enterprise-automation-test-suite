using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions;


[Binding]
public class AAN_Events_Steps
{
    private readonly ScenarioContext context;
    private NetworkHubPage networkHubPage;
    private EventPage eventPage;

    public AAN_Events_Steps(ScenarioContext context) => this.context = context;

    [Then(@"the user should be able to successfuly signup for a future event")]
    public void ThenTheUserShouldBeAbleToSuccessfulySignupForAFutureEvent()
    {
        networkHubPage = new NetworkHubPage(context);
        networkHubPage.AccessEventsHub()
             .AccessAllNetworkEvents()
             .FilterEventByTomorrow()
             .ClickOnFirstEventLink()
             .SignupForEvent()
             .AccessEventsHub()
             .AccessSignedUpEventFromCalendar();
    }

    [Then(@"the user should be able to successfuly Cancel the attendance for a signed up event")]
    public void ThenTheUserShouldBeAbleToSuccessfulyCancelTheAttendanceForASignedUpEvent()
    {
        eventPage = new EventPage(context);
        eventPage.CancelYourAttendance()
            .AccessEventsHubFromCancelledAttendancePage()
            .NoEventsInCalendar();
    }
    [Then(@"the user should be able to successfuly filter events by date")]
    public void ThenTheUserShouldBeAbleToSuccessfulyFilterEventsByDate()
    {
        networkHubPage = new NetworkHubPage(context);
        networkHubPage.AccessEventsHub()
             .AccessAllNetworkEvents()
             .FilterEventByOneMonth()
             .ClearAllFilters();
    }

    [Then(@"the user should be able to successfuly filter events by event format")]
    public void EventFormat()
    {
        networkHubPage = new NetworkHubPage(context);
        networkHubPage.AccessEventsHub()
             .AccessAllNetworkEvents()
             .FilterEventByEventType_InPerson()
             .VerifyEventType_Inperson_Filter()
             .ClearAllFilters()
             .FilterEventByEventType_Hybrid()
             .VerifyEventType_Hybrid_Filter()
             .ClearAllFilters()
             .FilterEventByEventType_Online()
             .VerifyEventType_Online_Filter()
             .ClearAllFilters();
    }

    [Then(@"the user should be able to successfuly filter events by event type")]
    public void ThenTheUserShouldBeAbleToSuccessfulyFilterEventsByEventType()
    {

        networkHubPage = new NetworkHubPage(context);
        networkHubPage.AccessEventsHub()
             .AccessAllNetworkEvents()
             .FilterEventByEventType_TrainingEvent()
             .VerifyEventType_TrainingEvent_Filter()
             .ClearAllFilters();
    }

    [Then(@"the user should be able to successfuly filter events by multiple combination of filters")]
    public void ThenTheUserShouldBeAbleToSuccessfulyFilterEventsByMultipleCombinationOfFilters()
    {
        networkHubPage = new NetworkHubPage(context);
        networkHubPage.AccessEventsHub()
             .AccessAllNetworkEvents()
             .FilterEventByEventType_InPerson()
             .VerifyEventType_Inperson_Filter()
             .FilterEventByEventType_Hybrid()
             .VerifyEventType_Hybrid_Filter()
             .FilterEventByEventType_Online()
             .VerifyEventType_Online_Filter()
             .FilterEventByEventType_TrainingEvent()
             .VerifyEventType_TrainingEvent_Filter()
             .FilterEventByOneMonth()
             .ClearAllFilters();

    }
}
