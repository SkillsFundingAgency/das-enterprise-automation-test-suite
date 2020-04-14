using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.ProviderLogin.Service.Pages;
using SFA.DAS.Login.Service.Helpers;

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
        private readonly string _providerUrl;

        public ProviderHomePageStepsHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _tabHelper = _context.Get<TabHelper>();
            _config = context.GetProviderConfig<ProviderConfig>();
            _providerUrl = _config.ProviderBaseUrl;
            _loginHelper = new ProviderPortalLoginHelper(_context);
            _login = new ProviderLoginUser { Username = _config.UserId, Password = _config.Password, Ukprn = _config.Ukprn };
        }

        public ProviderHomePage GoToProviderHomePage(bool newTab)
        {
            return GoToProviderHomePage(_login, newTab);
        } 

        public ProviderHomePage GoToProviderHomePageInNewTab()
        {
            return GoToProviderHomePage(_login, true);
        }

        public ProviderHomePage GoToProviderHomePage(ProviderLoginUser login, bool newTab)
        {
            if (newTab)
            {
                _tabHelper.OpenInNewTab(_providerUrl);
            }
            else
            {
                _tabHelper.GoToUrl(_providerUrl);
            }

            _objectContext.SetUkprn(login.Ukprn);

            if (_loginHelper.IsSignInPageDisplayed())
            {
                return _loginHelper.ReLogin(login);
            }
            else if (_loginHelper.IsIndexPageDisplayed())
            {
                return _loginHelper.Login(login);
            }
            return new ProviderHomePage   (_context);
        }
    }
}
