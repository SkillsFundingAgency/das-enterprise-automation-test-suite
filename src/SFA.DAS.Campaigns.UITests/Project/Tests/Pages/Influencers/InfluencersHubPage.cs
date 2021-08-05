using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Influencers
{
    public class InfluencersHubPage : HubBasePage
    {
        protected override string PageTitle => "INFLUENCERS";

        private By HowDoTheyWork => By.CssSelector("a[href= '/influencers/how-apprenticeships-work']");

        private By RequestSupport => By.CssSelector("a[href= '/influencers/request-ask-support']");

        private By ResourceHub => By.CssSelector("a[href= '/influencers/resource-hub']");

        

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public InfluencersHubPage(ScenarioContext context) : base(context) => _context = context;

        public void VerifySubHeadings() => VerifyFiuCards(() => NavigateToInfluencersHubPage());

        public InfluencersHowTheyWorkPage NavigateToHowDoTheyWorkPage()
        {
            formCompletionHelper.ClickElement(HowDoTheyWork);
            return new InfluencersHowTheyWorkPage(_context);
        }

        public InfluencersRequestSupportPage NavigateToRequestSupportPage()
        {
            formCompletionHelper.ClickElement(RequestSupport);
            return new InfluencersRequestSupportPage(_context);
        }

        public InfluencersResourceHubPage NavigateToResourceHubPage()
        {
            formCompletionHelper.ClickElement(ResourceHub);
            return new InfluencersResourceHubPage(_context);
        }
    }
}
