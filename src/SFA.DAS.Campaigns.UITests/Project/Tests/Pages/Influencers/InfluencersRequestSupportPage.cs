using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Influencers
{
    public class InfluencersRequestSupportPage : InfluencersBasePage
    {
        protected override string PageTitle => "Request support";

        protected override By PageHeader => SubPageHeader;

        public InfluencersRequestSupportPage(ScenarioContext context) : base(context) { }

        public InfluencersRequestSupportPage VerifySubHeadings() => VerifyFiuCards(() => NavigateToRequestSupportPage());
    }
}