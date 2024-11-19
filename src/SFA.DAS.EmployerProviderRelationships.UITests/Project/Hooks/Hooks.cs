namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Hooks;

[Binding]
public class Hooks(ScenarioContext context)
{
    private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

    private readonly DbConfig _dbConfig = context.Get<DbConfig>();

    protected readonly TryCatchExceptionHelper _tryCatch = context.Get<TryCatchExceptionHelper>();

    private EprDataHelper _eprDataHelper;

    [BeforeScenario(Order = 32)]
    public void SetUpHelpers()
    {
        context.Set(new RelationshipsSqlDataHelper(_objectContext, _dbConfig));

        context.Set(_eprDataHelper = new EprDataHelper());
    }

    [BeforeScenario(Order = 33)]
    [Scope(Tag = "createemployeraccount")]
    public void SetUpAornData()
    {
        var tprSqlDataHelper = context.Get<TprSqlDataHelper>();

        var (paye, aornNumber, orgName) = tprSqlDataHelper.CreateAornData(context.ScenarioInfo.Tags.Contains("singleorgaorn"));

        _eprDataHelper.EmployerPaye = paye;

        _eprDataHelper.EmployerAorn = aornNumber;

        _eprDataHelper.EmployerOrganisationName = orgName;

        var randomPersonNameHelper = new RandomPersonNameHelper();

        _eprDataHelper.EmployerFirstName = randomPersonNameHelper.FirstName;

        _eprDataHelper.EmployerLastName = randomPersonNameHelper.LastName;
    }

    [AfterScenario(Order = 23)]
    [Scope(Tag = "deletepermission")]
    public void DeleteProviderRelation() => _tryCatch.AfterScenarioException(() => new DeleteProviderRelationinDbHelper(context).DeleteProviderRelation());


    [AfterScenario(Order = 22)]
    [Scope(Tag = "deleterequest")]
    public void DeleteProviderRequest() => _tryCatch.AfterScenarioException(() => new DeleteProviderRelationinDbHelper(context).DeleteProviderRequest(_eprDataHelper.RequestId));
}
