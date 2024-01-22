using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages.DfeSignPages;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Helpers
{
    internal class ProviderPortalLoginHelper : IReLoginHelper
    {
        private readonly ScenarioContext _context;

        private readonly ProviderLoginUser providerLoginUser;

        internal ProviderPortalLoginHelper(ScenarioContext context, ProviderLoginUser user) { _context = context; providerLoginUser = user; }

        public bool IsLandingPageDisplayed() => new CheckProviderLandingPage(_context).IsPageDisplayed();

        public bool IsSignInPageDisplayed() => new CheckDfeSignInPage(_context).IsPageDisplayed();

        internal void ClickStartNow() { if (IsLandingPageDisplayed()) new ProviderLandingPage(_context).ClickStartNow(); }

        internal void SubmitValidLoginDetails() { if (IsSignInPageDisplayed()) new ProviderDfeSignInPage(_context).SubmitValidLoginDetails(providerLoginUser); }

        internal ProviderHomePage GoToProviderHomePage()
        {
            SubmitValidLoginDetails();

            if (new CheckSelectYourOrgOrProviderHomePage(_context, providerLoginUser.Ukprn).IsSelectYourOrganisationDisplayed())
            {
                new SelectYourOrganisationPage(_context).SelectOrganisation(providerLoginUser.Ukprn);
            }

            return new ProviderHomePage(_context);
        }
    }
}
