using System.Collections.Generic;
using System.Linq;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.CompaniesHouse
{
    public class SummaryPayePage: BasePage
    {
        private const string PageTitle = "Check details";
        private By _orgName = By.XPath("//tbody/tr[1]/td");
        private By _charityNumber = By.XPath("//tbody/tr[3]/td");
        private By _charityAddress = By.XPath("//tbody/tr[2]/td");
        private By _confirmSchemeButtonId = By.Id("continue");
        private By _changeOrgLink = By.XPath("(//a[contains(text(),'Change')])[3]");
        private By _changePAYELink = By.XPath("(//a[contains(text(),'Change')])[4]");
        private By payeNumber = By.XPath("//tbody/tr[4]/td");

        public SummaryPayePage(IWebDriver WebBrowserDriver) : base(WebBrowserDriver)
        {
            IsPagePresented();
        }

        public bool IsPagePresented()
        {
            return pageInteractionHelper.VerifyPageHeading(this.GetPageHeading(), PageTitle);
        }

        internal string GetSchemeFromDetails()
        {
            // This method serves two journies to fetch the PayeScheme name

            // 1. Below fetch get picked up for Account creation journey
            var elementsForConfirmCase = WebBrowserDriver
                .FindElements(By.XPath(".//tbody//tr[4]//td"));

            // 2. Below fetch get picked up from the header while adding additional PAYE to an existing account journey
            var elementsForAddCase = WebBrowserDriver
                .FindElements(By.ClassName("heading-xlarge"));

            var resultElement = elementsForConfirmCase.Count != 0 ? elementsForConfirmCase.First() : elementsForAddCase.First();

            var payescheme = 
                resultElement
                .Text
                .Replace("Confirm PAYE scheme", string.Empty)
                .Trim();

            return payescheme;
        }

        internal string GetOrganizationDetails()
        {
            return pageInteractionHelper.GetText(WebBrowserDriver, _orgName);
        }

        internal string GetCharityNumber()
        {
            return pageInteractionHelper.GetText(WebBrowserDriver, _charityNumber);
        }

        internal string GetCharityAddress()
        {
            return pageInteractionHelper.GetText(WebBrowserDriver, _charityAddress);
        }

        internal string GetPayeScheme()
        {
            return pageInteractionHelper.GetText(WebBrowserDriver, payeNumber);
        }

        internal LegalAgreementPage Continue()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _confirmSchemeButtonId);
            return new LegalAgreementPage(WebBrowserDriver);
        }

        private string MapOrganizationDetailsKey(string key)
        {
            var mapped = new Dictionary<string ,string>()
            {
                { "Name:", "Organisation name" },
                { "Address:", "Organisation address" },
                { "Charity number:", "Organisation number"}
            };
            return mapped.ContainsKey(key) ? mapped[key] : key;
        }

        public void ClickChangeOrgLink()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _changeOrgLink);
        }

        public void ClickChangePAYELink()
        {
            formCompletionHelper.ClickElement(WebBrowserDriver, _changePAYELink);
        }
    }
}