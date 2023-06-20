using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderChooseAnEmployerNonLevyPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Choose an employer";

        public ProviderChooseAnEmployerNonLevyPage(ScenarioContext context) : base(context)  { }

        internal ProviderConfirmEmployerPage ChooseAnEmployer(string employerType)
        {
            var employerUser = employerType == "Levy" ? context.GetUser<LevyUser>() : (EasAccountUser)context.GetUser<NonLevyUser>();

            var employerName = employerUser.OrganisationName.Substring(0, 3) + "%";

            string agreementId = context.Get<AccountsDbSqlHelper>().GetAgreementId(employerUser.Username, employerName).Trim();

            tableRowHelper.SelectRowFromTable("Select", agreementId);

            return new ProviderConfirmEmployerPage(context);
        }
    }
}
