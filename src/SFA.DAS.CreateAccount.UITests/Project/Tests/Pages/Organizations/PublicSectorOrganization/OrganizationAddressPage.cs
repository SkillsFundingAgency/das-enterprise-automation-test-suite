using System.Linq;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Organizations;
using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.CompaniesHouse;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.PublicSectorOrganization
{
    internal class OrganizationAddressPage : BasePage
    {
        [FindsBy(How = How.Id, Using = "AddressFirstLine")] private IWebElement _firstAddressInput;
        [FindsBy(How = How.Id, Using = "AddressSecondLine")] private IWebElement _secondAddressInput;
        [FindsBy(How = How.Id, Using = "TownOrCity")] private IWebElement _townOrCityInput;
        [FindsBy(How = How.Id, Using = "County")] private IWebElement _countryInput;
        [FindsBy(How = How.Id, Using = "Postcode")] private IWebElement _postcodeInput;
        [FindsBy(How = How.XPath, Using = ".//*[@type=\"submit\"]")] private IWebElement _continueButton;

        public OrganizationAddressPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal OrganizationAddressPage SetFirstAddressLine(string addressLine)
        {
            _formCompletionHelper.EnterText(_firstAddressInput, addressLine);
            return this;
        }

        internal OrganizationAddressPage SetSecondAddressLine(string addressLine)
        {
            _formCompletionHelper.EnterText(_secondAddressInput, addressLine);
            return this;
        }

        internal OrganizationAddressPage SetTownOrCity(string townOrCity)
        {
            _formCompletionHelper.EnterText(_townOrCityInput, townOrCity);
            return this;
        }

        internal OrganizationAddressPage SetCountry(string country)
        {
            _formCompletionHelper.EnterText(_countryInput, country);
            return this;
        }

        internal OrganizationAddressPage SetPostcode(string postcode)
        {
            _formCompletionHelper.EnterText(_postcodeInput, postcode);
            return this;
        }

        internal SummaryPayePage ContinueAndMoveToConfirmPage()
        {
            _formCompletionHelper.ClickElement(_continueButton);
            return new SummaryPayePage(WebBrowserDriver);
        }

        internal void ClickContinueWithoutEnteringData()
        {
            _formCompletionHelper.ClickElement(_continueButton);
        }

        internal ConfirmOrganizationDataPage ContinueAndMoveToConfirmOrganizationDataPage()
        {
            _formCompletionHelper.ClickElement(_continueButton);
            return new ConfirmOrganizationDataPage(WebBrowserDriver);
        }

        internal string[] GetErrors()
        {
            return WebBrowserDriver
                .FindElements(By.XPath(".//*[@class=\"error-summary\"]//li"))
                .Select((element) => element.Text)
                .ToArray();
        }
    }
}