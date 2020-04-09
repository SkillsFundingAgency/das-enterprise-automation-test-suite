using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ExistingAccountSteps
    {
        private readonly ScenarioContext _context;
        private readonly EmployerPortalLoginHelper _loginhelper;
        private HomePage _homePage;

        public ExistingAccountSteps(ScenarioContext context)
        {
            _context = context;
            _loginhelper = new EmployerPortalLoginHelper(context);
        }

        [Given(@"the Employer logins using existing Levy Account")]
        [When(@"the Employer logins using existing Levy Account")]
        public void GivenTheEmployerLoginsUsingExistingLevyAccount() => _homePage = _loginhelper.Login(_context.GetUser<LevyUser>(), true);

        [When(@"the Employer logins using existing NonLevy Account")]
        public void GivenTheEmployerLoginsUsingExistingNonLevyAccount() => _homePage = _loginhelper.LoginFromCreateAcccountPage(_context.GetUser<NonLevyUser>());

        [Then(@"Employer is able to navigate to all the link under Settings")]
        public void ThenEmployerIsAbleToNavigateToAllTheLinkUnderSettings() => _homePage = _homePage
                .GoToYourAccountsPage().OpenAccount().GoToHomePage()
                .GoToRenameAccountPage().GoToHomePage()
                .GoToChangeYourPasswordPage().NavigateBack()
                .GoToChangeYourEmailAddressPage().NavigateBack()
                .GoToNotificationSettingsPage().NavigateBack();

        [Then(@"Employer is able to navigate to Your saved favourites Page")]
        public void ThenEmployerIsAbleToNavigateToYourSavedFavouritesPage() => _homePage = _homePage.GoToYourSavedFavourites().GoToHomePage();

        [Then(@"Employer is able to navigate to Help Page")]
        public void ThenEmployerIsAbleToNavigateToHelpPage() => _homePage.GoToHelpPage();
    }
}
