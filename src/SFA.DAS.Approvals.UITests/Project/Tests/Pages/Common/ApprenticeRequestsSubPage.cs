using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Common
{
    public abstract class ApprenticeRequestsSubPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        private static By TableRows => By.CssSelector(".govuk-table .govuk-table__body .govuk-table__row");

        private static By ReferenceSelector => By.CssSelector("[data-label=Reference]");

        protected void SelectCurrentCohortDetailsFromTable()
        {
            javaScriptHelper.ScrollToTheBottom();
            tableRowHelper.SelectRowFromTableDescending("Details", objectContext.GetCohortReference());
        }

        protected void SelectCurrentCohortDetailsFromTable(string key) => tableRowHelper.SelectRowFromTable("Details", key);

        public List<string> GetAllCohorts() => pageInteractionHelper.FindElements(ReferenceSelector).Select(x => x.Text).ToList();

        public List<string> GetAllCohorts(string key)
        {
            return pageInteractionHelper.FindElements(TableRows).Where(x => x.Text.Contains(key)).ToList().Select(y => y.FindElement(ReferenceSelector).Text).ToList();
        }

        internal bool ViewDraftOrReadyToReviewCohortDetails(string key)
        {
            try
            {
                SelectCurrentCohortDetailsFromTable(key);

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}