using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.Admin;
using SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.Pages.AppEmpCommonPages;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Tests.StepDefinitions.Admin
{

    [Binding, Scope(Tag = "@aanadmin")]
    public class Admin_RemoveAmbassador_Filter_Steps(ScenarioContext context) : Admin_BaseSteps(context)
    {

        [Given(@"user should be able to cancel or remove the ambassador")]
        public void GivenUserShouldBeAbleToCancelOrRemoveTheAmbassador()
        {
            new AdminAdministratorHubPage(context)
                 .AccessManageAmbassadors()
                .AcessMember()
                .RemoveAmbassador()
                .SelectReasonsToRemoveAndCancelRemoval();
        }


        [Then(@"the user should be able to successfully filter ambassadors by status")]
        public void ThenTheUserShouldBeAbleToSuccessfullyFilterAmbassadorsByStatus()
        {
            new AdminAdministratorHubPage(context)
                .AccessManageAmbassadors()
                .FilterAmbassadorByStatus_New()
                .VerifyAMbassadorStatus_Published_New()
                .ClearAllFilters()
                .FilterEventByAmbassadorStatus_Active()
                .VerifyAMbassadorStatus_Published_Active()
                .ClearAllFilters();
        }


        [Then(@"the user should be able to successfully filter ambassadors by regions")]
        public void ThenTheUserShouldBeAbleToSuccessfullyFilterAmbassadorsByRegions()
        {
             new ManageAmbassadorsPage(context)
                .FilterEventByEventRegion_London()
                .VerifyEventRegion_London_Filter()
                .ClearAllFilters();
        }


        [Then(@"the user should be able to successfully filter ambassadors by multiple combination of filters")]
        public void ThenTheUserShouldBeAbleTosuccessfullyFilterAmbassadorsByMultipleCombinationOfFilters()
        {
            new ManageAmbassadorsPage(context)
                 .FilterAmbassadorByStatus_New()
                 .FilterEventByAmbassadorStatus_Active()
                 .FilterEventByEventRegion_London()
                 .VerifyAMbassadorStatus_Published_New()
                 .VerifyAMbassadorStatus_Published_Active()
                 .VerifyEventRegion_London_Filter()
                 .ClearAllFilters();
        }
    }
}