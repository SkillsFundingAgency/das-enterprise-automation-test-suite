using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Parent
{
    public class ParentHubPage : CampaingnsBasePage 
    {
        protected override string PageTitle => "PARENTS HUB";

        protected override By PageHeader => By.CssSelector(".header__caption--parents");

        protected By TheirCareer => By.CssSelector("#link-nav-parents");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ParentHubPage(ScenarioContext context) : base(context) => _context = context;

        public HelpShapeTheirCareerPage NavigateToTheirCareerPage()
        {
            formCompletionHelper.ClickElement(TheirCareer);
            return new HelpShapeTheirCareerPage(_context);
        }
    }
}
