using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ChangeOfEmployerSelectEmployerPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Choose a new employer";

        protected override bool TakeFullScreenShot => false;

        public ChangeOfEmployerSelectEmployerPage(ScenarioContext context) : base(context)  { }

        public ChangeOfEmployerConfirmNewEmployerPage SelectNewEmployer()
        {
            var newEmployerUser = context.GetUser<ChangeOfEmployerLevyUser>();

            var newEmployerName = newEmployerUser.SecondOrganisationName.Substring(0, 10) + "%";
            
            string agreementId = context.Get<AgreementIdSqlHelper>().GetAgreementId(newEmployerUser.Username, newEmployerName);

            tableRowHelper.SelectRowFromTable("Select", agreementId);
            
            return new ChangeOfEmployerConfirmNewEmployerPage(context);
        }
    }
}
