using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataExport.Helper;
using SFA.DAS.TransferMatching.UITests.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project
{
    [Binding]
    public class Hooks(ScenarioContext context)
    {
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();
        private readonly DbConfig _dbConfig = context.Get<DbConfig>();
        private readonly TryCatchExceptionHelper _tryCatch = context.Get<TryCatchExceptionHelper>();
        private TransferMatchingSqlDataHelper _transferMatchingSqlDataHelper;
        private CommitmentsSqlDataHelper _commitmentsSqlDataHelper;

        [BeforeScenario(Order = 42)]
        public void SetUpDataHelpers()
        {
            var courseDetails = context.Get<ApprenticeCourseDataHelper>().CourseDetails;

            context.Set(new TMDataHelper(courseDetails));

            _transferMatchingSqlDataHelper = new TransferMatchingSqlDataHelper(_objectContext, _dbConfig);

            context.Set(_transferMatchingSqlDataHelper);

            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(_objectContext, _dbConfig);

            context.Set(_commitmentsSqlDataHelper);

            _objectContext.SetPledgeDetailList();
        }

        [AfterScenario(Order = 41)]
        public void DeletePledge()
        {
            if (context.TestError == null) _tryCatch.AfterScenarioException(() => _transferMatchingSqlDataHelper.DeletePledge(_objectContext.GetPledgeDetailList()));
        }
    }
}
