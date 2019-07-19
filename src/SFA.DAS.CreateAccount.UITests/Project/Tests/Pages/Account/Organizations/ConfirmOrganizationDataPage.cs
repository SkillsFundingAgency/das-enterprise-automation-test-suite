using SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Organizations.CompaniesHouse;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SFA.DAS.CreateAccount.UITests.Project.Tests.Pages.Account.Organizations
{
    internal class ConfirmOrganizationDataPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = ".//*[@type=\"submit\"]")] private IWebElement _confirmButton;

        public ConfirmOrganizationDataPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
        }

        internal LegalAgreementPage Confirm()
        {
            _formCompletionHelper.ClickElement(_confirmButton);
            return new LegalAgreementPage(WebBrowserDriver);
        }

        private By orgName = By.XPath("//tbody/tr[1]/td");
        internal string GetOrganizationInfo()
        {
            return pageInteractionHelper.GetText(orgName);
        }

        private By charityNumber = By.XPath("//tbody/tr[3]/td");
        internal string GetCharityNumber()
        {
            return pageInteractionHelper.GetText(charityNumber);
        }

        private By charityAddress = By.XPath("//tbody/tr[2]/td");
        internal string GetCharityAddress()
        {
            return pageInteractionHelper.GetText(charityAddress);
        }

    }
}