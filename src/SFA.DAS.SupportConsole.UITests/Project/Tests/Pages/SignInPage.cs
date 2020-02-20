using SFA.DAS.IdamsLogin.Service.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.Pages
{
    public class SignInPage : SignInBasePage
    {
        protected override string PageTitle => "ESFA Sign in";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly SupportConsoleConfig _config;
        #endregion

        public SignInPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _config = context.GetSupportConsoleConfig<SupportConsoleConfig>();
        }

        public SearchHomePage SignInWithValidDetails()
        {
            SubmitValidLoginDetails(_config.SupportConsoleLoginUsername, _config.SupportConsoleLoginPassword);
            return new SearchHomePage(_context);
        }
    }
}
