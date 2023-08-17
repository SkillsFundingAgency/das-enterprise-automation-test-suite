using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Influencers
{
    public abstract class InfluencersBasePage : HubBasePage
    {
        private static By HowDoTheyWork => By.CssSelector("a[href= '/influencers/how-apprenticeships-work']");

        private static By RequestSupport => By.CssSelector("a[href= '/influencers/request-ask-support']");

        private static By ResourceHub => By.CssSelector("a[href= '/influencers/resource-hub']");

        private static By BecomeAnAmbassador => By.CssSelector("a[href= '/influencers/become-an-ambassador']");

        public InfluencersBasePage(ScenarioContext context) : base(context)  { }

        public InfluencersHowTheyWorkPage NavigateToHowDoTheyWorkPage()
        {
            formCompletionHelper.ClickElement(HowDoTheyWork);
            return new InfluencersHowTheyWorkPage(context);
        }

        public InfluencersRequestSupportPage NavigateToRequestSupportPage()
        {
            formCompletionHelper.ClickElement(RequestSupport);
            return new InfluencersRequestSupportPage(context);
        }

        public InfluencersResourceHubPage NavigateToResourceHubPage()
        {
            formCompletionHelper.ClickElement(ResourceHub);
            return new InfluencersResourceHubPage(context);
        }

        public InfluencersBecomeAnAmbassadorPage NavigateToBecomeAnAmbassadorPage()
        {
            formCompletionHelper.ClickElement(BecomeAnAmbassador);
            return new InfluencersBecomeAnAmbassadorPage(context);
        }
    }
}
