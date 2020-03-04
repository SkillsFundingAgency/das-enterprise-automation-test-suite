using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Parent
{
    public class HelpShapeTheirCareerPage : CampaingnsBasePage
    {
        protected override string PageTitle => "HELP SHAPE THEIR CAREER";

        protected override By PageHeader => By.CssSelector(".heading-xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public HelpShapeTheirCareerPage(ScenarioContext context) : base(context) => _context = context;
    }
}
