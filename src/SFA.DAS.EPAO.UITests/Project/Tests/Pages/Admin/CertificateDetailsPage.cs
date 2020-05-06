using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class CertificateDetailsPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Certificate";

        protected override By PageHeader => By.CssSelector(".govuk-heading-xl");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By SearchButton => By.CssSelector("a.govuk-button[href*='/select']");

        private By History => By.CssSelector("#history");

        public CertificateDetailsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public CertificateDetailsPage ShowAllHistory()
        {
            formCompletionHelper.ClickElement(SearchButton);
            VerifyPage(History);
            VerifyPage(SearchButton, "Show summary");
            return new CertificateDetailsPage(_context);
        }
    }
}
