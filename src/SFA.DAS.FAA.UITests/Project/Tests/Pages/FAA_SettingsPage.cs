using OpenQA.Selenium;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.RAA.DataGenerator.Project;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_SettingsPage : BasePage
    {
        protected override string PageTitle => "Settings";

        private By UsernameField => By.CssSelector("#EmailAddress");
        private By PasswordField => By.CssSelector("#Password");
        private By SuccessfulMobileVerificationText => By.Id("SuccessMessageText");
        private By DeleteYourAccountLink => By.LinkText("Delete your account");
        private By DeleteAccountButton => By.Id("delete-account-button");

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;     
        private readonly FAADataHelper _dataHelper;        
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ObjectContext _objectcontext;
        
        #endregion
    
        public FAA_SettingsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectcontext = context.Get<ObjectContext>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _dataHelper = context.Get<FAADataHelper>();
            VerifyPage();
        }

        public void VerifySuccessfulVerificationText()
        {
            _pageInteractionHelper.VerifyText(SuccessfulMobileVerificationText, _dataHelper.SuccessfulPhoneVerificationText);
        } 

        public FAA_ConfirmAccountDeletionPage DeleteYourAccount()
        {
            var (username, password, _ , _) = _objectcontext.GetFAANewAccount();
            _formCompletionHelper.Click(DeleteYourAccountLink);
            _formCompletionHelper.EnterText(UsernameField, username);
            _formCompletionHelper.EnterText(PasswordField, password);
            _formCompletionHelper.Click(DeleteAccountButton);
            return new FAA_ConfirmAccountDeletionPage(_context);
        }
    }
}
