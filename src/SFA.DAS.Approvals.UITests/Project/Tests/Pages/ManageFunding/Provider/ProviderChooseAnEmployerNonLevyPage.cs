using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderChooseAnEmployerNonLevyPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Choose an employer";

        private By EmployersAvailable => By.CssSelector("table tbody tr");

        public ProviderChooseAnEmployerNonLevyPage(ScenarioContext context) : base(context)  { }

        internal ProviderConfirmEmployerNonLevyPage ChooseAnEmployer(string employerType)
        {
            var employerUser = employerType == "Levy" ? context.GetUser<LevyUser>() : (EasAccountUser)context.GetUser<NonLevyUser>();
            var employerName = employerUser.OrganisationName.Substring(0, 3) + "%";
            string agreementId = context.Get<AccountsDbSqlHelper>().GetAgreementId(employerUser.Username, employerName).Trim();
            tableRowHelper.SelectRowFromTable("Select", agreementId);
            return new ProviderConfirmEmployerNonLevyPage(context);
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
