using SFA.DAS.Login.Service.Project.Helpers;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Apprentice;


[Binding, Scope(Tag = "@aanaprentice")]
public class Apprentice_Events_Steps : Apprentice_BaseSteps
{
    public Apprentice_Events_Steps(ScenarioContext context) : base(context) { }

    [Given(@"an onboarded apprentice logs into the AAN portal")]
    public void AnOnboardedApprenticeLogsIntoTheAANPortal()
    {
        networkHubPage = GetSignInPage().SubmitUserDetails_OnboardingJourneyComplete(context.Get<AanApprenticeOnBoardedUser>());
    }

    [Then(@"the user should be able to successfully signup for a future event")]
    public void ThenTheUserShouldBeAbleTosuccessfullySignupForAFutureEvent()
    {
        eventPage = networkHubPage.AccessEventsHub()
             .AccessAllNetworkEvents()
             .FilterEventByTomorrow()
             .ClickOnFirstEventLink()
             .SignupForEvent()
             .AccessEventsHub()
             .AccessSignedUpEventFromCalendar();
    }

    [Then(@"the user should be able to successfully Cancel the attendance for a signed up event")]
    public void ThenTheUserShouldBeAbleTosuccessfullyCancelTheAttendanceForASignedUpEvent()
    {
        eventPage.CancelYourAttendance()
            .AccessEventsHubFromCancelledAttendancePage()
            .NoEventsInCalendar();
    }
    [Then(@"the user should be able to successfully filter events by date")]
    public void ThenTheUserShouldBeAbleTosuccessfullyFilterEventsByDate()
    {
        searchNetworkEventsPage = networkHubPage.AccessEventsHub()
             .AccessAllNetworkEvents()
             .FilterEventByOneMonth()
             .ClearAllFilters();
    }

    [Then(@"the user should be able to successfully filter events by event format")]
    public void EventFormat()
    {
        searchNetworkEventsPage = searchNetworkEventsPage
             .FilterEventByEventFormat_InPerson()
             .VerifyEventFormat_Inperson_Filter()
             .ClearAllFilters()
             .FilterEventByEventFormat_Hybrid()
             .VerifyEventFormat_Hybrid_Filter()
             .ClearAllFilters()
             .FilterEventByEventFormat_Online()
             .VerifyEventFormat_Online_Filter()
             .ClearAllFilters();
    }

    [Then(@"the user should be able to successfully filter events by event type")]
    public void ThenTheUserShouldBeAbleTosuccessfullyFilterEventsByEventType()
    {
        searchNetworkEventsPage = searchNetworkEventsPage
             .FilterEventByEventType_TrainingEvent()
             .VerifyEventType_TrainingEvent_Filter()
             .ClearAllFilters();
    }

    [Then(@"the user should be able to successfully filter events by regions")]
    public void ThenTheUserShouldBeAbleToSuccessfullyFilterEventsByRegions()
    {
        searchNetworkEventsPage = searchNetworkEventsPage
            .FilterEventByEventRegion_London()
            .VerifyEventRegion_London_Filter()
            .ClearAllFilters();
    }

    [Then(@"the user should be able to successfully filter events by multiple combination of filters")]
    public void ThenTheUserShouldBeAbleTosuccessfullyFilterEventsByMultipleCombinationOfFilters()
    {
        searchNetworkEventsPage = searchNetworkEventsPage
             .FilterEventByOneMonth()
             .FilterEventByEventFormat_InPerson()
             .FilterEventByEventFormat_Hybrid()
             .FilterEventByEventFormat_Online()
             .FilterEventByEventType_TrainingEvent()
             .FilterEventByEventRegion_London()
             .VerifyEventFormat_Inperson_Filter()
             .VerifyEventFormat_Hybrid_Filter()
             .VerifyEventFormat_Online_Filter()
             .VerifyEventType_TrainingEvent_Filter()
             .VerifyEventRegion_London_Filter()
             .ClearAllFilters();

    }
}
