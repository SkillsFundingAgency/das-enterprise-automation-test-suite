using SFA.DAS.ProviderFeedback.UITests.Project.Tests.Pages;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProviderFeedback.UITests
{
    [Binding]
    public class PFStepDefinitions
    {
        private readonly ScenarioContext _context;

        public PFStepDefinitions(ScenarioContext context)
        {
            _context = context;
        }

        [Given(@"the user on the homepage")]
        public void GivenTheUserOnTheHomepage()
        {
            new ProviderFeedbackHomePage(_context);
        }
    }
}
