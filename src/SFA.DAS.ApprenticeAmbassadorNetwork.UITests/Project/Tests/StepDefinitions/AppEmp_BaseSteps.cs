using NUnit.Framework;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;
using System;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions;

public abstract class AppEmp_BaseSteps : BaseSteps
{
    private (string id, DateTime startdate) Event;

    public AppEmp_BaseSteps(ScenarioContext context) : base(context)
    {

    }

    protected EventsHubPage SignupForAFutureEvent(NetworkHubPage networkHubPage)
    {
        var page = networkHubPage.AccessEventsHub();

        Event = _aanSqlHelper.GetNextEventStartDate();

        return page.AccessAllNetworkEvents()
             .ClickOnFirstEventLink(Event.startdate)
             .SignupForEvent()
             .AccessEventsHub();
    }

    protected void CancelTheAttendance(EventsHubPage eventsHubPage)
    {
        var page = eventsHubPage.GoToEventMonth(Event.startdate);

        var NoOfeventsFound = page.NoOfEventsFoundInCalender();

        var actual = page.AccessSignedUpEventFromCalendar(Event.startdate).CancelYourAttendance()
           .AccessEventsHubFromCancelledAttendancePage()
           .GoToEventMonth(Event.startdate)
           .NoOfEventsFoundInCalender();

        Assert.That(actual, Is.EqualTo(NoOfeventsFound - 1));
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

    protected NetworkDirectoryPage FilterByEventRegionNetworkDirectory(NetworkDirectoryPage networkDirectoryPage)
    {
        return networkDirectoryPage.FilterEventByEventRegion_London()
            .VerifyEventRegion_London_Filter()
            .ClearAllFilters();
    }
    protected NetworkDirectoryPage FilterByEventRoleNetworkDirectory(NetworkHubPage networkHubPage)
    {
        return networkHubPage.AccessNetworkDirectory()
            .FilterByRole_Apprentice()
            .VerifyRole_Apprentice_Filter()
            .ClearAllFilters()
            .FilterByRole_Employer()
            .VerifyRole_Employer_Filter()
            .ClearAllFilters()
            .FilterByRole_Regionalchair()
            .VerifyRole_Regionalchair_Filter()
            .ClearAllFilters();
    }
    protected NetworkDirectoryPage FilterByMultipleCombination_NetworkCirectory(NetworkDirectoryPage networkDirectoryPage)
    {
        return networkDirectoryPage
            .FilterEventByEventRegion_London()
            .FilterByRole_Apprentice()
            .FilterByRole_Regionalchair()
            .FilterByRole_Employer()
            .VerifyEventRegion_London_Filter()
            .VerifyRole_Apprentice_Filter()
            .VerifyRole_Employer_Filter()
            .VerifyRole_Regionalchair_Filter()
            .ClearAllFilters();
    }
}
