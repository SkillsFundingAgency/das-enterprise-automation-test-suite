using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Influencers
{
    public class InfluencersHubPage(ScenarioContext context) : InfluencersBasePage(context)
    {
        protected override string PageTitle => "Influencers";

        protected override By PageHeader => PageHeaderTag;

        private static By BrowseApprentice => By.CssSelector("#fiu-panel-link-faa");

        public void VerifySubHeadings() => VerifyFiuCards(() => NavigateToInfluencersHubPage());

        public BrowseApprenticeshipPage NavigateToBrowseApprenticeshipPage()
        {
            formCompletionHelper.ClickElement(BrowseApprentice);
            return new BrowseApprenticeshipPage(context);
        }
    }
}
