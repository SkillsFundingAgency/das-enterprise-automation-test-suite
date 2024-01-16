using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Helpers
{
    internal class ProviderPortalLoginHelper : IReLoginHelper
    {
        private readonly ScenarioContext _context;

        internal ProviderPortalLoginHelper(ScenarioContext context) => _context = context;

        public bool IsLandingPageDisplayed() => new CheckProviderLandingPage(_context).IsPageDisplayed();

        public bool IsDfeSignInPageDisplayed() => new CheckDfeSignInPage(_context).IsPageDisplayed();

        public bool IsSelectYourOrganisationDisplayed() => new CheckSelectYourOrganisationPage(_context).IsPageDisplayed();

        public bool IsProviderHomePageDisplayed(string ukprn) => new CheckProviderHomePage(_context).IsPageDisplayed(ukprn);

        internal void StartNow() => new ProviderLandingPage(_context).StartNow();

        internal void SubmitValidLoginDetails(ProviderLoginUser login) => new ProviderDfeSignInPage(_context).SubmitValidLoginDetails(login);

        internal ProviderHomePage SelectOrganisation(ProviderLoginUser login) => new SelectYourOrganisationPage(_context).SelectOrganisation(login.Ukprn);

    }
}
