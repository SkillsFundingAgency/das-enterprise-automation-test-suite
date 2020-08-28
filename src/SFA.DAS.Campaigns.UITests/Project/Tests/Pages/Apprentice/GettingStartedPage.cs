using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice
{
    public class GettingStartedPage: ApprenticeBasePage
    {
        protected override string PageTitle => "Getting started";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public GettingStartedPage(ScenarioContext context):base(context)
        {
            _context = context;
        }
    }
}