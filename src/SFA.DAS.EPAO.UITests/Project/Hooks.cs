using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.EPAO.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly DbConfig _config;
        private readonly TryCatchExceptionHelper _tryCatch;
        private EPAOAdminDataHelper _ePAOAdminDataHelper;
        private EPAOAdminSqlDataHelper _ePAOAdminSqlDataHelper;
        private EPAOAdminCASqlDataHelper _ePAOAdminCASqlDataHelper;
        private EPAOApplySqlDataHelper _ePAOApplySqlDataHelper;
        
        public Hooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
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



            var r = _context.Get<RandomDataGenerator>();

            _context.Set(new EPAOAssesmentServiceDataHelper(r));

            _context.Set(new EPAOApplyDataHelper(r));

            _context.Set(new EPAOApplyStandardDataHelper(r));

            _ePAOAdminDataHelper = new EPAOAdminDataHelper(r);

            _context.Set(_ePAOAdminDataHelper);

            _ePAOAdminCASqlDataHelper = new EPAOAdminCASqlDataHelper(_config, _context.ScenarioInfo.Tags);

            _context.Set(_ePAOAdminCASqlDataHelper);
        }

        [BeforeScenario(Order = 33)]
        [Scope(Tag = "deleteorganisationstandards")]
        public void ClearStandards() => _ePAOAdminSqlDataHelper.DeleteOrganisationStandard(_ePAOAdminDataHelper.StandardCode, _ePAOAdminDataHelper.OrganisationEpaoId);

        [BeforeScenario(Order = 34)]
        [Scope(Tag = "resetapplyuserorganisationid")]
        public void ResetApplyUserOrganisationId() => _ePAOApplySqlDataHelper.ResetApplyUserOrganisationId(_context.GetUser<EPAOApplyUser>().Username);

        [AfterScenario(Order = 32)]
        [Scope(Tag = "deleteorganisationcontact")]
        public void ClearContact() => _tryCatch.AfterScenarioException(() => _ePAOAdminSqlDataHelper.DeleteContact(_ePAOAdminDataHelper.Email));

        [AfterScenario(Order = 33)]
        [Scope(Tag = "deleteorganisation")]
        public void ClearOrganisation() => _tryCatch.AfterScenarioException(() => _ePAOAdminSqlDataHelper.DeleteOrganisation(_ePAOAdminDataHelper.NewOrganisationUkprn));

        [AfterScenario(Order = 34)]
        [Scope(Tag = "makeorganisationlive")]
        public void MakeOrganisationLive() => _tryCatch.AfterScenarioException(() => _ePAOAdminSqlDataHelper.UpdateOrgStatusToLive(_ePAOAdminDataHelper.MakeLiveOrganisationEpaoId));

        [AfterScenario(Order = 35)]
        [Scope(Tag = "recordagrade")]
        public void Recordagrade() => _tryCatch.AfterScenarioException(() => _ePAOAdminCASqlDataHelper.DeleteCertificate(_objectContext.GetLearnerULN(), _objectContext.GetLearnerStandardCode()));
    }
}
