using OpenQA.Selenium;
using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.AssessmentService
{
    public class AS_SearchEmployerAddress : BasePage
    {
        protected override string PageTitle => "Search for the employer's address";
        protected override By PageHeader => By.CssSelector(".js-search-address-heading");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly RandomDataGenerator _randomDataGenerator;
        #endregion

        #region Locators
        private By AddressSearchTextBox => By.Id("postcode-search");
        private By PostCodeAutocompleteElements => By.CssSelector(".ui-menu-item");
        private By SelectedAddressPanel => By.CssSelector(".js-address-panel");
        private By ContinueButton => By.CssSelector(".govuk-button");
        #endregion

        public AS_SearchEmployerAddress(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _randomDataGenerator = context.Get<RandomDataGenerator>();
            VerifyPage();
        }

        public AS_SearchEmployerAddress SearchAndSelectEmployerAddress()
        {
            _formCompletionHelper.EnterText(AddressSearchTextBox, "CV1 2WT");

            _formCompletionHelper.ClickElement(() =>
            {
                var postCodeAutocompleteAddresses = _pageInteractionHelper.FindElements(PostCodeAutocompleteElements);
                return postCodeAutocompleteAddresses[_randomDataGenerator.GenerateRandomNumberBetweenTwoValues(0, postCodeAutocompleteAddresses.Count - 1)];
            });

            _pageInteractionHelper.WaitForDynamicElementToAppear(SelectedAddressPanel);

            return this;
        }

        public AS_ConfirmAddressPage ClickContinueInSearchEmployerAddressPage()
        {
            _formCompletionHelper.Click(ContinueButton);
            return new AS_ConfirmAddressPage(_context);
        }
    }
}
