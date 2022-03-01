using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_SearchEmployerOrAddressPage : EPAOAssesment_BasePage
    {
        protected override string PageTitle => "Search for an employer or address";
        protected override By PageHeader => By.CssSelector(".js-search-address-heading");

        #region Locators
        private By AddressSearchTextBox => By.Id("postcode-search");
        private By AutoSuggestOptions => By.CssSelector(".ui-menu-item");
        private By SelectedAddressPanel => By.CssSelector(".js-address-panel");
        private By EnterAddressManuallyLink => By.Id("enterAddressManually");
        #endregion

        public AS_SearchEmployerOrAddressPage(ScenarioContext context) : base(context) => VerifyPage();

        public AS_ConfirmAddressPage ClickContinueInSearchEmployerAddressPage()
        {
            Continue();
            return new AS_ConfirmAddressPage(context);
        }

        public AS_AddEmployerAddress ClickEnterAddressManuallyLinkInSearchEmployerPage()
        {
            formCompletionHelper.Click(EnterAddressManuallyLink);
            return new AS_AddEmployerAddress(context);
        }
    }
}
