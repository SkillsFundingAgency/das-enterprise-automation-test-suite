using SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper;
using SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.BaseSqlDbHelper;
using SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper;

namespace SFA.DAS.TestDataExport.StepDefinitions;

[Binding]
public class VerifyDbConnectionSteps(ScenarioContext context)
{
    private readonly DbConfig _dbConfig = context.Get<DbConfig>();

    private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

    private List<string> _exception;

    [Then(@"the db connection are verified")]
    public void ThenTheDbConnectionAreVerified()
    {
        _exception = new List<string>();

        AssertDbConnection(new AssessorDbSqlDataHelper(_objectContext, _dbConfig));
        AssertDbConnection(new LoginDbSqlDataHelper(_objectContext, _dbConfig));
        AssertDbConnection(new QnaDbSqlDataHelper(_objectContext, _dbConfig));
        AssertDbConnection(new ApplyDbSqlDataHelper(_objectContext, _dbConfig));
        AssertDbConnection(new RoatpDbSqlDataHelper(_objectContext, _dbConfig));

        AssertDbConnection(new TestDataCleanupAComtSqlDataHelper(_objectContext, _dbConfig));
        AssertDbConnection(new TestDataCleanupComtSqlDataHelper(_objectContext, _dbConfig));
        AssertDbConnection(new TestDataCleanUpEasLtmcSqlDataHelper(_objectContext, _dbConfig));
        AssertDbConnection(new TestDataCleanUpEmpFcastSqlDataHelper(_objectContext, _dbConfig));
        AssertDbConnection(new TestDataCleanUpEmpFinSqlDataHelper(_objectContext, _dbConfig));
        AssertDbConnection(new TestDataCleanUpEmpIncSqlDataHelper(_objectContext, _dbConfig));
        AssertDbConnection(new TestDataCleanUpPfbeDbSqlDataHelper(_objectContext, _dbConfig));
        AssertDbConnection(new TestDataCleanUpPrelDbSqlDataHelper(_objectContext, _dbConfig));
        AssertDbConnection(new TestDataCleanUpPsrDbSqlDataHelper(_objectContext, _dbConfig));
        AssertDbConnection(new TestDataCleanUpRsvrSqlDataHelper(_objectContext, _dbConfig));

        AssertDbConnection(new EmploymentCheckDbSqlDataHelper(_objectContext, _dbConfig));

        AssertDbConnection(new TestDataCleanUpEasAccDbSqlDataHelper(_objectContext, _dbConfig));
        AssertDbConnection(new ACommitmentLoginDbSqlDataHelper(_objectContext, _dbConfig));
        AssertDbConnection(new CrsDbSqlDataHelper(_objectContext, _dbConfig));
        AssertDbConnection(new TprDbSqlDataHelper(_objectContext, _dbConfig));
        AssertDbConnection(new TestDataCleanUpUsersDbSqlDataHelper(_objectContext, _dbConfig));

        if (_exception.Any())
        {
            _exception.ForEach(x => SetDebugInformation(x));

            throw new Exception(string.Join(Environment.NewLine, _exception.Select(x => x)));
        }
    }

    private void AssertDbConnection(ProjectSqlDbHelper helper)
    {
        string caller = helper.GetCaller();

        if (helper.ExcludeEnvironments)
        {
            SetDebugInformation($"EXCLUDED -'{caller}', does not exist for this environment");
            return;
        }

        try
        {
            string catalog = helper.GetTableCatalog();

            StringAssert.StartsWith("das-", catalog);

            SetDebugInformation($"'{caller}' connected sucessfully to '{catalog}'");

        }
        catch (Exception)
        {
            _exception.Add($"FAILED - '{caller}' could not be connected");
        }
    }

    private void SetDebugInformation(string message) => _objectContext.SetDebugInformation(message);
}