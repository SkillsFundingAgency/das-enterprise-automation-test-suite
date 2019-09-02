using NUnit.Framework;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class ExistingAccountSteps
    {
        private readonly ScenarioContext _context;
        private readonly LoginHelper _loginHelper;

        public ExistingAccountSteps(ScenarioContext context)
        {
            _context = context;
            _loginHelper = new LoginHelper(context);
        }

        [Given(@"the Employer login using existing levy account")]
        public void GivenTheEmployerLoginUsingExistingLevyAccount()
        {
            var levyUser = _context.GetUser<LevyUser>();

            _loginHelper.SetLoginCredentials(levyUser);

            _loginHelper.Login(levyUser);
        }

        [Given(@"the Employer login using existing non levy account")]
        public void GivenTheEmployerLoginUsingExistingNonLevyAccount()
        {
            var nonlevyUser = _context.GetUser<NonLevyUser>();

            _loginHelper.SetLoginCredentials(nonlevyUser);

            _loginHelper.Login(nonlevyUser);
        }

        [Given(@"the Employer login using existing eoi account")]
        public void GivenTheEmployerLoginUsingExistingEoiAccount()
        {
            var eoiUser = _context.GetUser<EoiUser>();

            _loginHelper.SetLoginCredentials(eoiUser);

            _loginHelper.Login(eoiUser);
        }
    }

    public class LoginHelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public LoginHelper(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        public HomePage Login(LoginUser loginUser)
        {
            return new IndexPage(_context)
                .SignIn()
                .Login(loginUser);
        }

        internal void SetLoginCredentials(LoginUser loginUser)
        {
            _objectContext.SetLoginCredentials(loginUser.Username, loginUser.Password);
            TestContext.Progress.WriteLine($"Email : {loginUser.Username}");
        }
    }
}
