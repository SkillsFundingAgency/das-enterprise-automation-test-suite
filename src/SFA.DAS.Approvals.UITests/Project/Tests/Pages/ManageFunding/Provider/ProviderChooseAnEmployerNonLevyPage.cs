using OpenQA.Selenium;
using SFA.DAS.Registration.UITests.Project;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderChooseAnEmployerNonLevyPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Choose an employer";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By EmployersAvailable => By.CssSelector("table tbody tr");

        public ProviderChooseAnEmployerNonLevyPage(ScenarioContext context) : base(context) => _context = context;

        internal ProviderConfirmEmployerNonLevyPage ChooseAnEmployerNonLevy()
        {
            tableRowHelper.SelectRowFromTable("Select", objectContext.GetAgreementId());
            return new ProviderConfirmEmployerNonLevyPage(_context);
        }

        internal bool CanChooseAnEmployer()
        {
            var rows = pageInteractionHelper.FindElements(EmployersAvailable).ToList();

            if (rows.Count == 0)
            {
                throw new System.Exception("Test Exception: Create Cohort Link is displayed but no employer found");
            }
            else
            {
                return rows.Any(x => x.Text.Contains(objectContext.GetAgreementId()));
            }
        }
    }
}
