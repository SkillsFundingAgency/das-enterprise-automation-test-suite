using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionRealStories
    {
        #region Private Variables
        private readonly ScenarioContext _context;
        private readonly RealStoriesPage realStoriesPage;
        #endregion

        public StepDefinitionRealStories(ScenarioContext context)
        {
            _context = context;
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