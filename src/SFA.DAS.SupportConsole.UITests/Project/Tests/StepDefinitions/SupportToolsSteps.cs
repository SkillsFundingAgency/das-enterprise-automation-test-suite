using SFA.DAS.SupportConsole.UITests.Project.Helpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.SupportConsole.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class SupportToolsSteps
    {
        private readonly ScenarioContext _context;
        private readonly StepsHelper _stepsHelper;

        public SupportToolsSteps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new StepsHelper(_context);
            //_config = context.GetSupportConsoleConfig<SupportConsoleConfig>();
        }

        [Given(@"the User is logged into Support Tools")]
        public void GivenTheUserIsLoggedIntoSupportTools()
        {
            _stepsHelper.ValidUserLogsinToSupportTools();
        }


        
    }
}
