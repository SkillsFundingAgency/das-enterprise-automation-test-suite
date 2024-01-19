using OpenQA.Selenium;
using SFA.DAS.DfeAdmin.Service.Project.Tests.Pages;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.ProviderLogin.Service.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport.CheckPage;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Helpers
{
    internal class ProviderPortalLoginHelper : IReLoginHelper
    {
        private readonly ScenarioContext _context;

        internal ProviderPortalLoginHelper(ScenarioContext context) => _context = context;

        public bool IsLandingPageDisplayed() => new CheckProviderLandingPage(_context).IsPageDisplayed();

        public bool IsStubSignInPageDisplayed() => new CheckDfeSignInPage(_context).IsPageDisplayed();

        public bool IsSelectYourOrganisationDisplayed() => new CheckSelectYourOrganisationPage(_context).IsPageDisplayed();

        public bool IsProviderHomePageDisplayed(string ukprn) => new CheckProviderHomePage(_context, ukprn).IsPageDisplayed();

        internal void ClickStartNow() => new ProviderLandingPage(_context).ClickStartNow();

        internal void SubmitValidLoginDetails(ProviderLoginUser login) => new ProviderDfeSignInPage(_context).SubmitValidLoginDetails(login);

        internal ProviderHomePage SelectOrganisation(ProviderLoginUser login) => new SelectYourOrganisationPage(_context).SelectOrganisation(login.Ukprn);
    }

    //Experimental method not in use : Please don't delete
    public class CheckProviderPortalReLoginPages(ScenarioContext context) : CheckPageTitleShorterTimeOut(context)
    {
        protected override string PageTitle { get; }

        protected override By Identifier => By.CssSelector($"{DfeSignInPage.DfePageIdentifierCss}, {SelectYourOrganisationPage.SyoPageIdentifierCss}, {ProviderHomePage.ProviderHomePageIdentifierCss}");

        public string DisplayedPage(string ukprn)
        {
            string displayedPage = string.Empty;

            IsPageDisplayed(() =>
            {
                string[] pageTitle = [DfeSignInPage.DfePageTitle, SelectYourOrganisationPage.SyoPageTitle, ukprn];

                SetDebugInformation($"Check displayed page loaded using Page title : {string.Join(", ", pageTitle.Select(x => $"'{x}'"))} ");

                (bool result, string actualPage) = checkPageInteractionHelper.VerifyPage(() => checkPageInteractionHelper.FindElement(Identifier), pageTitle.ToList());

                displayedPage = actualPage;

                return result;
            });

            return displayedPage;
        }
    }
}
