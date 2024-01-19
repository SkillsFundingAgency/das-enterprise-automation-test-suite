using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport.CheckPage;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderLogin.Service.Project.Tests.Pages
{
    public class CheckSelectYourOrgOrProviderHomePage(ScenarioContext context, string ukprn) : CheckPageTitleShorterTimeOut(context)
    {
        protected override string PageTitle { get; }

        protected override By Identifier => By.CssSelector($"{SelectYourOrganisationPage.SyoPageIdentifierCss}, {ProviderHomePage.ProviderHomePageIdentifierCss}");

        public bool IsSelectYourOrganisationDisplayed() => ActualDisplayedPage(SelectYourOrganisationPage.SyoPageTitle);

        public bool IsProviderHomePageDisplayed() => ActualDisplayedPage(ukprn);

        private bool ActualDisplayedPage(string page) => ActualDisplayedPage().Contains(page);

        private string ActualDisplayedPage()
        {
            string displayedPage = string.Empty;

            IsPageDisplayed(() =>
            {
                string[] pageTitle = [SelectYourOrganisationPage.SyoPageTitle, ukprn];

                SetDebugInformation($"Check that {string.Join(" OR ", pageTitle.Select(x => $"'{x}'"))} is displayed using Page title");

                (bool result, string actualPage) = checkPageInteractionHelper.VerifyPage(() => checkPageInteractionHelper.FindElements(Identifier), pageTitle.ToList());

                displayedPage = actualPage;

                return result;
            });

            return displayedPage;
        }
    }
}
