using OpenQA.Selenium;
using SFA.DAS.RAA_V1.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_RegistrationPage : BasePage
    {

        protected override By PageHeader => By.CssSelector(".pageTitle");

        protected override string PageTitle => "Registration";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly RAARegistrationDataHelper _dataHelper;
        #endregion

        private By Title => By.Id("title");
        private By FirstName => By.Id("firstName");
        private By LastName => By.Id("lastName");
        private By EmailAddress => By.Id("userEmail");
        private By MobileNumber => By.Id("userMobile");
        private By Password => By.Id("password");
        private By ConfirmPassword => By.Id("confirmPassword");
        private By AcceptTermsAndCondition => By.Id("termsAndConditions");
        private By ButtonRegister => By.XPath("//button[contains(text(),'Register')]");
        private By ConfirmationText => By.CssSelector(".pageSubtitle");

        public RAA_RegistrationPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _dataHelper = context.Get<RAARegistrationDataHelper>();
            VerifyPage();
        }

        public RAA_RegistrationPage Register()
        {
            _formCompletionHelper.SelectFromDropDownByText(Title, _dataHelper.Title);
            _formCompletionHelper.EnterText(FirstName, _dataHelper.FirstName);
            _formCompletionHelper.EnterText(LastName, _dataHelper.LastName);
            _formCompletionHelper.EnterText(EmailAddress, _dataHelper.EmailAddress);
            _formCompletionHelper.EnterText(MobileNumber, _dataHelper.MobileNumber);
            _formCompletionHelper.EnterText(Password, _dataHelper.Password);
            _formCompletionHelper.EnterText(ConfirmPassword, _dataHelper.Password);
            _formCompletionHelper.Click(AcceptTermsAndCondition);
            _formCompletionHelper.Click(ButtonRegister);
            return this;
        }

        public string FormInfoText()
        {
            _pageInteractionHelper.WaitforURLToChange("/registrationEmailSent/");
            return _pageInteractionHelper.GetText(ConfirmationText);
        }
    }
}
