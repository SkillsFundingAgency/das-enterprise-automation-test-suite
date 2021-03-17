using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
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
        
        private ProviderNotificationSettingsPage _providerNotification;

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
            _providerStepsHelper.NavigateToProviderHomePage()
                .GoToManageYourFunding()
                .AddApprenticeWithReservedFundingGoesToAccessDenied()
                .GoBackToTheServiceHomePage();
        }

        [When(@"the user navigates to notification settings page")]
        public void ProviderNavigatesToNotificationSettingsPage()
        {
            _providerNotification = _providerStepsHelper.NavigateToProviderHomePage()
                .GoToProviderNotificationSettingsPage();
        }

        [Then(@"the user is able to choose to receive notification emails")]
        public void ProviderIsAbleToChooseToReceiveNotificationEmails()
        {
            _providerNotification = _providerNotification.ChooseToReceiveEmails();
            Assert.IsTrue(_providerNotification.IsSettingsUpdated(), $"Choose to receive notification emails success message is not displayed");
        }

        [Then(@"the user is able to choose No notification emails")]
        public void ProviderIsAbleToChooseNoNotificationEmails()
        {
            _providerNotification = _providerNotification.ChooseNotToReceiveEmails();
            Assert.IsTrue(_providerNotification.IsSettingsUpdated(), $"Choose not to receive notification emails success message is not displayed");
        }

        [Then(@"the user can view organisations and agreements")]
        public void ThenTheUserCanViewOrganisationsAndAgreements()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .GoToOrganisationsAndAgreementsPage();
        }

    }
}
