using SFA.DAS.ASK.UITests.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.ASK.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class AskSteps
    {
        private readonly ScenarioContext _context;

        public AskSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"the user sign in to ask programme")]
        public void GivenTheUserSignInToAskProgramme()
        {
            new LandingPage(_context).StartNow();
        }
    }
}
