using OpenQA.Selenium;
using SFA.DAS.RAA.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.FAA.UITests.Project.Tests.Pages
{
    public class FAA_ChangeYourEmailAddressPage : BasePage
    {
        protected override string PageTitle => "Change your email address";

        private By EmailAddress => By.Id("EmailAddress");
        private By SendCodeButton => By.Id("btn-sendcode");
        private By SuccessMessageText => By.Id("SuccessMessageText");
        private By VerificationCode => By.Id("PendingUsernameCode");
        private By VerifyEmailButton => By.Id("verify-email-button");
        private By VerifyPassword => By.Id("VerifyPassword");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly FAADataHelper _faaDataHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;        
        #endregion

        public FAA_ChangeYourEmailAddressPage(ScenarioContext context ): base(context)
        {
            _context = context;
            VerifyPage();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            _faaDataHelper = context.Get<FAADataHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public FAA_SignInPage ChangeEmailAddress()
        {
            _formCompletionHelper.EnterText(EmailAddress, _faaDataHelper.ChangedEmailId);
            _formCompletionHelper.Click(SendCodeButton);
            _pageInteractionHelper.VerifyText(SuccessMessageText, "A verification code has been sent to your new email address.");
            _formCompletionHelper.EnterText(VerificationCode, _faaDataHelper.ActivationCode);
            _formCompletionHelper.EnterText(VerifyPassword, _faaDataHelper.Password);
            _formCompletionHelper.Click(VerifyEmailButton);
            return new FAA_SignInPage(_context);
        }
    }
}
