using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class CheckIndexPage : BasePage
    {
        protected override string PageTitle { get; }

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        #endregion

        protected By SigninLink => By.LinkText("sign in");

        public CheckIndexPage(ScenarioContext context) : base(context)
        {
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
        }

        public bool IsIndexPageDisplayed()
        {
            return _pageInteractionHelper.IsElementDisplayed(SigninLink);
        }
    }

    public class IndexPage : CheckIndexPage
    {
        protected override string PageTitle => "Create an account to manage apprenticeships";

        #region Helpers and Context
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By CreateAccountLink => By.Id("service-start");

        public IndexPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public SignInPage SignIn()
        {
            _formCompletionHelper.ClickElement(SigninLink);
            return new SignInPage(_context);
        }

        public RegisterPage CreateAccount()
        {
            _formCompletionHelper.ClickElement(CreateAccountLink);
            return new RegisterPage(_context);
        }
    }
}
