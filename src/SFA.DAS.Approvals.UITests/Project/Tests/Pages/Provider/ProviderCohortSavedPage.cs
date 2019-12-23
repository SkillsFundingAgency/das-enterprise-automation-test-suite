using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.Configuration;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCohortSavedPage : BasePage
    {
        protected override string PageTitle => "Cohort saved but not sent";

        protected override By PageHeader => By.CssSelector(".green-box-alert");


        #region Helpers and Context
        private readonly TableRowHelper _tableRowHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion


        public ProviderCohortSavedPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _tableRowHelper = context.Get<TableRowHelper>();
            VerifyPage();
        }

        public ProviderReviewYourCohortPage SelectViewCurrentCohortDetails()
        {
            _tableRowHelper.SelectRowFromTable("Details", _objectContext.GetCohortReference());
            return new ProviderReviewYourCohortPage(_context);
        }
    }
}
