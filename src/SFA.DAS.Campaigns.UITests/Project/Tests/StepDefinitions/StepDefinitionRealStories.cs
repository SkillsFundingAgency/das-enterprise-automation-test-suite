using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionRealStories
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private RealStoriesPage realStoriesPage;
        #endregion

        public StepDefinitionRealStories(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.GetCampaingnsProjectConfig<CampaignsConfig>();
            _objectContext = context.Get<ObjectContext>();
            realStoriesPage = new RealStoriesPage(_context);
        }

        [Then(@"I verify the content under Real Stories header")]
        public void VerifyContentUnderRealStoriesHeader()
        {
            realStoriesPage.VerifyContentUnderRealStoriesHeader();
        }

        [Then(@"I can play the first video on the screen")]
        public void PlayTheFirstVideo()
        {
            realStoriesPage.PlayTheFirstVideo();
        }
    }
}