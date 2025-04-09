using SFA.DAS.RAAProvider.UITests.Project.Helpers;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAAProvider.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class NavigationSteps(ScenarioContext context)
    {
        private readonly RecruitmentProviderHomePageStepsHelper _recruitmentProviderHomePageStepsHelper = new(context);

        [Given(@"the Provider navigates to 'Recruit' Page")]
        [When(@"the Provider navigates to 'Recruit' Page")]
        public void WhenTheProviderNavigatesToPage() => _recruitmentProviderHomePageStepsHelper.GoToRecruitmentProviderHomePage(true);


        [Then("the Provider can navigate to Reports page")]
        public void ThenTheProviderCanNavigateToReportsPage() => _recruitmentProviderHomePageStepsHelper.GoToReportsPage();


        [Then("the Provider can navigate to Manage your recruitment emails page")]
        public void ThenTheProviderCanNavigateToManageYourRecruitmentEmailsPage() => _recruitmentProviderHomePageStepsHelper.GoToManageYourRecruitmentEmailsPage();


        [Then("the Provider can navigate to apprentice requests page")]
        public void ThenTheProviderCanNavigateToApprenticeRequestsPage() => _recruitmentProviderHomePageStepsHelper.GoToApprenticeRequestsPage();


        [Then(@"the Provider can navigate to manage funding page")]
        public void ThenTheProviderCanNavigateToManageFundingPage() => _recruitmentProviderHomePageStepsHelper.GoToManageFundingPage();


        [Then("the Provider can navigate to manage your apprentices page")]
        public void ThenTheProviderCanNavigateToManageYourApprenticesPage() => _recruitmentProviderHomePageStepsHelper.GoToManageYourApprenticesPage();


        [Then("the Provider can navigate to organisations and agreements page")]
        public void ThenTheProviderCanNavigateToOrganisationsAndAgreementsPage() => _recruitmentProviderHomePageStepsHelper.GoToOrganisationsAndAgreementsPage();

        
        [Then("the Provider can navigate to recruit notification settings page")]
        public void ThenTheProviderCanNavigateToRecruitNotificationSettingsPage() => _recruitmentProviderHomePageStepsHelper.GoToNotificationsViaSettingsPage();


        [Then("the Provider can navigate to change your sign in details settings page")]
        public void ThenTheProviderCanNavigateToChangeYourSignInDetailsSettingsPage() => _recruitmentProviderHomePageStepsHelper.GoToChangeYourSignInDetailsPage();
    }
}
