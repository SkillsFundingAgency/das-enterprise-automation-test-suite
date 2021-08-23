using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Influencers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages
{
    public abstract class CampaingnsHeaderBasePage : CampaingnsVerifyLinks
    {

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        protected By Apprentice => By.CssSelector("a[href*='apprentice']");

        protected By Employer => By.CssSelector("a[href*='employers']");

        protected By Influencers => By.CssSelector("a[href*='influencers']");

        protected By SiteMap => By.CssSelector("#link-footer-sitemap");

        public CampaingnsHeaderBasePage(ScenarioContext context) : base(context) => _context = context;

        public ApprenticeHubPage NavigateToApprenticeshipHubPage()
        {
            formCompletionHelper.ClickElement(Apprentice);
            return new ApprenticeHubPage(_context);
        }

        public EmployerHubPage NavigateToEmployerHubPage()
        {
            formCompletionHelper.ClickElement(Employer);
            return new EmployerHubPage(_context);
        }

        public InfluencersHubPage NavigateToInfluencersHubPage()
        {
            formCompletionHelper.ClickElement(Influencers);
            return new InfluencersHubPage(_context);
        }

        public SiteMapPage NavigateToSiteMapPage()
        {
            formCompletionHelper.ClickElement(SiteMap);
            return new SiteMapPage(_context);
        }
    }
}
