using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class CohortsForReviewPage : BasePage
    {
        protected override string PageTitle => "Apprentice details ready for review";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly TableRowHelper _tableRowHelper;
        #endregion


        public CohortsForReviewPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _tableRowHelper = context.Get<TableRowHelper>();
            VerifyPage();
        }

        public ReviewYourCohortPage SelectViewCurrentCohortDetails()
        {
            _tableRowHelper.SelectRowFromTable("Details", _objectContext.GetCohortReference());
            return new ReviewYourCohortPage(_context);
        }
    }
}

