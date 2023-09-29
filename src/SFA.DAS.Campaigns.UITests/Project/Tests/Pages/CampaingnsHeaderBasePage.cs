using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Influencers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public abstract class CampaingnsHeaderBasePage : CampaingnsVerifyLinks
    {
        protected static By Apprentice => By.CssSelector("a[href*='apprentice']");

        protected static By Employer => By.CssSelector("a[href*='employers']");

        protected static By Influencers => By.CssSelector("a[href*='influencers']");

        protected static By SiteMap => By.CssSelector("#link-footer-sitemap");

        public CampaingnsHeaderBasePage(ScenarioContext context) : base(context) { }

        public ApprenticeHubPage NavigateToApprenticeshipHubPage()
        {
            formCompletionHelper.ClickElement(Apprentice);
            return new ApprenticeHubPage(context);
        }

        public EmployerHubPage NavigateToEmployerHubPage()
        {
            formCompletionHelper.ClickElement(Employer);
            return new EmployerHubPage(context);
        }

        public InfluencersHubPage NavigateToInfluencersHubPage()
        {
            formCompletionHelper.ClickElement(Influencers);
            return new InfluencersHubPage(context);
        }

        public SiteMapPage NavigateToSiteMapPage()
        {
            formCompletionHelper.ClickElement(SiteMap);
            return new SiteMapPage(context);
        }
    }
}
