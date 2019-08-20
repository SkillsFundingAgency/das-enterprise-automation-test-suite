using SFA.DAS.Registration.UITests.Project.Tests.Pages;
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

        public ExistingAccountSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"the User login using existing levy account")]
        public void GivenTheUserLoginUsingExistingLevyAccount()
        {
            var levyUser = _context.GetUser<LevyUser>();
            new IndexPage(_context)
                .SignIn()
                .Login(levyUser);
        }

        [Given(@"the User login using existing non levy account")]
        public void GivenTheUserLoginUsingExistingNonLevyAccount()
        {
            var nonlevyUser = _context.GetUser<NonLevyUser>();
            new IndexPage(_context)
                .SignIn()
                .Login(nonlevyUser);
        }

        [Given(@"the User login using existing eoi account")]
        public void GivenTheUserLoginUsingExistingEoiAccount()
        {
            var eoiUser = _context.GetUser<EoiUser>();
            new IndexPage(_context)
                .SignIn()
                .Login(eoiUser);
        }
    }
}
