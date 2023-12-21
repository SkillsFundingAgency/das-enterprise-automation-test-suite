using NUnit.Framework;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;
using System;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions;

public abstract class AppEmp_BaseSteps(ScenarioContext context) : BaseSteps(context)
{
    private (string id, DateTime startdate) Event;

    protected NetworkDirectoryPage networkDirectoryPage;

    protected (string id, string FullName) Apprentice;

    protected void AccessNetworkDirectory(NetworkHubPage networkHubPage, bool isRegionalChair, string email)
    {
        string x = isRegionalChair ? "is" : "is not";

        networkDirectoryPage = networkHubPage.AccessNetworkDirectory();

        Apprentice = _aanSqlHelper.GetLiveApprenticeDetails(isRegionalChair, email);

        Assert.That(!string.IsNullOrEmpty(Apprentice.id), $"No member found who '{x} regional chair' and email is not '{email}', use the sql query in test data attachment to debug the test");
    }

    protected static NetworkDirectoryPage SendRegionalChairMessage(NetworkDirectoryPage networkDirectoryPage, (string id, string fullname) apprentice, string message)
    {
        return SendMessage(networkDirectoryPage, true, apprentice, message);
    }

    protected static NetworkDirectoryPage SendApprenticeMessage(NetworkDirectoryPage networkDirectoryPage, (string id, string fullname) apprentice, string message)
    {
        return SendMessage(networkDirectoryPage, false, apprentice, message);
    }

    private static NetworkDirectoryPage SendMessage(NetworkDirectoryPage networkDirectoryPage, bool isRegionalChair, (string id, string fullname) apprentice, string message)
    {
        return networkDirectoryPage.GoToApprenticeMessagePage(isRegionalChair)
           .GoToApprenticeMessagePage(apprentice)
           .SendMessage(message)
           .AccessNetworkDirectory();
    }

    protected static void VerifyYourAmbassadorProfile(NetworkHubPage networkHubPage, string value)
    {
        networkHubPage.AccessProfileSettings().AccessYourAmbassadorProfile().VerifyYourAmbassadorProfile(value);
    }

    protected EventsHubPage SignupForAFutureEvent(NetworkHubPage networkHubPage, string email)
    {
        var page = networkHubPage.AccessEventsHub();

        Event = _aanSqlHelper.GetNextActiveEventDetails(email);

        return page.AccessAllNetworkEvents()
             .ClickOnFirstEvent()
             .GoToEvent(Event)
             .SignupForEvent()
             .AccessEventsHub();
    }

    protected void CancelTheAttendance(EventsHubPage eventsHubPage)
    {
        var page = eventsHubPage.GoToEventMonth(Event.startdate);

        var NoOfeventsFound = page.NoOfEventsFoundInCalender();

        var actual = page.AccessFirstEventFromCalendar().GoToEvent(Event).CancelYourAttendance()
           .AccessEventsHubFromCancelledAttendancePage()
           .GoToEventMonth(Event.startdate)
           .NoOfEventsFoundInCalender();

        Assert.That(actual, Is.EqualTo(NoOfeventsFound - 1));
    }

    protected static SearchNetworkEventsPage FilterByDate(NetworkHubPage networkHubPage)
    {
        return networkHubPage.AccessEventsHub()
             .AccessAllNetworkEvents()
             .FilterEventByOneMonth()
             .ClearAllFilters();
    }

    protected static SearchNetworkEventsPage FilterByEventFormat(SearchNetworkEventsPage searchNetworkEventsPage)
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

    protected static SearchNetworkEventsPage FilterByEventType(SearchNetworkEventsPage searchNetworkEventsPage)
    {
        return searchNetworkEventsPage
             .FilterEventByEventType_TrainingEvent()
             .VerifyEventType_TrainingEvent_Filter()
             .ClearAllFilters();
    }

    protected static SearchNetworkEventsPage FilterByEventRegion(SearchNetworkEventsPage searchNetworkEventsPage)
    {
        return searchNetworkEventsPage
            .FilterEventByEventRegion_London()
            .VerifyEventRegion_London_Filter()
            .ClearAllFilters();
    }

    protected static SearchNetworkEventsPage FilterByMultipleCombination(SearchNetworkEventsPage searchNetworkEventsPage)
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

    protected static NetworkDirectoryPage FilterByEventRegionNetworkDirectory(NetworkDirectoryPage networkDirectoryPage)
    {
        return networkDirectoryPage.FilterEventByEventRegion_London()
            .VerifyEventRegion_London_Filter()
            .ClearAllFilters();
    }
    protected static NetworkDirectoryPage FilterByEventRoleNetworkDirectory(NetworkHubPage networkHubPage)
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
    protected static NetworkDirectoryPage FilterByMultipleCombinationNetworkDirectory(NetworkDirectoryPage networkDirectoryPage)
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
