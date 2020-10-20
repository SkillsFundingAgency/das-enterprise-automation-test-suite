using SFA.DAS.Roatp.UITests.Project.Helpers.RoatpApply;
using SFA.DAS.Roatp.UITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project
{
    [Binding, Scope(Tag = "roatpapplycreateaccount")]
    public class RoatpApplyCreateAccountHooks : RoatpBaseHooks
    {
        private readonly ScenarioContext _context;
        private readonly RoatpApplyContactSqlDbHelper _roatpApplyContactSqlDbHelper;
        private readonly LoginInvitationsSqlDbHelper _loginInvitationsSqlDbHelper;
        private RoatpApplyDataHelpers _applydataHelpers;

        public RoatpApplyCreateAccountHooks(ScenarioContext context) : base(context) 
        {
            _context = context;
            _roatpApplyContactSqlDbHelper = new RoatpApplyContactSqlDbHelper(config);
            _loginInvitationsSqlDbHelper = new LoginInvitationsSqlDbHelper(config);
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            _applydataHelpers = new RoatpApplyDataHelpers(_context.Get<RandomDataGenerator>());
            _context.Set(_applydataHelpers);
        }

        [BeforeScenario(Order = 34)]
        public void ClearDownData() 
        {
            var email = _applydataHelpers.CreateAccountEmail;
            _roatpApplyContactSqlDbHelper.DeleteContact(email);
            _loginInvitationsSqlDbHelper.DeleteUser(email);
        }

        [BeforeScenario(Order = 36)]
        public void NavigateToRoatpApply() => GoToUrl(UrlConfig.Apply_BaseUrl);
    }
}
