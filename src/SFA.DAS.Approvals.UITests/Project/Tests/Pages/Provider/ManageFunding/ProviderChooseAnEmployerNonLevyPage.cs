using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider.ManageFunding
{
    public class ProviderChooseAnEmployerNonLevyPage : BasePage
    {
        protected override string PageTitle => "Choose an employer";

        #region Helpers and Context
        private readonly TableRowHelper _tableRowHelper;
        private readonly ScenarioContext _context;
        #endregion

        public ProviderChooseAnEmployerNonLevyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _tableRowHelper = context.Get<TableRowHelper>();
            VerifyPage();
        }

        internal ProviderConfirmEmployerNonLevyPage ChooseAnEmployerNonLevyEOI()
        {
            _tableRowHelper.SelectRowFromTable("Select", "");
            return new ProviderConfirmEmployerNonLevyPage(_context);
        }
    }
}
