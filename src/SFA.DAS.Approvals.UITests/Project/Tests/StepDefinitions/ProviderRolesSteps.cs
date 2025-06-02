using NUnit.Framework;
using SFA.DAS.Approvals.UITests.Project.Helpers.StepsHelper.Provider;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ProviderRolesSteps
    {
        private readonly ScenarioContext _context;
        private readonly ProviderStepsHelper _providerStepsHelper;
        private readonly ProviderReservationStepsHelper _providerReservationStepsHelper;

        private ProviderNotificationSettingsPage _providerNotification;

        public ProviderRolesSteps(ScenarioContext context)
        {
            _context = context;
            _providerStepsHelper = new ProviderStepsHelper(_context);
            _providerReservationStepsHelper = new ProviderReservationStepsHelper(_context);
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
        public void ThenTheUserCanCreateReservation() => _providerReservationStepsHelper.ProviderMakeReservation(new ApprovalsProviderHomePage(_context)).GoToHomePage();

        [Then(@"the user can delete reservation")]
        public void ThenTheUserCanDeleteReservation() => _providerStepsHelper.NavigateToProviderHomePage()
                .GoToManageYourFunding()
                .DeleteTheReservedFunding()
                .YesDeleteThisReservation()
                .GoToHomePage();

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

        [Then(@"user can access Notification Settings page")]
        public void UserCanAccessNotificationSettingsPage()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .GoToProviderNotificationSettingsPage().ClickCancel();
        }

        [Then(@"user can access Orgs And Agreements page")]
        public void UserCanAccessProviderOrganisationsAndAgreementsPage()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .GoToProviderEmployersAndPermissionsPagePage()
                .GoToProviderHomePage();
        }

        [Then(@"user can access Help page")]
        public void UserCanAccessHelpPage()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .GoToManageApprenticeshipsServiceHelpPage()
                .GoToProviderHomePage();
        }

        [Then(@"user can access Feedback page")]
        public void UserCanAccessFeedbackPage()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .VerifyProviderFooterFeedbackPage();
        }

        [Then(@"user can access Privacy Statement page")]
        public void UserCanAccessPrivacyStatementPage()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .GoToProviderFooterPrivacyPage()
                .GoToProviderHomePage();
        }

        [Then(@"user can access Cookies page")]
        public void UserCanAccessCookiesPage()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .GoToProviderFooterCookiesPage()
                .GoToProviderHomePage();
        }

        [Then(@"user can access Terms Of Use page")]
        public void UserCanAccessTermsOfUsePage()
        {
            _providerStepsHelper.NavigateToProviderHomePage()
                .GoToProviderFooterTermsOfUsePage()
                .GoToProviderHomePage();
        }

        [Then(@"user can signout from their account")]
        public void UserCanSignoutFromTheirAccount()
        {
            _providerStepsHelper.NavigateToProviderHomePage().SignsOut();
        }

        [Then(@"user can view Add New Apprentices page as defined in the table below (.*)")]
        public void UserCanOrCannotViewAddNewApprenticesPageAsDefinedInTable(bool canAccess)
        {
            if (canAccess)
                _providerStepsHelper.NavigateToProviderHomePage().GotoSelectJourneyPage();
            else
                _providerStepsHelper.NavigateToProviderHomePage()
                    .GotoSelectJourneyPageGoesToAccessDenied()
                    .GoBackToTheServiceHomePage();
        }

        [Then(@"user can view Add An Employer page as defined in the table below (.*)")]
        public void UserCanOrCannotViewAddAnEmployerPageAsDefinedInTable(bool canAccess)
        {
            if (canAccess)
                _providerStepsHelper.NavigateToProviderHomePage().GotoAddNewEmployerStartPage();
            else
                _providerStepsHelper.NavigateToProviderHomePage()
                    .GotoAddNewEmployerStartPageGoesToAccessDenied()
                    .NavigateBrowserBack();
        }

        [Then(@"user can view Get Funding For NonLevy Employers page as defined in the table below (.*)")]
        public void UserCanOrCannotViewGetFundingNonLevyEmployersPageAsDefinedInTable(bool canAccess)
        {
            if (canAccess)
                _providerStepsHelper.NavigateToProviderHomePage().GoToProviderGetFunding();
            else
                _providerStepsHelper.NavigateToProviderHomePage()
                    .GoToProviderGetFundingGoesToAccessDenied()
                    .NavigateBrowserBack();
        }

        [Then(@"user can view View Employers And Manage Permissions page")]
        public void UserCanViewEmployersAndManagePermissionsPage()
        {
            _providerStepsHelper.NavigateToProviderHomePage().GotoViewEmpAndManagePermissionsPage();
        }

        [Then(@"user can view Apprentice Requests page")]
        public void UserCanViewApprenticeRequestsPage()
        {
            _providerStepsHelper.NavigateToProviderHomePage().GoToApprenticeRequestsPage();
        }

        [Then(@"user can view Manage Your Funding Reserved For NonLevy Employers page")]
        public void UserCanViewManageYourFundingReservedForNonLevyEmployersPage()
        {
            _providerStepsHelper.NavigateToProviderHomePage().GoToManageYourFunding();
        }

        [Then(@"user can view Manage Your Apprentices page")]
        public void UserCanViewManageYourApprenticesPage()
        {
            _providerStepsHelper.NavigateToProviderHomePage().GoToProviderManageYourApprenticePage();
        }

        [Then(@"user can view Recruit Apprentices page")]
        public void UserCanViewRecruitApprenticesPage()
        {
            _providerStepsHelper.NavigateToProviderHomePage().GoToProviderRecruitApprenticesHomePage();
        }

        [Then(@"user can view Your Standards And Training Venues page")]
        public void UserCanViewYourStandardsAndTrainingVenuesPage()
        {
            _providerStepsHelper.NavigateToProviderHomePage().NavigateToYourStandardsAndTrainingVenuesPage();
        }

        [Then(@"user can view Developer APIs page as defined in the table below (.*)")]
        public void UserCanViewDeveloperAPIsPage(bool canAccess)
        {
            if (canAccess) 
            _providerStepsHelper.NavigateToProviderHomePage().NavigateToDeveloperAPIsPage();
            else
                _providerStepsHelper.NavigateToProviderHomePage()
                    .NavigateToDeveloperAPIsPageGoesToApimAccessDenied()
                    .GoBackToTheServiceHomePage();
        }

        [Then(@"user can view Your Feedback page")]
        public void UserCanViewYourFeedbackPage()
        {
            _providerStepsHelper.NavigateToProviderHomePage().NavigateToYourFeedback();
        }

        [Then(@"user can view View Employer Requests For Training page")]
        public void UserCanViewEmployerRequestsForTrainingPage()
        {
            _providerStepsHelper.NavigateToProviderHomePage().NavigateToViewEmployerRequestsForTrainingPage();
        }
    }
}
