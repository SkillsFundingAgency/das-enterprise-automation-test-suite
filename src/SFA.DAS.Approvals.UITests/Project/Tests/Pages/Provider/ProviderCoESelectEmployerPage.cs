using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ProviderCoESelectEmployerPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Choose a new employer";

        protected override bool TakeFullScreenShot => false;

        public ProviderCoEConfirmNewEmployerPage SelectNewEmployer()
        {
            var newEmployerUser = context.GetUser<EmployerWithMultipleAccountsUser>();

            var newEmployerName = newEmployerUser.SecondOrganisationName[..10] + "%";
            
            string agreementId = context.Get<AccountsDbSqlHelper>().GetAgreementId(newEmployerUser.Username, newEmployerName);

            tableRowHelper.SelectRowFromTable("Select", agreementId);
            
            return new ProviderCoEConfirmNewEmployerPage(context);
        }
    }
}
