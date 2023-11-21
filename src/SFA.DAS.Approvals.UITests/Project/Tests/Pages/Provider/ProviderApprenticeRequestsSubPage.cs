using Dynamitey.DynamicObjects;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public abstract class ProviderApprenticeRequestsSubPage : ApprovalsBasePage
    {
        private static By ReferenceSelector => By.CssSelector("[data-label=Reference]");

        public ProviderApprenticeRequestsSubPage(ScenarioContext context) : base(context)
        {
                
        }

        protected void SelectCurrentCohortDetailsFromTable()
        {
            javaScriptHelper.ScrollToTheBottom();
            tableRowHelper.SelectRowFromTableDescending("Details", objectContext.GetCohortReference());
        }

        protected void SelectCurrentCohortDetailsFromTable(string key) => tableRowHelper.SelectRowFromTable("Details", key);

        public List<string> GetAllCohorts()=> pageInteractionHelper.FindElements(ReferenceSelector).Select(x => x.Text).ToList();

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