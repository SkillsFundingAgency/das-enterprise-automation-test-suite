using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class OrganisationDetailsPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Organisation details";

        protected override By PageHeader => By.CssSelector(".govuk-caption-xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public OrganisationDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }
    }
}
