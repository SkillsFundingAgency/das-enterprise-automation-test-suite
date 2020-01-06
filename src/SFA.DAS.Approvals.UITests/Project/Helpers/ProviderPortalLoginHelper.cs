using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using SFA.DAS.Login.Service;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public class ProviderPortalLoginHelper : IReLoginHelper
    {
        private readonly ScenarioContext _context;

        public ProviderPortalLoginHelper(ScenarioContext context)
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

        public ProviderHomePage ReLogin(ProviderLogin login)
        {
            return Login(new ProviderSiginPage(_context), login);
        }

        public ProviderHomePage Login(ProviderLogin login)
        {
            return Login(new ProviderIndexPage(_context)
                    .StartNow(), login);
        }

        public ProviderHomePage Login(ProviderSiginPage siginPage, ProviderLogin login)
        {
            return siginPage.SubmitValidLoginDetails(login);
        }
    }
}
