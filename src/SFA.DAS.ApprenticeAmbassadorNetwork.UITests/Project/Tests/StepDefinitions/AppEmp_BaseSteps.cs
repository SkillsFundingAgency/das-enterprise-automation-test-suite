using NUnit.Framework;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions;

public abstract class AppEmp_BaseSteps : BaseSteps
{
    private EventPage eventPage;

    private SearchNetworkEventsPage searchNetworkEventsPage;

    private int NoOfeventsFound;

    private NetworkHubPage networkHubPage;

    public AppEmp_BaseSteps(ScenarioContext context) : base(context)
    {

    }

    protected void SignupForAFutureEvent(NetworkHubPage networkHubPage)
    {
        this.networkHubPage = networkHubPage;

        var page = networkHubPage.AccessEventsHub();

        NoOfeventsFound = page.NoOfEventsFoundInCalender();

        eventPage = page.AccessAllNetworkEvents()
             .FilterEventByTomorrow()
             .ClickOnFirstEventLink()
             .SignupForEvent()
             .AccessEventsHub()
             .AccessSignedUpEventFromCalendar();
    }

    protected void CancelTheAttendance()
    {
        var actual = eventPage.CancelYourAttendance()
           .AccessEventsHubFromCancelledAttendancePage()
           .NoOfEventsFoundInCalender();

        Assert.That(actual, Is.LessThan(NoOfeventsFound));
    }

    protected void FilterByDate()
    {
        searchNetworkEventsPage = networkHubPage.AccessEventsHub()
             .AccessAllNetworkEvents()
             .FilterEventByOneMonth()
             .ClearAllFilters();
    }

    protected void FilterByEventFormat()
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

    protected void FilterByEventType()
    {
        searchNetworkEventsPage = searchNetworkEventsPage
             .FilterEventByEventType_TrainingEvent()
             .VerifyEventType_TrainingEvent_Filter()
             .ClearAllFilters();
    }

    protected void FilterByEventRegion()
    {
        searchNetworkEventsPage = searchNetworkEventsPage
            .FilterEventByEventRegion_London()
            .VerifyEventRegion_London_Filter()
            .ClearAllFilters();
    }

    protected void FilterByMultipleCombination()
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
