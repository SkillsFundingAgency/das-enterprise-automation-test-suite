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
        private readonly ExistingAccountsStepsHelper _stepsHelper;

        public ExistingAccountSteps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new ExistingAccountsStepsHelper(context);
        }

        [Given(@"the Employer login using existing levy account")]
        public void GivenTheEmployerLoginUsingExistingLevyAccount()
        {
            _stepsHelper.Login(_context.GetUser<LevyUser>(), true);
        }

        [Given(@"the Employer login using existing non levy account")]
        public void GivenTheEmployerLoginUsingExistingNonLevyAccount()
        {
            _stepsHelper.Login(_context.GetUser<NonLevyUser>(), false);
        }

        [Given(@"the Employer login using existing eoi account")]
        public void GivenTheEmployerLoginUsingExistingEoiAccount()
        {
            _stepsHelper.Login(_context.GetUser<EoiUser>(), false);
        }
    }
}
