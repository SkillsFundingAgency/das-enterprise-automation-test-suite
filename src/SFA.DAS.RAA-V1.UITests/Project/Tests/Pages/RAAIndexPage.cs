using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages
{
    public class RAAIndexPage : BasePage
    {
        protected override string PageTitle => "Recruit an apprentice";
        
        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        #endregion

        private By SignInButton => By.LinkText("Sign in");

        public RAAIndexPage(ScenarioContext context): base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public Idams ClickOnSignInButton()
        {
            _formCompletionHelper.Click(SignInButton);
            return new Idams(_context);
        }
    }
}
