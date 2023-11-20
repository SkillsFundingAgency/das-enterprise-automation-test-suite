using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public abstract class ProviderApprenticeRequestsSubPage : ApprovalsBasePage
    {
        public ProviderApprenticeRequestsSubPage(ScenarioContext context) : base(context)
        {
                
        }

        protected void SelectCurrentCohortDetailsFromTable()
        {
            javaScriptHelper.ScrollToTheBottom();
            tableRowHelper.SelectRowFromTableDescending("Details", objectContext.GetCohortReference());
        }

        protected void SelectCurrentCohortDetailsFromTable(string key) => tableRowHelper.SelectRowFromTable("Details", key);

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