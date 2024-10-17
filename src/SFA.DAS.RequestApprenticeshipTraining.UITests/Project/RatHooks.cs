using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Registration.UITests.Project;
using SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Helpers;
using SFA.DAS.TestDataExport.Helper;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project;

[Binding]
public class RatHooks(ScenarioContext context)
{
    private readonly ObjectContext _objectContext = context.Get<ObjectContext>();
    private readonly DbConfig _dbConfig = context.Get<DbConfig>();
    protected readonly TryCatchExceptionHelper _tryCatch = context.Get<TryCatchExceptionHelper>();
    private RatDataHelper _ratDataHelper;


    [BeforeScenario(Order = 32)]
    public void SetUpHelpers()
    {
        context.Set(new RoatpV2SqlDataHelper(_objectContext, _dbConfig));

        context.Set(_ratDataHelper = new RatDataHelper());
    }

    [AfterScenario(Order = 33)]
    public void ClearDownRatData()
    {
        if (context.TestError != null) return;

        _tryCatch.AfterScenarioException(() => new RatSqlHelper(_objectContext, _dbConfig).ClearDownRatData(_objectContext.GetDBAccountId(), _ratDataHelper.RequestId));
    }
}
