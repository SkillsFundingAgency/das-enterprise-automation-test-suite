using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Helpers
{
    internal class ProviderPortalLoginHelper : IReLoginHelper
    {
        private readonly ScenarioContext _context;

        internal ProviderPortalLoginHelper(ScenarioContext context) => _context = context;

        public bool IsSignInPageDisplayed() => new CheckProviderSignInPage(_context).IsPageDisplayed();

        public bool IsIndexPageDisplayed() => new CheckProviderIndexPage(_context).IsPageDisplayed();

        public bool IsProviderHomePageDisplayed(string ukprn) => new CheckProviderHomePage(_context).IsPageDisplayed(ukprn);

        public bool IsSelectYourOrganisationDisplayed() => new CheckSelectYourOrganisationPage(_context).IsPageDisplayed();

        internal void StartNow() => new ProviderIndexPage(_context).StartNow();

        internal void SubmitValidLoginDetails(ProviderLoginUser login) => new ProviderSignInPage(_context).SubmitValidLoginDetails(login);

        internal ProviderHomePage SelectOrganisation(ProviderLoginUser login) => new SelectYourOrganisationPage(_context).SelectOrganisation(login.Ukprn);

    }
}
