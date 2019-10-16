using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderChooseAnEmployerNonLevyPage : BasePage
    {
        protected override string PageTitle => "Choose an employer";

        #region Helpers and Context
        private readonly TableRowHelper _tableRowHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion

        public ProviderChooseAnEmployerNonLevyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _tableRowHelper = context.Get<TableRowHelper>();
            VerifyPage();
        }

        internal ProviderConfirmEmployerNonLevyPage ChooseAnEmployerNonLevyEOI()
        {
            _tableRowHelper.SelectRowFromTable("Select", _objectContext.GetAgreementId());
            return new ProviderConfirmEmployerNonLevyPage(_context);
        }
    }
}
