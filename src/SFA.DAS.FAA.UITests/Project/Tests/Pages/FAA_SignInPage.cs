using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_SignInPage : BasePage
    {
        protected override string PageTitle => "Sign in";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly FAAConfig _config;
        private readonly FAADataHelper _dataHelper;
        private readonly PageInteractionHelper _PageInteractionhelper;
        #endregion

        private By UsernameField => By.CssSelector("#EmailAddress");

        private By PasswordField => By.CssSelector("#Password");

        private By SignInButton => By.CssSelector("#sign-in-button");

        private By CreateAnAccountLink => By.Id("create-account-link");

        public FAA_SignInPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _config = context.GetFAAConfig<FAAConfig>();
            _dataHelper = context.Get<FAADataHelper>();
            _PageInteractionhelper = context.Get<PageInteractionHelper>();
            VerifyPage(UsernameField);
        }

        public FAA_MyApplicationsHomePage SubmitValidLoginDetails()
        {
            _formCompletionHelper.EnterText(UsernameField, _config.FAAUserName);
            _formCompletionHelper.EnterText(PasswordField, _config.FAAPassword);
            _formCompletionHelper.ClickElement(SignInButton);
            return new FAA_MyApplicationsHomePage(_context);
        }

        public FAA_ActivateYourAccountPage SubmitUnactivatedLoginDetails()
        {
            _formCompletionHelper.EnterText(UsernameField, _dataHelper.EmailId);
            _formCompletionHelper.EnterText(PasswordField, _dataHelper.Password);
            _formCompletionHelper.ClickElement(SignInButton);
            return new FAA_ActivateYourAccountPage(_context);
        }

        public FAA_CreateAnAccountPage ClickCreateAnAccountLink()
        {
            _formCompletionHelper.Click(CreateAnAccountLink);
            return new FAA_CreateAnAccountPage(_context);
        }
    }
}
