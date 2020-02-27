using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class CampaignsSteps
    {
        private readonly ScenarioContext _context;

        public CampaignsSteps(ScenarioContext context)
        {
            _context = context;
        }

        [Then(@"an apprentice can register interest")]
        public void ThenAnApprenticeCanRegisterInterest()
        {
            new FireItUpHomePage(_context);
        }

    }
}
