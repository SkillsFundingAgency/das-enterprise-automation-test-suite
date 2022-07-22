using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework;
using SFA.DAS.Login.Service.Project.Helpers;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class EmployerHomePageStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabHelper;
        private readonly EmployerPortalLoginHelper _loginHelper;
        private readonly ObjectContext _objectContext;

        public EmployerHomePageStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _tabHelper = _context.Get<TabHelper>();
            _loginHelper = new EmployerPortalLoginHelper(_context);
        }

        public HomePage Login(EasAccountUser loginUser) => _loginHelper.Login(loginUser, true);

        public HomePage GotoEmployerHomePage(bool openInNewTab = true)
        {
            GoToEmployerLoginPage(openInNewTab);

            if (_loginHelper.IsSignInPageDisplayed())
            {
                return _loginHelper.ReLogin();
            }

            if (_loginHelper.IsYourAccountPageDisplayed())
            {
                return new YourAccountsPage(_context)
                    .GoToHomePage(_objectContext.GetOrganisationName());
            }

            return new HomePage(_context, !openInNewTab);
        }

        public SignInPage ValidateUnsuccessfulLogon(bool openInNewTab = true)
        {
            GoToEmployerLoginPage(openInNewTab);

            if (_loginHelper.IsSignInPageDisplayed())
            {
                return _loginHelper.FailedLogin();
            }

            return new SignInPage(_context);
        }

        public MyAccountWithOutPayePage GotoEmployerHomePage(MyAccountWithOutPayeLoginHelper loginHelper)
        {
            OpenInNewTab();

            if (loginHelper.IsSignInPageDisplayed())
            {
                return loginHelper.ReLogin();
            }

            return new MyAccountWithOutPayePage(_context);
        }

        public void OpenInNewTab() => _tabHelper.OpenInNewTab(UrlConfig.EmployerApprenticeshipService_BaseUrl);

        private void GoToEmployerLoginPage(bool openInNewTab)
        {
            if (openInNewTab)
            {
                OpenInNewTab();
            }

            if (_loginHelper.IsIndexPageDisplayed())
            {
                new CreateAnAccountToManageApprenticeshipsPage(_context).ClickSignInLinkOnIndexPage();
            }
        }
    
    
    
    }
}