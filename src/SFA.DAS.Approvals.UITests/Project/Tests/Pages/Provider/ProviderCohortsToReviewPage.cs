using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCohortsToReviewPage : BasePage
    {
        protected override string PageTitle => "Cohorts to review, update or approve";

        #region Helpers and Context
        private readonly TableRowHelper _tableRowHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion


        public ProviderCohortsToReviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _tableRowHelper = context.Get<TableRowHelper>();
            VerifyPage();
        }

        public ProviderReviewYourCohortPage SelectViewCurrentCohortDetails()
        {
            _tableRowHelper.SelectRowFromTable("Details", _objectContext.GetCohortReference());
            //SelectCohort(_objectContext.GetCohortReference());
            return new ProviderReviewYourCohortPage(_context);
        }

        private void SelectCohort(string cohotRef)
        {
            IWebDriver _webDriver = _context.GetWebDriver();
            var table = _webDriver.FindElement(By.TagName("table"));
            var tableRows = table.FindElements(By.CssSelector("tbody tr"));
            var links = _webDriver.FindElements(By.PartialLinkText("Details"));

            if (tableRows.Count > 0)
            {
                for (int i = 1; i < tableRows.Count; i++)
                {
                    var row = _webDriver.FindElement(By.XPath($"/html/body/main/div[2]/div/table/tbody/tr[{i}]/td[2]"));
                    if (row.Text.Contains(cohotRef))
                    {
                        _webDriver.FindElement(By.XPath($"/html/body/main/div[2]/div/table/tbody/tr[{i}]/td[4]/a"));
                        break;
                    }
                }
            }          


        }
    }
}
