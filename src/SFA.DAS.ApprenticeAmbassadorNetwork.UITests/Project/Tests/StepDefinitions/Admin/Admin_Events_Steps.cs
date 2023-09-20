using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;
using SFA.DAS.EsfaAdmin.Service.Project;
using SFA.DAS.EsfaAdmin.Service.Project.Helpers;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Admin
{

    [Binding, Scope(Tag = "@aanadmin")]
    public class Admin_Events_Steps : Admin_BaseSteps
    {
        private AdminAdministratorHubPage adminAdministratorHubPage;

        private ManageEventsPage manageEventsPage;

        private readonly EsfaAdminLoginStepsHelper _esfaAdminLoginStepsHelper;

        public Admin_Events_Steps(ScenarioContext context) : base(context)
        {
            _esfaAdminLoginStepsHelper = new EsfaAdminLoginStepsHelper(context);
        }

        [Given(@"an admin logs into the AAN portal")]
        public void AnAdminLogsIntoTheAANPortal() => SubmitValidLoginDetails(context.GetAanEsfaAdminConfig<AanEsfaAdminConfig>());

        [Given(@"a super admin logs into the AAN portal")]
        public void ASuperAdminLogsIntoTheAANPortal() => SubmitValidLoginDetails(context.GetAanEsfaSuperAdminConfig<AanEsfaSuperAdminConfig>());

        [Then(@"the user should be able to successfully filter events by date")]
        public void TheUserShouldBeAbleToSuccessfullyFilterEventsByDate()
        {
            manageEventsPage = adminAdministratorHubPage.AccessManageEvents();

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

        private AdminAdministratorHubPage SubmitValidLoginDetails(EsfaAdminConfig config)
        {
            _esfaAdminLoginStepsHelper.SubmitValidLoginDetails(config);

            return adminAdministratorHubPage = new AdminAdministratorHubPage(context);
        }
    }
}