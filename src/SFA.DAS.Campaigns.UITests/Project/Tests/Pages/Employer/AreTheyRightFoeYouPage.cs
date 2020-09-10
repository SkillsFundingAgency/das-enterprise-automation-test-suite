using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer
{
    public class AreTheyRightFoeYouPage: EmployerBasePage
    {
        protected override string PageTitle => "Page not found";
        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public AreTheyRightFoeYouPage(ScenarioContext context):base(context) { }
    }
}