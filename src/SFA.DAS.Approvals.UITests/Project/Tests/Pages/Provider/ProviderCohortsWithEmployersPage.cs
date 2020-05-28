using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCohortsWithEmployersPage : BasePage
    {
        protected override string PageTitle => "Apprentice details with employer";

        #region Helpers and Context
        private readonly TableRowHelper _tableRowHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion

        public ProviderCohortsWithEmployersPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _tableRowHelper = context.Get<TableRowHelper>();
            VerifyPage();
        }

        internal ProviderViewYourCohortPage SelectViewCurrentCohortDetails()
        {
            _tableRowHelper.SelectRowFromTable("Details", _objectContext.GetCohortReference());
            return new ProviderViewYourCohortPage(_context);
        }

    }
}
