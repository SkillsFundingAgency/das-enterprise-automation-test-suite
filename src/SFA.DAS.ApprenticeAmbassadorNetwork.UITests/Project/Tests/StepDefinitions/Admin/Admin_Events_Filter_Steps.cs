using FluentAssertions;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Models;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Admin
{

    [Binding, Scope(Tag = "@aanadmin")]
    public class Admin_Events_Filter_Steps(ScenarioContext context) : Admin_BaseSteps(context)
    {
        private ManageEventsPage manageEventsPage;

        [Then(@"the user should be able to successfully filter events by date")]
        public void TheUserShouldBeAbleToSuccessfullyFilterEventsByDate()
        {
            manageEventsPage = new AdminAdministratorHubPage(context).AccessManageEvents();

            manageEventsPage.FilterEventByOneMonth().ClearAllFilters();
        }

        [Then(@"the user should be able to successfully filter events by event status")]
        public void ThenTheUserShouldBeAbleToSuccessfullyFilterEventsByEventStatus()
        {
            manageEventsPage = manageEventsPage
                .FilterEventByEventStatus_Published()
                .VerifyEventStatus_Published_Filter()
                .ClearAllFilters()
                .FilterEventByEventStatus_Cancelled()
                .VerifyEventStatus_Cancelled_Filter()
                .ClearAllFilters();
        }

        [Then(@"the user should be able to successfully filter events by event type")]
        public void ThenTheUserShouldBeAbleTosuccessfullyFilterEventsByEventType()
        {
            manageEventsPage = manageEventsPage
                 .FilterEventByEventType_TrainingEvent()
                 .VerifyEventType_TrainingEvent_Filter()
                 .ClearAllFilters();
        }

        [Then(@"the user should be able to successfully filter events by regions")]
        public void ThenTheUserShouldBeAbleToSuccessfullyFilterEventsByRegions()
        {
            manageEventsPage = manageEventsPage
                .FilterEventByEventRegion_London()
                .VerifyEventRegion_London_Filter()
                .ClearAllFilters();
        }


        [Then(@"the user should be able to successfully filter events by multiple combination of filters")]
        public void ThenTheUserShouldBeAbleTosuccessfullyFilterEventsByMultipleCombinationOfFilters()
        {
            manageEventsPage = manageEventsPage
                 .FilterEventByOneMonth()
                 .FilterEventByEventStatus_Published()
                 .FilterEventByEventType_TrainingEvent()
                 .FilterEventByEventRegion_London()
                 .VerifyEventStatus_Published_Filter()
                 .VerifyEventType_TrainingEvent_Filter()
                 .VerifyEventRegion_London_Filter()
                 .ClearAllFilters();

        }

        [Given(@"the following events have been created:")]
        public void GivenTheFollowingEventsHaveBeenCreated(Table table)
        {
            var stepsHelper = context.Get<AanAdminStepsHelper>();

            var events = table.CreateSet<NetworkEvent>().ToList();

            foreach(var e in events)
            {
                var confirmationPage = stepsHelper.CheckYourEvent(EventFormat.InPerson, false, false, e.EventTitle, e.Location).SubmitEvent();
                confirmationPage.AccessHub();
            };
        }

        [When(@"the user filters events within (.*) miles of ""([^""]*)""")]
        public void WhenTheUserFiltersEventsWithinMilesOf(int p0, string location)
        {
            var hub = new AdminAdministratorHubPage(context);
            var manageEvents = hub.AccessManageEvents();
            manageEvents.FilterEventsByLocation(location);

            var stepsHelper = context.Get<AanAdminStepsHelper>();
            stepsHelper.ClearEventTitleCache();
        }

        [Then(@"the following events can be found within the search results:")]
        public void ThenTheFollowingEventsCanBeFoundWithinTheSearchResults(Table table)
        {
            var stepsHelper = context.Get<AanAdminStepsHelper>();
            var titles = stepsHelper.GetAllEventTitles();

            var expectedEvents = table.CreateSet<NetworkEvent>().ToList();

            foreach (var expected in expectedEvents)
            {
                titles.Should().Contain(expected.EventTitle);
            }
        }

        [Then(@"the following events can not be found within the search results:")]
        public void ThenTheFollowingEventsCanNotBeFoundWithingTheSearchResults(Table table)
        {
            var stepsHelper = context.Get<AanAdminStepsHelper>();
            var titles = stepsHelper.GetAllEventTitles();

            var unexpectedEvents = table.CreateSet<NetworkEvent>().ToList();

            foreach (var unexpected in unexpectedEvents)
            {
                titles.Should().NotContain(unexpected.EventTitle);
            }
        }

        [Then(@"the event search results should include '([^']*)'")]
        public void ThenTheEventSearchResultsShouldInclude(string expected)
        {
            var stepsHelper = context.Get<AanAdminStepsHelper>();
            var titles = stepsHelper.GetAllEventTitles();

            titles.Should().Contain(expected);
        }

        [Then(@"the event search results should not include '([^']*)'")]
        public void ThenTheEventSearchResultsShouldNotInclude(string expected)
        {
            var stepsHelper = context.Get<AanAdminStepsHelper>();
            var titles = stepsHelper.GetAllEventTitles();

            titles.Should().NotContain(expected);
        }
    }
}