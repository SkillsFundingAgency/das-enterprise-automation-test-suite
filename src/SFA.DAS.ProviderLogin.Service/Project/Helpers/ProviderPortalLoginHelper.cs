using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Pages;
using SFA.DAS.ProviderLogin.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Helpers
{
    internal class ProviderPortalLoginHelper : IReLoginHelper
    {
        private readonly ScenarioContext _context;

        internal ProviderPortalLoginHelper(ScenarioContext context) => _context = context;

        public bool IsSignInPageDisplayed() => new CheckProviderSignInPage(_context).IsPageDisplayed();

        public bool IsIndexPageDisplayed() => new CheckProviderIndexPage(_context).IsPageDisplayed();

        public bool IsProviderHomePageDisplayed(string ukprn) => new CheckProviderHomePage(_context).IsPageDisplayed(ukprn);

        internal ProviderHomePage ReLogin(ProviderLoginUser login) => Login(new ProviderSiginPage(_context), login);

        internal ProviderHomePage Login(ProviderLoginUser login) => Login(new ProviderIndexPage(_context).StartNow(), login);
        
        private static ProviderHomePage Login(ProviderSiginPage siginPage, ProviderLoginUser login) => siginPage.SubmitValidLoginDetails(login);
    }
}
