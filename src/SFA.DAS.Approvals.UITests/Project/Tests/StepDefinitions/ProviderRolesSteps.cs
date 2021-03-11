using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderRolesSteps
    {
        private readonly ProviderStepsHelper _providerStepsHelper;
        
        public ProviderRolesSteps(ScenarioContext context) => _providerStepsHelper = new ProviderStepsHelper(context);

        [Then(@"the user can create reservation")]
        public void ThenTheUserCanCreateReservation()
        {
            _providerStepsHelper.MakeReservation();                  
        }

        [Given(@"the user can delete reservation")]
        public void GivenTheUserCanDeleteReservation()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .GoToManageYourFunding()
                .DeleteTheReservedFunding()
                .YesDeleteThisReservation();
        }

        [Then(@"the user can add an apprentice")]
        public void ThenTheUserCanAddAnApprentice()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .GoToManageYourFunding()
                .AddApprenticeWithReservedFunding();
        }

        [Then(@"the user can not reserve the funding")]
        public void ThenTheUserCanNotReserveTheFunding()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .ClickToReserveFunding()
                .GoBackToTheServiceHomePage();
        }

 
        [Then(@"the user can not delete the reservation")]
        public void ThenTheUserCanNotDeleteTheReservation()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .GoToManageYourFunding()
                .ClickToDeleteReservation()
                .GoBackToTheServiceHomePage();
        }

        [Then(@"the user can not add an apprentice")]
        public void ThenTheUserCanNotAddAnApprentice()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .GoToManageYourFunding()
                .ClickToAddAnApprenticeForaReservation()
                .GoBackToTheServiceHomePage();
        }
    }
}
