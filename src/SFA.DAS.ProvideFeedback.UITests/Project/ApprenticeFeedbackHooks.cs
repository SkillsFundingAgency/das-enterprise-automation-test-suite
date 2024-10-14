using SFA.DAS.ApprenticeCommitments.APITests.Project.Helpers.SqlDbHelpers;

namespace SFA.DAS.ProvideFeedback.UITests.Project;

[Binding, Scope(Tag = "apprenticefeedback")]
public class ApprenticeFeedbackHooks(ScenarioContext context) : BaseHooks(context)
{
    private readonly DbConfig _dbConfig = context.Get<DbConfig>();

    [BeforeScenario(Order = 31)]
    public void NavigateToApprenticePortal() => _context.Get<TabHelper>().GoToUrl(UrlConfig.Apprentice_BaseUrl);

    [BeforeScenario(Order = 32)]
    public void SetUpHelpers()
    {
        _context.Set(new ApprenticeCommitmentsSqlDbHelper(_objectContext, _dbConfig));
        _context.Set(new ApprenticeCommitmentsAccountsSqlDbHelper(_objectContext, _dbConfig));
    }
}
