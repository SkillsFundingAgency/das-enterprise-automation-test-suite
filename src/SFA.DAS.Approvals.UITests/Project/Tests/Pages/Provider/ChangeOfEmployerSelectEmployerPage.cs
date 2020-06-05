using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider
{
    public class ChangeOfEmployerSelectEmployerPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Choose a new employer";

        private readonly AgreementIdSqlHelper _agreementIdSqlHelper;

        private readonly ScenarioContext _context;

        private readonly string _newEmployerEmail;

        public ChangeOfEmployerSelectEmployerPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _agreementIdSqlHelper = context.Get<AgreementIdSqlHelper>();
            _newEmployerEmail = context.GetUser<TransfersUser>().Username;
        }

        public ChangeOfEmployerConfirmNewEmployerPage SelectNewEmployer()
        {
            string _newEmployerName = _context.GetTransfersConfig<TransfersConfig>().ReceiverOrganisationName;

            _newEmployerName = _newEmployerName.Substring(0, 10) + "%";
            
            string agreementId = _agreementIdSqlHelper.GetAgreementId(_newEmployerEmail, _newEmployerName);

            tableRowHelper.SelectRowFromTable("Select", agreementId);
            
            return new ChangeOfEmployerConfirmNewEmployerPage(_context);
        }

    }
}
