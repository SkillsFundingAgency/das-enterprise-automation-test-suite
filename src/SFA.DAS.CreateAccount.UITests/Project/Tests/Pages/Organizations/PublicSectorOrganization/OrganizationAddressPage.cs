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

        public OrganizationAddressPage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
        }

        internal OrganizationAddressPage SetFirstAddressLine(string addressLine)
        {
            formCompletionHelper.EnterText(WebBrowserDriver, _firstAddressInput, addressLine);
            return this;
        }

        internal OrganizationAddressPage SetSecondAddressLine(string addressLine)
        {
            formCompletionHelper.EnterText(WebBrowserDriver, _secondAddressInput, addressLine);
            return this;
        }

        internal OrganizationAddressPage SetTownOrCity(string townOrCity)
        {
            formCompletionHelper.EnterText(WebBrowserDriver, _townOrCityInput, townOrCity);
            return this;
        }

        internal OrganizationAddressPage SetCountry(string country)
        {
            formCompletionHelper.EnterText(WebBrowserDriver, _countryInput, country);
            return this;
        }

        internal OrganizationAddressPage SetPostcode(string postcode)
        {
            formCompletionHelper.EnterText(WebBrowserDriver, _postcodeInput, postcode);
            return this;
        }

        internal SummaryPayePage ContinueAndMoveToConfirmPage()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _continueButton);
            return new SummaryPayePage(WebBrowserDriver);
        }

        internal void ClickContinueWithoutEnteringData()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _continueButton);
        }

        internal ConfirmOrganizationDataPage ContinueAndMoveToConfirmOrganizationDataPage()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _continueButton);
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