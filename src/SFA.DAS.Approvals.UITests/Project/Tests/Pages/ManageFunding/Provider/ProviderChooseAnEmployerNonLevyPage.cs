using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.Login.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Provider
{
    public class ProviderChooseAnEmployerNonLevyPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Choose an employer";

        internal ProviderConfirmEmployerPage ChooseLevyEmployer() => ChooseAnEmployer("Levy");

        internal ProviderConfirmEmployerPage ChooseNonLevyEmployer() => ChooseAnEmployer("NonLevy");
        internal ProviderConfirmEmployerPage ChooseNonLevyEmployerAtMaxReservationLimit() => ChooseAnEmployer("NonLevyUserAtMaxReservationLimit");

        private ProviderConfirmEmployerPage ChooseAnEmployer(string employerType)
        {

            EasAccountUser employerUser = employerType switch
            {
                "NonLevy" => context.GetUser<NonLevyUser>(),
                "NonLevyUserAtMaxReservationLimit" => context.GetUser<NonLevyUserAtMaxReservationLimit>(),
                _ => context.GetUser<LevyUser>()
            };

            var employerName = employerUser.OrganisationName[..3] + "%";

            string agreementId = context.Get<AccountsDbSqlHelper>().GetAgreementId(employerUser.Username, employerName).Trim();

            tableRowHelper.SelectRowFromTable("Select", agreementId);

            return new ProviderConfirmEmployerPage(context);
        }
    }
}
