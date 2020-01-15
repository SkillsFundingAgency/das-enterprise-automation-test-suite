using NUnit.Framework;
using SFA.DAS.Campaigns.UITests.Project;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests
{
    [Binding]
    public class VerifyJamalPanelVideoSteps
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly TabHelper _tabHelper;
        private FireItUpHomePage fireItUpHomePage;
        private jamalTheCallingPage JamalTheCallingPage;
        #endregion

        public VerifyJamalPanelVideoSteps(ScenarioContext context)
        {
            _context = context;
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
            _tabHelper = context.Get<TabHelper>();
        }
        [Given(@"I launch the Jamal page")]
        public void GivenILaunchTheJamalPage()
        {
            fireItUpHomePage = new FireItUpHomePage(_context);
            TestContext.Progress.WriteLine("Navigating to Jamal page");
            fireItUpHomePage.ClickOnTheCallingLink();
        }
        
        [Then(@"I verify the content on jamal Panel")]
        public void ThenIVerifyTheContentOnJamalPanel()
        {
           jamalTheCallingPage = new JamalTheCallingPage(_context);

        }
    }
}
