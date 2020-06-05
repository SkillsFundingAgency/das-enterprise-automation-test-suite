using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project.Tests.Pages.Admin
{
    public class SearchResultsPage : EPAOAdmin_BasePage
    {
        protected override string PageTitle => "Search results";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By ViewLearner => By.CssSelector(".govuk-link[href*='/select']");

        public SearchResultsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            VerifyPage();
        }

        public CertificateDetailsPage SelectACertificate()
        {
            formCompletionHelper.ClickElement(ViewLearner);
            return new CertificateDetailsPage(_context);
        }
    }
}
