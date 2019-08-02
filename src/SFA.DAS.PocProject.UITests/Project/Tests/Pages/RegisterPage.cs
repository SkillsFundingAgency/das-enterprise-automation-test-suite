using OpenQA.Selenium;
using SFA.DAS.PocProject.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project.Tests.Pages
{
    public class RegisterPage : BasePage
    {

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ProjectSpecificConfig _config;
        #endregion

        private const string LastName = "Auto_Tester";

        private By SignInLink => By.LinkText("sign in");

        private By FirstNameInput => By.Id("FirstName");

        private By LastNameInput => By.Id("LastName");

        private By EmailInput => By.Id("Email");

        private By PasswordInput => By.Id("Password");

        private By PasswordConfirmInput => By.Id("ConfirmPassword");

        private By TermsAndConditionsLink => By.LinkText("terms and conditions");

        private By SetMeUpButton => By.Id("button-register");

        private readonly DataHelper _helper;

        public RegisterPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetProjectSpecificConfig<ProjectSpecificConfig>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
            _helper = context.Get<DataHelper>();
        }

        protected override string PageTitle => "Set up as a user";

        public ConfirmPage Register()
        {
                EnterFirstName().
                EnterlastName().
                EnterEmail().
                EnterPassword().
                EnterPasswordConfirm().
                SetMeUp();
            return new ConfirmPage(_context);
        }

        private RegisterPage EnterFirstName()
        {
            _formCompletionHelper.EnterText(FirstNameInput, _config.TwoDigitProjectCode);
            return this;
        }

        private RegisterPage EnterlastName()
        {
            _formCompletionHelper.EnterText(LastNameInput, LastName);
            return this;
        }

        private RegisterPage EnterEmail()
        {
            _formCompletionHelper.EnterText(EmailInput, _helper.RandomEmail);
            return this;
        }

        private RegisterPage EnterPassword()
        {
            _formCompletionHelper.EnterText(PasswordInput, _config.PP_AccountPassword);
            return this;
        }

        private RegisterPage EnterPasswordConfirm()
        {
            _formCompletionHelper.EnterText(PasswordConfirmInput, _config.PP_AccountPassword);
            return this;
        }

        private RegisterPage SetMeUp()
        {
            _formCompletionHelper.ClickElement(SetMeUpButton);
            return this;
        }
    }
}