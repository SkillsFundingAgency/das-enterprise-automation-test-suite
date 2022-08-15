using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.ProviderLogin.Service.Pages;
using SFA.DAS.UI.Framework;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;

namespace SFA.DAS.ProviderLogin.Service.Helpers
{
    public class ProviderHomePageStepsHelper
    {
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabHelper;
        private readonly ProviderConfig _config;
        private readonly ObjectContext _objectContext;
        private readonly ProviderPortalLoginHelper _loginHelper;
        private readonly ProviderLoginUser _login;
        private readonly PortableFlexiJobProviderConfig _pfjConfig;
        private readonly ProviderPortableFlexiJobUser _providerPortableFlexiJobUser;

        public ProviderHomePageStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _tabHelper = _context.Get<TabHelper>();
            _config = context.GetProviderConfig<ProviderConfig>();
            _pfjConfig = context.GetPortableFlexiJobProviderConfig<PortableFlexiJobProviderConfig>();
            _loginHelper = new ProviderPortalLoginHelper(_context);
            _login = new ProviderLoginUser { UserId = _config.UserId, Password = _config.Password, Ukprn = _config.Ukprn };
            _providerPortableFlexiJobUser = new ProviderPortableFlexiJobUser { UserId = _pfjConfig.UserId, Password = _pfjConfig.Password, Ukprn = _pfjConfig.Ukprn };
        }

        public ProviderHomePage GoToProviderHomePage(bool newTab) => GoToProviderHomePage(_login, newTab);

        public ProviderHomePage GoToPortableFlexiJobProviderHomePage(bool newTab) => GoToProviderHomePageForPortableFlexiJobUser(_providerPortableFlexiJobUser, newTab);

        public ProviderHomePage GoToProviderHomePage(ProviderLoginUser login, bool newTab)
        {
            if (newTab) _tabHelper.OpenNewTab();

            _tabHelper.GoToUrl(UrlConfig.Provider_BaseUrl);

            _objectContext.SetUkprn(login.Ukprn);

            return GoToProviderHomePage(login);
        }

        public ProviderHomePage GoToProviderHomePageForPortableFlexiJobUser(ProviderPortableFlexiJobUser login, bool newTab)
        {
            if (newTab) _tabHelper.OpenNewTab();

            _tabHelper.GoToUrl(UrlConfig.Provider_BaseUrl);

            _objectContext.SetUkprn(login.Ukprn);

            return GoToProviderHomePage(login);
        }

        public ProviderHomePage GoToProviderHomePage(ProviderConfig login, bool newTab)
        {
            var loginUser = new ProviderLoginUser { UserId = login.UserId, Password = login.Password, Ukprn = login.Ukprn };

            return GoToProviderHomePage(loginUser, newTab);
        }

        private ProviderHomePage GoToProviderHomePage(ProviderLoginUser login)
        {
            if (_loginHelper.IsSignInPageDisplayed()) return _loginHelper.ReLogin(login);

            if (_loginHelper.IsYourProviderAccountPageDisplayed()) return new ProviderHomePage(_context);

            if (_loginHelper.IsIndexPageDisplayed()) return _loginHelper.Login(login);

            return new ProviderHomePage(_context);
        }

        private ProviderHomePage GoToProviderHomePage(ProviderPortableFlexiJobUser login)
        {
            if (_loginHelper.IsSignInPageDisplayed()) return _loginHelper.ReLogin(login);

            if (_loginHelper.IsYourProviderAccountPageDisplayed()) return new ProviderHomePage(_context);

            if (_loginHelper.IsIndexPageDisplayed()) return _loginHelper.Login(login);

            return new ProviderHomePage(_context);
        }
    }
}