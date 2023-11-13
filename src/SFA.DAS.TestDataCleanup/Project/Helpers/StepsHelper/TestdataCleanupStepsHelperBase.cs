namespace SFA.DAS.TestDataCleanup.Project.Helpers.StepsHelper;

public abstract class TestdataCleanupStepsHelperBase
{
    protected readonly DbConfig _dbConfig;

    private readonly ObjectContext _objectContext;

    public TestdataCleanupStepsHelperBase(ScenarioContext context)
    {
        _objectContext = context.Get<ObjectContext>();

        _dbConfig = context.Get<DbConfig>();
    }

    protected void ReportTestDataCleanUp(Func<(List<string>, List<string>)> func)
    {
        var (usersdeleted, userswithconstraints) = func.Invoke();

        TestCleanUpReport(usersdeleted, userswithconstraints);
    }

    protected TestdataCleanupWithAccountIdStepsHelper GetCleanUpHelper(int greaterThan, int lessThan)
    {
        var easAccountIds = new TestDataCleanUpEasAccDbSqlDataHelper(_objectContext, _dbConfig).GetAccountIds(greaterThan, lessThan);

        var easAccountsNotToDelete = easAccountIds.ListOfArrayToList(0);

        return new TestdataCleanupWithAccountIdStepsHelper(_objectContext, _dbConfig, greaterThan, lessThan, easAccountsNotToDelete);
    }

    private void TestCleanUpReport(List<string> usersdeleted, List<string> userswithconstraints)
    {
        if (usersdeleted.Count > 0) 
            _objectContext.Set($"{NextNumberGenerator.GetNextCount()}_testdatadeleted", $"{string.Join(Environment.NewLine, usersdeleted)}");
        
        if (userswithconstraints.Count > 0) 
            throw new Exception($"{Environment.NewLine}{string.Join(Environment.NewLine, userswithconstraints)}");
    }
}
