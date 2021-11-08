using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Influencers
{
    public class InfluencersHubPage : InfluencersBasePage
    {
        private readonly ScenarioContext _context;

        protected override string PageTitle => "INFLUENCERS";

        protected override By PageHeader => PageHeaderTag;

        private By BrowseApprentice => By.CssSelector("#fiu-panel-link-faa");

        public InfluencersHubPage(ScenarioContext context) : base(context) => _context = context;

        public void VerifySubHeadings() => VerifyFiuCards(() => NavigateToInfluencersHubPage());

        public BrowseApprenticeshipPage NavigateToBrowseApprenticeshipPage()
        {
            formCompletionHelper.ClickElement(BrowseApprentice);
            return new BrowseApprenticeshipPage(_context);
        }
    }
}
