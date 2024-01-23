using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class EmployerHomePageStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly EmployerPortalLoginHelper _loginHelper;
        private readonly ObjectContext _objectContext;

        public EmployerHomePageStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _loginHelper = new EmployerPortalLoginHelper(_context);
        }

        public HomePage Login(EasAccountUser loginUser) => _loginHelper.Login(loginUser, true);

        public HomePage GotoEmployerHomePage(bool openInNewTab = true)
        {
            GoToEmployerLoginPage(openInNewTab);

            if (_loginHelper.IsSignInPageDisplayed())
                return _loginHelper.ReLogin();

            if (_loginHelper.IsYourAccountPageDisplayed())
                return new YourAccountsPage(_context).GoToHomePage(_objectContext.GetOrganisationName());

            return new HomePage(_context, !openInNewTab);
        }

        public CreateYourEmployerAccountPage GoToCreateYourEmployerAccountPage()
        {
            GoToEmployerLoginPage(true);
            return new CreateYourEmployerAccountPage(_context);
        }

        public AccountUnavailablePage ValidateUnsuccessfulLogon()
        {
            GoToEmployerLoginPage(true);

            if (_loginHelper.IsSignInPageDisplayed()) return _loginHelper.FailedLogin1();

            return new AccountUnavailablePage(_context);
        }

        public void NavigateToEmployerApprenticeshipService() => GetTabHelper().GoToUrl(EmployerApprenticeshipService_BaseUrl);

        private void OpenInNewTab() => GetTabHelper().OpenInNewTab(EmployerApprenticeshipService_BaseUrl);

        private void GoToEmployerLoginPage(bool openInNewTab)
        {
            if (openInNewTab) OpenInNewTab();

            if (_loginHelper.IsLandingPageDisplayed()) new CreateAnAccountToManageApprenticeshipsPage(_context).GoToStubSignInPage();
        }

        private static string EmployerApprenticeshipService_BaseUrl => UrlConfig.EmployerApprenticeshipService_BaseUrl;

        private TabHelper GetTabHelper() => _context.Get<TabHelper>();
    }
}