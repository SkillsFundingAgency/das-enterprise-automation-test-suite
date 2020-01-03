using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.EPAO.UITests.Project.Helpers;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_SearchEmployerAddressPage : BasePage
    {
        protected override string PageTitle => "Search for the employer's address";
        protected override By PageHeader => By.CssSelector(".js-search-address-heading");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly RandomElementHelper _randomElementHelper;
        #endregion

        #region Locators
        private By AddressSearchTextBox => By.Id("postcode-search");
        private By AutoSuggestOptions => By.CssSelector(".ui-menu-item");
        private By SelectedAddressPanel => By.CssSelector(".js-address-panel");
        private By EnterAddressManuallyLink => By.Id("enterAddressManually");
        #endregion

        public AS_SearchEmployerAddressPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _randomElementHelper = context.Get<RandomElementHelper>();
            VerifyPage();
        }

        public AS_SearchEmployerAddressPage SearchAndSelectEmployerAddress()
        {
            _formCompletionHelper.EnterText(AddressSearchTextBox, "CV1 2WT");
            var autoSuggestOptionElements = _pageInteractionHelper.FindElements(AutoSuggestOptions);
            _formCompletionHelper.ClickElement(() => _randomElementHelper.GetRandomElementFromListOfElements(autoSuggestOptionElements));
            VerifyPage(SelectedAddressPanel);
            return this;
        }

        public AS_ConfirmAddressPage ClickContinueInSearchEmployerAddressPage()
        {
            Continue();
            return new AS_ConfirmAddressPage(_context);
        }

        public AS_AddEmployerAddress ClickEnterAddressManuallyLinkInSearchEmployerPage()
        {
            _formCompletionHelper.Click(EnterAddressManuallyLink);
            return new AS_AddEmployerAddress(_context);
        }
    }
}
