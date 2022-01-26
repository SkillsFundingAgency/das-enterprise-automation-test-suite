using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.EPAO.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.TestDataCleanup.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly DbConfig _config;
        private readonly TryCatchExceptionHelper _tryCatch;
        private EPAOAdminDataHelper _ePAOAdminDataHelper;
        private EPAOAdminSqlDataHelper _ePAOAdminSqlDataHelper;
        private EPAOApplySqlDataHelper _ePAOApplySqlDataHelper;
        
        public Hooks(ScenarioContext context)
        {
            _context = context;
            _tryCatch = context.Get<TryCatchExceptionHelper>();
            _config = context.Get<DbConfig>();
        }

        [BeforeScenario(Order = 32)]
        public void SetUpHelpers()
        {
            _ePAOApplySqlDataHelper = new EPAOApplySqlDataHelper(_config);

            _context.Set(_ePAOApplySqlDataHelper);

            _ePAOAdminSqlDataHelper = new EPAOAdminSqlDataHelper(_config);

            _context.Set(_ePAOAdminSqlDataHelper);

            _context.Set(new EPAOAssesmentServiceDataHelper());

            _context.Set(new EPAOApplyDataHelper());

            _context.Set(new EPAOApplyStandardDataHelper());

            _ePAOAdminDataHelper = new EPAOAdminDataHelper();

            _context.Set(_ePAOAdminDataHelper);

            _context.Set(new EPAOAdminCASqlDataHelper(_config));
        }

        [BeforeScenario(Order = 33)]
        [Scope(Tag = "deleteorganisationstandards")]
        public void ClearStandards() => _ePAOAdminSqlDataHelper.DeleteOrganisationStandard(_ePAOAdminDataHelper.StandardCode, _ePAOAdminDataHelper.OrganisationEpaoId);

        [BeforeScenario(Order = 34)]
        [Scope(Tag = "resetapplyuserorganisationid")]
        public void ResetApplyUserOrganisationId() => _ePAOApplySqlDataHelper.ResetApplyUserOrganisationId(_context.GetUser<EPAOApplyUser>().Username);

        [BeforeScenario(Order = 35)]
        [Scope(Tag = "deletestandardwithdrawal")]
        public void DeleteStandardWithdrawalApplication() => _ePAOApplySqlDataHelper.DeleteStandardWithdrawalApplication(_context.GetUser<EPAOWithdrawalUser>().Username);

        [BeforeScenario(Order = 36)]
        [Scope(Tag = "deleteorganisationstandardversion")]
        public void ClearOrgganisationStandardVersion() => _ePAOApplySqlDataHelper.DeleteOrganisationStandardVersion();

        [AfterScenario(Order = 32)]
        [Scope(Tag = "deleteorganisationcontact")]
        public void ClearContact() => _tryCatch.AfterScenarioException(() => _ePAOAdminSqlDataHelper.DeleteContact(_ePAOAdminDataHelper.Email));

        [AfterScenario(Order = 33)]
        [Scope(Tag = "deleteorganisation")]
        public void ClearOrganisation() => _tryCatch.AfterScenarioException(() => _ePAOAdminSqlDataHelper.DeleteOrganisation(_ePAOAdminDataHelper.NewOrganisationUkprn));

        [AfterScenario(Order = 34)]
        [Scope(Tag = "makeorganisationlive")]
        public void MakeOrganisationLive() => _tryCatch.AfterScenarioException(() => _ePAOAdminSqlDataHelper.UpdateOrgStatusToLive(_ePAOAdminDataHelper.MakeLiveOrganisationEpaoId));
    }
}
