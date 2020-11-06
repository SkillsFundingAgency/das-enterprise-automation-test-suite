using System;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.UI.Framework;

namespace SFA.DAS.Registration.UITests.Project.Helpers
{
    public class EmployerHomePageStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabHelper;
        private readonly RegistrationConfig _registrationConfig;
        private readonly EmployerPortalLoginHelper _loginHelper;
        private readonly ObjectContext _objectContext;

        public EmployerHomePageStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _tabHelper = _context.Get<TabHelper>();
            _registrationConfig = _context.GetRegistrationConfig<RegistrationConfig>();
            _loginHelper = new EmployerPortalLoginHelper(_context);
        }

        public HomePage GotoEmployerHomePage()
        {
            OpenInNewTab();

            if (_loginHelper.IsIndexPageDisplayed())
            {
                new IndexPage(_context).ClickSignInLinkOnIndexPage();
            }
            
            if (_loginHelper.IsSignInPageDisplayed())
            {
                return _loginHelper.ReLogin();
            }

            if (_loginHelper.IsYourAccountPageDisplayed())
            {
                return new YourAccountsPage(_context)
                    .GoToHomePage(_objectContext.GetOrganisationName());
            }

            return new HomePage(_context);
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

        private void OpenInNewTab() => _tabHelper.OpenInNewTab(UrlConfig.EmployerApprenticeshipService_BaseUrl);
    }
}