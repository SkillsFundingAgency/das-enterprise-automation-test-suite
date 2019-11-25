using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.FAA
{
    public class FAA_CreateAnAccountPage : BasePage
    {
        protected override string PageTitle => "Create an account";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        private readonly RAAV1Config _config;
        private readonly FAADataHelper _dataHelper;
        #endregion

        #region Locators
        private By FirstName => By.Id("Firstname");
        private By LastName => By.Id("Lastname");
        private By DOB_Day => By.Id("DateOfBirth_Day");
        private By DOB_Month => By.Id("DateOfBirth_Month");
        private By DOB_Year => By.Id("DateOfBirth_Year");
        private By PostCode => By.Id("postcode-search");
        private By PostCodeAutoSuggestResults => By.CssSelector(".ui-menu-item");
        private By EmailId => By.Id("EmailAddress");
        private By PhoneNumber => By.Id("PhoneNumber");
        private By Password => By.Id("Password");
        private By ConfirmPassword => By.Id("ConfirmPassword");
        private By AcceptTermsAndConditions => By.CssSelector("input#HasAcceptedTermsAndConditions");
        private By CreateAccountButton => By.Id("create-account-btn");
        #endregion

        public FAA_CreateAnAccountPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<FAADataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _config = context.GetRAAV1Config<RAAV1Config>();
            VerifyPage();
        }

        public FAA_ActivateYourAccountPage SubmitSubmitAccountCreationDetails()
        {
            _formCompletionHelper.EnterText(FirstName, _dataHelper.FirstName);
            _formCompletionHelper.EnterText(LastName, _dataHelper.LastName);
            _formCompletionHelper.EnterText(DOB_Day, _dataHelper.DOB_Day);
            _formCompletionHelper.EnterText(DOB_Month, _dataHelper.DOB_Month);
            _formCompletionHelper.EnterText(DOB_Year, _dataHelper.DOB_Year);
            SelectAddress();
            _formCompletionHelper.EnterText(EmailId, _dataHelper.EmailId);
            _formCompletionHelper.EnterText(PhoneNumber, _dataHelper.PhoneNumber);
            _formCompletionHelper.EnterText(Password, _dataHelper.Password);
            _formCompletionHelper.EnterText(ConfirmPassword, _dataHelper.Password);
            _formCompletionHelper.ClickElement(() => _pageInteractionHelper.FindElement(AcceptTermsAndConditions));
            _formCompletionHelper.Click(CreateAccountButton);

            return new FAA_ActivateYourAccountPage(_context);
        }

        public void SelectAddress()
        {
            _formCompletionHelper.EnterText(PostCode, _dataHelper.PostCode);
            var randomElements = _pageInteractionHelper.FindElements(PostCodeAutoSuggestResults);
            _formCompletionHelper.ClickElement(() => _dataHelper.GetRandomElementFromListOfElements(randomElements));
        }
    }
}