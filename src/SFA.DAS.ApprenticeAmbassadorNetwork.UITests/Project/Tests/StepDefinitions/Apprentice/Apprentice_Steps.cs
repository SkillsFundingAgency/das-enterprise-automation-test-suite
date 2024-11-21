using FluentAssertions;
using NUnit.Framework;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Models;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;
using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.DfeSignPages;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.Login.Service.Project.Helpers;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Apprentice;

[Binding, Scope(Tag = "@aanaprentice")]
public class Apprentice_Steps(ScenarioContext context) : Apprentice_BaseSteps(context)
{
    private SearchNetworkEventsPage searchNetworkEventsPage;

    private EventsHubPage eventsHubPage;

    private AanApprenticeOnBoardedUser user;

    [Given(@"an onboarded apprentice logs into the AAN portal")]
    [When(@"an onboarded apprentice logs into the AAN portal")]
    public void AnOnboardedApprenticeLogsIntoTheAANPortal() => networkHubPage =
        SubmitUserDetails_OnboardingJourneyComplete(user = context.Get<AanApprenticeOnBoardedUser>());

    [Then(@"the user should be able to successfully verify a regional chair member profile")]
    public void VerifyRegionalChairMemberProfile() => AccessNetworkDirectory(true);

    [Then(@"the user should be able to successfully verify an apprentice member profile")]
    public void VerifyApprenticeMemberProfile() => AccessNetworkDirectory(false);

    private void AccessNetworkDirectory(bool isRegionalChair) =>
        AccessNetworkDirectory(networkHubPage, isRegionalChair, user.Username);

    [Then(
        @"the user should be able to (ask for industry advice|ask for help with a network activity|request a case study|get in touch after meeting at a network event) to an apprentice member successfully")]
    public void TheUserShouldBeAbleToAskAnApprenticeMemberSuccessfully(string message) =>
        SendApprenticeMessage(networkDirectoryPage, Apprentice, message);

    [Then(
        @"the user should be able to (ask for industry advice|ask for help with a network activity|request a case study|get in touch after meeting at a network event) to a regional chair member successfully")]
    public void TheUserShouldBeAbleToAskARegionalChairMemberSuccessfully(string message) =>
        SendRegionalChairMessage(networkDirectoryPage, Apprentice, message);

    [When(@"the user should be able to successfully verify ambassador profile")]
    public void VerifyYourAmbassadorProfile() => VerifyYourAmbassadorProfile(networkHubPage, user.Username);

    [Then(@"the user should be able to update profile information")]
    public void ThenTheUserShouldBeAbleToUpdateProfileInformation() => new YourAmbassadorProfilePage(context)
        .AccessChangeForPersonalDetails()
        .ChangePersonalDetailsAndContinue()
        .AccessChangeForInterestInNetwork()
        .SelectProjectManagementAndContinue()
        .AccessChangeForApprenticeshipInformation()
        .ChangeSeconLineAddressAndContinue()
        .AccessChangeForContactDetails()
        .ChangeLinkedlnUrlAndContinue();

    [When(@"the user should be able to successfully hide ambassador profile information")]
    public void WhenTheUserShouldBeAbleToSuccessfullyHideAmbassadorProfileInformation() =>
        AccessYourAmbassadorProfile(networkHubPage)
            .AccessChangeForPersonalDetails()
            .HideJobtitleAndBiography()
            .AccessChangeForApprenticeshipInformation()
            .HideApprenticeshipInformation()
            .AccessChangeForContactDetails()
            .HideLinkedlnInformation();

    [Then(@"the user should be able to successfully display ambassador profile information")]
    public void ThenTheUserShouldBeAbleToSuccessfullyDisplayAmbassadorProfileInformation() =>
        new YourAmbassadorProfilePage(context)
            .AccessChangeForPersonalDetails()
            .DisplayJobtitleAndBiography()
            .AccessChangeForApprenticeshipInformation()
            .DisplayApprenticeshipInformation()
            .AccessChangeForContactDetails()
            .DisplayLinkedlnInformation();


    [Then(@"the user should be able to successfully signup for a future event")]
    public void SignupForAFutureEvent() => eventsHubPage = SignupForAFutureEvent(networkHubPage, user.Username);

    [Then(@"the user should be able to successfully Cancel the attendance for a signed up event")]
    public void CancelTheAttendance() => CancelTheAttendance(eventsHubPage);

    [Then(@"the user should be able to successfully filter events by date")]
    public void FilterByDate() => searchNetworkEventsPage = FilterByDate(networkHubPage);

    [Then(@"the user should be able to successfully filter events by event format")]
    public void FilterByEventFormat() => FilterByEventFormat(searchNetworkEventsPage);

    [Then(@"the user should be able to successfully filter events by event type")]
    public void FilterByEventType() => FilterByEventType(searchNetworkEventsPage);

    [Then(@"the user should be able to successfully filter events by multiple combination of filters")]
    public void FilterByMultipleCombination() => FilterByMultipleCombination(searchNetworkEventsPage);

    [Then(@"the user should be able to successfully filter events by role Network Directory")]
    public void FilterByRole_NetworkDirectory() =>
        networkDirectoryPage = FilterByEventRoleNetworkDirectory(networkHubPage);

    [Then(@"the user should be able to successfully filter events by regions Network Directory")]
    public void FilterByEventRegion_NetworkDirectory() => FilterByEventRegionNetworkDirectory(networkDirectoryPage);

    [Then(@"the user should be able to successfully filter events by multiple combination of filters Network Directory")]
    public void FilterByMultipleCombination_NetworkDirectory() =>
        FilterByMultipleCombinationNetworkDirectory(networkDirectoryPage);

    [Given(@"the following events have been created:")]
    public void GivenTheFollowingEventsHaveBeenCreated(Table table)
    {
        var tabHelper = context.Get<TabHelper>();
        tabHelper.GoToUrl(UrlConfig.AAN_Admin_BaseUrl);

        var user = context.GetUser<AanAdminUser>();

        new DfeSignInPage(context).SubmitValidLoginDetails(user);

        var stepsHelper = context.Get<AanAdminStepsHelper>();

        var events = table.CreateSet<NetworkEventWithLocation>().ToList();

        foreach (var e in events)
        {
            var confirmationPage = stepsHelper
                .CheckYourEvent(EventFormat.InPerson, false, false, e.EventTitle, e.Location).SubmitEvent();
            confirmationPage.AccessHub();
        }

        ;

        tabHelper.GoToUrl(UrlConfig.AAN_Apprentice_BaseUrl);
    }

    [When(@"the user filters events within (.*) miles of ""([^""]*)""")]
    public void WhenTheUserFiltersEventsWithinMilesOf(int radius, string location)
    {
        var searchNetworkEventsPage = networkHubPage.AccessEventsHub()
            .AccessAllNetworkEvents();

        searchNetworkEventsPage.EnterKeywordFilter("Location Filter Apprentice Test Event");
        
        searchNetworkEventsPage.FilterEventsByLocation(location, radius);

        var stepsHelper = context.Get<ApprenticeStepsHelper>();
        stepsHelper.ClearEventTitleCache();
    }

    [When(@"the user filters events Across England centered on ""([^""]*)""")]
    public void WhenTheUserFiltersEventsAcrossEnglandCenteredOn(string location)
    {
        var searchNetworkEventsPage = new SearchNetworkEventsPage(context);

        searchNetworkEventsPage.EnterKeywordFilter("Location Filter Apprentice Test Event");
        searchNetworkEventsPage.FilterEventsByLocation(location, 0);

        var stepsHelper = context.Get<ApprenticeStepsHelper>();
        stepsHelper.ClearEventTitleCache();
    }


    [Then(@"the following events can be found within the search results:")]
    public void ThenTheFollowingEventsCanBeFoundWithinTheSearchResults(Table table)
    {
        var stepsHelper = context.Get<ApprenticeStepsHelper>();
        var titles = stepsHelper.GetAllSearchResults().Select(x => x.EventTitle).ToList();

        var expectedEvents = table.CreateSet<NetworkEvent>().ToList();

        foreach (var expected in expectedEvents)
        {
            titles.Should().Contain(expected.EventTitle);
        }
    }

    [Then(@"the following events can not be found within the search results:")]
    public void ThenTheFollowingEventsCanNotBeFoundWithinTheSearchResults(Table table)
    {
        var stepsHelper = context.Get<ApprenticeStepsHelper>();
        var titles = stepsHelper.GetAllSearchResults().Select(x => x.EventTitle).ToList();

        var unexpectedEvents = table.CreateSet<NetworkEvent>().ToList();

        foreach (var unexpected in unexpectedEvents)
        {
            titles.Should().NotContain(unexpected.EventTitle);
        }
    }

    [When(@"the user orders the results by Closest")]
    public void WhenTheUserOrdersTheResultsByClosest()
    {
        var searchNetworkEventsPage = new SearchNetworkEventsPage(context);
        searchNetworkEventsPage.SelectOrderByClosest();
    }

    [Then(@"the following events can be found within the search results in the given order:")]
    public void ThenTheFollowingEventsCanBeFoundWithinTheSearchResultsInTheGivenOrder(Table table)
    {
        var stepsHelper = context.Get<ApprenticeStepsHelper>();
        var eventSearchResults = stepsHelper.GetAllSearchResults();
        var expectedEvents = table.CreateSet<NetworkEventWithOrdinal>().OrderBy(e => e.Order).ToList();

        var filteredSearchResults = eventSearchResults
            .Where(x => expectedEvents.Select(y => y.EventTitle).Contains(x.EventTitle))
            .OrderBy(x => x.Index)
            .ToList();
        
        for (var i = 0; i < expectedEvents.Count; i++)
        {
            var expectedEvent = expectedEvents[i];
            var actualEvent = filteredSearchResults.ElementAtOrDefault(i);

            Assert.NotNull(actualEvent, $"Expected event with index {i} was not found.");
            Assert.AreEqual(expectedEvent.EventTitle, actualEvent.EventTitle, $"Event at index {i + 1} does not match the expected title.");
        }
    }

    [Then(@"the heading text ""([^""]*)"" is displayed")]
    public void ThenTheHeadingTextIsDisplayed(string expectedText)
    {
        searchNetworkEventsPage = new SearchNetworkEventsPage(context);
        searchNetworkEventsPage.VerifyHeadingText(expectedText);
    }

    [Then(@"the text ""([^""]*)"" is displayed")]
    public void ThenTheTextIsDisplayed(string expectedText)
    {
        searchNetworkEventsPage = new SearchNetworkEventsPage(context);
        searchNetworkEventsPage.VerifyBodyText(expectedText);
    }

    [When(@"the user navigates to Network Events")]
    public void WhenTheUserNavigatesToNetworkEvents()
    {
        searchNetworkEventsPage = networkHubPage.AccessEventsHub().AccessAllNetworkEvents();
    }

    [When(@"the user filters events by Cancelled status")]
    public void WhenTheFiltersEventsByCancelledEventType()
    {
        searchNetworkEventsPage = new SearchNetworkEventsPage(context);
        searchNetworkEventsPage.FilterEventByEventStatus_Cancelled();
    }

    [When(@"the user filters events by Training event type")]
    public void WhenTheUserFiltersEventsByTrainingEventType()
    {
        searchNetworkEventsPage = new SearchNetworkEventsPage(context);
        searchNetworkEventsPage.FilterEventByEventType_TrainingEvent();
    }

    [When(@"the user filters events so that there are no results")]
    public void WhenTheUserFiltersEventsSoThatThereAreNoResults()
    {
        searchNetworkEventsPage = new SearchNetworkEventsPage(context);
        searchNetworkEventsPage.FilterEventsWithNoResults();
    }
}