using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Influencers
{
    public abstract class InfluencersBasePage : HubBasePage
    {
        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By HowDoTheyWork => By.CssSelector("a[href= '/influencers/how-apprenticeships-work']");

        private By RequestSupport => By.CssSelector("a[href= '/influencers/request-ask-support']");

        private By ResourceHub => By.CssSelector("a[href= '/influencers/resource-hub']");

        private By BecomeAnAmbassador => By.CssSelector("a[href= '/influencers/become-an-ambassador']");

        public InfluencersBasePage(ScenarioContext context) : base(context) => _context = context;

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

        public InfluencersBecomeAnAmbassadorPage NavigateToBecomeAnAmbassadorPage()
        {
            formCompletionHelper.ClickElement(BecomeAnAmbassador);
            return new InfluencersBecomeAnAmbassadorPage(_context);
        }
    }
}
