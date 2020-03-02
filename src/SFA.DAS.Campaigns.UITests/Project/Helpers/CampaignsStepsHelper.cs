using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Helpers
{
    public class CampaignsStepsHelper
    {
        private readonly ScenarioContext _context;

        public CampaignsStepsHelper(ScenarioContext context) => _context = context;

        public FireItUpHomePage GoToFireItUpHomePage() => new FireItUpHomePage(_context).AcceptCookieAndAlert();
    }
}
