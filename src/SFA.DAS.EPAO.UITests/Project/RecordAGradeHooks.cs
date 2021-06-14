using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.EPAO.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.EPAO.UITests.Project
{
    [Binding, Scope(Tag = "recordagrade")]
    public class RecordAGradeHooks
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly TryCatchExceptionHelper _tryCatch;
        private readonly string[] _tags;

        public RecordAGradeHooks(ScenarioContext context)
        {
            _context = context;
            _tags = _context.ScenarioInfo.Tags;
            _objectContext = context.Get<ObjectContext>();
            _tryCatch = context.Get<TryCatchExceptionHelper>();
        }

        [BeforeScenario(Order = 35)]
        public void SetUpLearnerCriteria()
        {
            switch (true)
            {
                case bool _ when _tags.Contains("epaoca1standard1version0option"): SetLearnerCriteria(true, false, false, false); break;
                case bool _ when _tags.Contains("epaoca1standard1version1option"): SetLearnerCriteria(true, false, true, false); break;
                case bool _ when _tags.Contains("epaoca1standard2version0option"): SetLearnerCriteria(true, true, false, false); break;
                case bool _ when _tags.Contains("epaoca1standard2version1option"): SetLearnerCriteria(true, true, true, false); break;
                case bool _ when _tags.Contains("epaoca2standard1version0option"): SetLearnerCriteria(true, false, false, true); break;
                case bool _ when _tags.Contains("epaoca2standard1version1option"): SetLearnerCriteria(true, false, true, true); break;
                case bool _ when _tags.Contains("epaoca2standard2version0option"): SetLearnerCriteria(true, true, false, true); break;
                case bool _ when _tags.Contains("epaoca2standard2version1option"): SetLearnerCriteria(true, true, true, true); break;
            };
        }

        [AfterScenario(Order = 35)]
        public void Recordagrade() => _tryCatch.AfterScenarioException(() => _context.Get<EPAOAdminCASqlDataHelper>().DeleteCertificate(_objectContext.GetLearnerULN(), _objectContext.GetLearnerStandardCode()));

        private void SetLearnerCriteria(bool isActiveStandard, bool hasMultipleVersions, bool withOptions, bool hasMultiStandards)
        {
            var leanerDetails = new LeanerCriteria(isActiveStandard, hasMultipleVersions, withOptions, hasMultiStandards);
            
            _context.Set(leanerDetails);

            _objectContext.SetLearnerCriteria(isActiveStandard, hasMultipleVersions, withOptions, hasMultiStandards);
        }

    }
}
