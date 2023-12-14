using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Influencers
{
    public class InfluencersRequestSupportPage(ScenarioContext context) : InfluencersBasePage(context)
    {
        protected override string PageTitle => "Request support";

        protected override By PageHeader => SubPageHeader;

        public InfluencersRequestSupportPage VerifySubHeadings() => VerifyFiuCards(() => NavigateToRequestSupportPage());
    }
}