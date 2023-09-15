using NUnit.Framework;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions;

public abstract class AppEmp_BaseSteps : BaseSteps
{
    private int NoOfeventsFound;

    public AppEmp_BaseSteps(ScenarioContext context) : base(context)
    {

    }

    protected EventPage SignupForAFutureEvent(NetworkHubPage networkHubPage)
    {
        var page = networkHubPage.AccessEventsHub();

        NoOfeventsFound = page.NoOfEventsFoundInCalender();

        return page.AccessAllNetworkEvents()
             .FilterEventByTomorrow()
             .ClickOnFirstEventLink()
             .SignupForEvent()
             .AccessEventsHub()
             .AccessSignedUpEventFromCalendar();
    }

    protected void CancelTheAttendance(EventPage eventPage)
    {
        var actual = eventPage.CancelYourAttendance()
           .AccessEventsHubFromCancelledAttendancePage()
           .NoOfEventsFoundInCalender();

        Assert.That(actual, Is.EqualTo(NoOfeventsFound));
    }

    protected SearchNetworkEventsPage FilterByDate(NetworkHubPage networkHubPage)
    {
        return networkHubPage.AccessEventsHub()
             .AccessAllNetworkEvents()
             .FilterEventByOneMonth()
             .ClearAllFilters();
    }

    protected SearchNetworkEventsPage FilterByEventFormat(SearchNetworkEventsPage searchNetworkEventsPage)
    {
        return searchNetworkEventsPage
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

    protected SearchNetworkEventsPage FilterByEventType(SearchNetworkEventsPage searchNetworkEventsPage)
    {
        return searchNetworkEventsPage
             .FilterEventByEventType_TrainingEvent()
             .VerifyEventType_TrainingEvent_Filter()
             .ClearAllFilters();
    }

    protected SearchNetworkEventsPage FilterByEventRegion(SearchNetworkEventsPage searchNetworkEventsPage)
    {
        return searchNetworkEventsPage
            .FilterEventByEventRegion_London()
            .VerifyEventRegion_London_Filter()
            .ClearAllFilters();
    }

    protected SearchNetworkEventsPage FilterByMultipleCombination(SearchNetworkEventsPage searchNetworkEventsPage)
    {
        return searchNetworkEventsPage
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
