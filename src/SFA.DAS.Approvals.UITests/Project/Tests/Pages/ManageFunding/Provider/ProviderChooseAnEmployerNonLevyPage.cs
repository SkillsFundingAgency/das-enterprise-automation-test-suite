using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderChooseAnEmployerNonLevyPage : BasePage
    {
        protected override string PageTitle => "Choose an employer";

        #region Helpers and Context
        private readonly TableRowHelper _tableRowHelper;
        private readonly PageInteractionHelper _pageInteractionHelper;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        #endregion

        private By EmployersAvailable => By.CssSelector("table tbody tr");

        public ProviderChooseAnEmployerNonLevyPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _tableRowHelper = context.Get<TableRowHelper>();
            _pageInteractionHelper = context.Get<PageInteractionHelper>();
            VerifyPage();
        }

        internal ProviderConfirmEmployerNonLevyPage ChooseAnEmployerNonLevy()
        {
            _tableRowHelper.SelectRowFromTable("Select", _objectContext.GetAgreementId());
            return new ProviderConfirmEmployerNonLevyPage(_context);
        }

        internal bool CanChooseAnEmployer()
        {
            var rows = _pageInteractionHelper.FindElements(EmployersAvailable).ToList();

            if (rows.Count == 0)
            {
                throw new System.Exception("Create Cohort Link is displayed but no employer found");
            }
            else
            {
                return rows.Any(x => x.Text.Contains(_objectContext.GetAgreementId()));
            }
        }
    }
}
