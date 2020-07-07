using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_SearchEmployerAddressPage : EPAO_BasePage
    {
        protected override string PageTitle => "Search for the address that you’d like us to send the certificate to";
        protected override By PageHeader => By.CssSelector(".js-search-address-heading");
        private readonly ScenarioContext _context;

        #region Locators
        private By AddressSearchTextBox => By.Id("postcode-search");
        private By AutoSuggestOptions => By.CssSelector(".ui-menu-item");
        private By SelectedAddressPanel => By.CssSelector(".js-address-panel");
        private By EnterAddressManuallyLink => By.Id("enterAddressManually");
        #endregion

        public AS_SearchEmployerAddressPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public AS_ConfirmAddressPage ClickContinueInSearchEmployerAddressPage()
        {
            Continue();
            return new AS_ConfirmAddressPage(_context);
        }

        public AS_AddEmployerAddress ClickEnterAddressManuallyLinkInSearchEmployerPage()
        {
            formCompletionHelper.Click(EnterAddressManuallyLink);
            return new AS_AddEmployerAddress(_context);
        }
    }
}
