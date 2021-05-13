using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ChangeOfEmployerSelectEmployerPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Choose a new employer";

        private readonly ScenarioContext _context;

        public ChangeOfEmployerSelectEmployerPage(ScenarioContext context) : base(context) => _context = context;

        public ChangeOfEmployerConfirmNewEmployerPage SelectNewEmployer()
        {
            var newEmployerUser = _context.GetUser<ChangeOfEmployerLevyUser>();

            var newEmployerName = newEmployerUser.SecondOrganisationName.Substring(0, 10) + "%";
            
            string agreementId = _context.Get<AgreementIdSqlHelper>().GetAgreementId(newEmployerUser.Username, newEmployerName);

            tableRowHelper.SelectRowFromTable("Select", agreementId);
            
            return new ChangeOfEmployerConfirmNewEmployerPage(_context);
        }
    }
}
