using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.ProviderLogin.Service.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderRolesSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly ProviderHomePageStepsHelper _providerHomePageStepsHelper;

        public ProviderRolesSteps(ScenarioContext context)
        {
            _context = context;
            _providerStepsHelper = new ProviderStepsHelper(_context);
            _providerHomePageStepsHelper = new ProviderHomePageStepsHelper(_context);
        }

        [Given(@"a reservation exists")]
        public void GivenAReservationExists()
        {
            _providerStepsHelper
                .NavigateToProviderHomePage()
                .GoToManageYourFunding()
                .VerifyReservationExists();
        }

        [Then(@"the user can create reservation")]
        public void ThenTheUserCanCreateReservation()
        {
            _providerStepsHelper
                .ProviderMakeReservationThenGotoHomePage();
        }

        [Then(@"the user can delete reservation")]
        public void ThenTheUserCanDeleteReservation()
        {
            _providerStepsHelper
                .ProviderDeleteReservationThenGotoHomePage();
        }

        [Then(@"the user can add an apprentice")]
        public void ThenTheUserCanAddAnApprentice()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .GoToManageYourFunding()
                .AddApprenticeWithReservedFunding();
        }

        [Then(@"the user can not reserve the funding")]
        public void ThenTheUserCannotReserveTheFunding()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .GoToProviderGetFundingGoesToAccessDenied()
                .GoBackToTheServiceHomePage();
        }

        [Then(@"the user can not delete the reservation")]
        public void ThenTheUserCanNotDeleteTheReservation()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .GoToManageYourFunding()
                .DeleteTheReservedFundingGoesToAccessDenied()

                .GoBackToTheServiceHomePage();
        }

        [Then(@"the user can not add an apprentice")]
        public void ThenTheUserCanNotAddAnApprentice()
        {
            //_providerStepsHelper.NavigateToProviderHomePage()
            //    .GoToManageYourFunding()
            //    .AddApprenticeWithReservedFundingGoesToAccessDenied()
            //    .GoBackToTheServiceHomePage();
        }
    }
}
