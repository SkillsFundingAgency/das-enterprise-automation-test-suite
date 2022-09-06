using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.ApprenticeCommitments.UITests.Project;

namespace SFA.DAS.ProvideFeedback.UITests.Project;

public class ApprenticeFeedbackUser : ApprenticeUser { }

[Binding, Scope(Tag = "apprenticefeedback")]
public class ApprenticeFeedbackHooks : BaseHooks
{

    private readonly DbConfig _dbConfig;

    public ApprenticeFeedbackHooks(ScenarioContext context) : base(context) => _dbConfig = context.Get<DbConfig>();

    [BeforeScenario(Order = 31)]
    public void NavigateToApprenticePortal() => _context.Get<TabHelper>().GoToUrl(UrlConfig.Apprentice_BaseUrl);

    [BeforeScenario(Order = 32)]
    public void SetUpHelpers()
    {
        _context.Set(new ApprenticeCommitmentsSqlDbHelper(_dbConfig));
        _context.Set(new ApprenticeCommitmentsAccountsSqlDbHelper(_dbConfig));
    } 

    [AfterScenario(Order = 33)]
    public void ClearDownEmployerFeedbackResult() => 
        _tryCatch.AfterScenarioException(() => new ApprenticeFeedbackSqlHelper(_dbConfig).ClearDownApprenticeFeedbackResult(_objectContext.GetApprenticeId(), _objectContext.GetProviderUkprn()));

}
