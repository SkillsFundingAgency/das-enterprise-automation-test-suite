using SFA.DAS.Registration.UITests.Project.Helpers;
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
        private readonly EmployerPortalLoginHelper _loginHelper;

        public ExistingAccountSteps(ScenarioContext context)
        {
            _context = context;
            _loginHelper = new EmployerPortalLoginHelper(context);
        }

        [Given(@"the Employer login using existing levy account")]
        public void GivenTheEmployerLoginUsingExistingLevyAccount()
        {
            var levyUser = _context.GetUser<LevyUser>();

            _loginHelper.SetLoginCredentials(levyUser, true);

            _loginHelper.Login(levyUser);
        }

        [Given(@"the Employer login using existing non levy account")]
        public void GivenTheEmployerLoginUsingExistingNonLevyAccount()
        {
            var nonlevyUser = _context.GetUser<NonLevyUser>();

            _loginHelper.SetLoginCredentials(nonlevyUser, false);

            _loginHelper.Login(nonlevyUser);
        }

        [Given(@"the Employer login using existing eoi account")]
        public void GivenTheEmployerLoginUsingExistingEoiAccount()
        {
            var eoiUser = _context.GetUser<EoiUser>();

            _loginHelper.SetLoginCredentials(eoiUser, false);

            _loginHelper.Login(eoiUser);
        }
    }
}
