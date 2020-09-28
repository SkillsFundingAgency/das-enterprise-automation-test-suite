using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCohortsToReviewPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprentice details ready for review";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly JavaScriptHelper _javaScriptHelper;
        #endregion

        public ProviderCohortsToReviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _javaScriptHelper = _context.Get<JavaScriptHelper>();
        }


        public ProviderReviewYourCohortPage SelectViewCurrentCohortDetails()
        {
            _javaScriptHelper.ScrollToTheBottom();
            tableRowHelper.SelectRowFromTableDescending("Details", objectContext.GetCohortReference());
            return new ProviderReviewYourCohortPage(_context);
        }        
    }
}