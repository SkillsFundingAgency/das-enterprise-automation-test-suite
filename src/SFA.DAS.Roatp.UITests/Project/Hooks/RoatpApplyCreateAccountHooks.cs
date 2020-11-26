using SFA.DAS.Roatp.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project.Hooks
{
    [Binding, Scope(Tag = "roatpapplycreateaccount")]
    public class RoatpApplyCreateAccountHooks : RoatpBaseHooks
    {
        private readonly ScenarioContext _context;
        private readonly RoatpApplyContactSqlDbHelper _roatpApplyContactSqlDbHelper;
        private readonly LoginInvitationsSqlDbHelper _loginInvitationsSqlDbHelper;
        private RoatpApplyCreateUserDataHelpers _applydataHelpers;

        public RoatpApplyCreateAccountHooks(ScenarioContext context) : base(context)
        {
            _context = context;
            _roatpApplyContactSqlDbHelper = new RoatpApplyContactSqlDbHelper(config);
            _loginInvitationsSqlDbHelper = new LoginInvitationsSqlDbHelper(config);
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers() => SetUpCreateAccountApplyDataHelpers();

        [BeforeScenario(Order = 34)]
        public void ClearDownData()
        {
            if (_context.ScenarioInfo.Tags.Contains("perftestroatpapplycreateaccount")) { return; }

            _applydataHelpers = _context.Get<RoatpApplyCreateUserDataHelpers>();

            var email = _applydataHelpers.CreateAccountEmail;

            _roatpApplyContactSqlDbHelper.DeleteContact(email);

            _loginInvitationsSqlDbHelper.DeleteUser(email);
        }
    }
}
