using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.ProviderLogin.Service.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Helpers
{
    internal class ProviderPortalLoginHelper : IReLoginHelper
    {
        private readonly ScenarioContext _context;

        internal ProviderPortalLoginHelper(ScenarioContext context)
        {
            _context = context;
        }

        public bool IsSignInPageDisplayed()
        {
            return new CheckProviderSignInPage(_context)
                .IsPageDisplayed();
        }

        public bool IsIndexPageDisplayed()
        {
            return new CheckProviderIndexPage(_context)
                    .IsPageDisplayed();
        }

        internal ProviderHomePage ReLogin(ProviderLoginUser login)
        {
            return Login(new ProviderSiginPage(_context), login);
        }

        internal ProviderHomePage Login(ProviderLoginUser login)
        {
            return Login(new ProviderIndexPage(_context)
                    .StartNow(), login);
        }

        private ProviderHomePage Login(ProviderSiginPage siginPage, ProviderLoginUser login)
        {
            return siginPage.SubmitValidLoginDetails(login);
        }
    }
}
