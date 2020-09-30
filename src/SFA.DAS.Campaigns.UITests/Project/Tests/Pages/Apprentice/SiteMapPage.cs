using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class SiteMapPage: ApprenticeBasePage
    {
        private ScenarioContext context;
        protected override string PageTitle => "Sitemap";
        public SiteMapPage(ScenarioContext context) : base(context) { }
    }
}