namespace SFA.DAS.TestDataCleanup.Project.Tests.StepDefinitions;

[Binding]
public class TestdataCleanupWithAccountId(ScenarioContext context)
{
    private readonly TestdataCleanupStepsHelper _testDataCleanUpStepsHelper = new(context);
    private readonly DbConfig _dbConfig = context.Get<DbConfig>();
    private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

    [Then(@"the test data are cleaned up in comt db for accounts between '(\d*)' and '(\d*)'")]
    public void TestDataAreCleanedUpInComtDbs(int greaterThan, int lessThan) => _testDataCleanUpStepsHelper.CleanUpComtTestData(greaterThan, lessThan);

    [Then(@"the test data are cleaned up in prel db for accounts between '(\d*)' and '(\d*)'")]
    public void TestDataAreCleanedUpInPrelDb(int greaterThan, int lessThan) => _testDataCleanUpStepsHelper.CleanUpPrelTestData(greaterThan, lessThan);

    [Then(@"the test data are cleaned up in pfbe db for accounts between '(\d*)' and '(\d*)'")]
    public void TestDataAreCleanedUpInPfbeDb(int greaterThan, int lessThan) => _testDataCleanUpStepsHelper.CleanUpPfbeTestData(greaterThan, lessThan);

    [Then(@"the test data are cleaned up in fcast db for accounts between '(\d*)' and '(\d*)'")]
    public void TestDataAreCleanedUpInFcastDb(int greaterThan, int lessThan) => _testDataCleanUpStepsHelper.CleanUpEmpFcastTestData(greaterThan, lessThan);

    [Then(@"the test data are cleaned up in fin db for accounts between '(\d*)' and '(\d*)'")]
    public void TestDataAreCleanedUpInFinDb(int greaterThan, int lessThan) => _testDataCleanUpStepsHelper.CleanUpEmpFinTestData(greaterThan, lessThan);

    [Then(@"the test data are cleaned up in rsvr db for accounts between '(\d*)' and '(\d*)'")]
    public void TestDataAreCleanedUpInRsvrDb(int greaterThan, int lessThan) => _testDataCleanUpStepsHelper.CleanUpRsvrTestData(greaterThan, lessThan);

    [Then(@"the test data are cleaned up in emp inc db for accounts between '(\d*)' and '(\d*)'")]
    public void TestDataAreCleanedUpInEmpIncDb(int greaterThan, int lessThan) => _testDataCleanUpStepsHelper.CleanUpEmpIncTestData(greaterThan, lessThan);

    [Then(@"the test data are cleaned up in ltm db for accounts between '(\d*)' and '(\d*)'")]
    public void ThenTheTestDataAreCleanedUpInLtmDb(int greaterThan, int lessThan) => _testDataCleanUpStepsHelper.CleanUpEasLtmTestData(greaterThan, lessThan);

    [Then(@"the test data are cleaned up in acomt db for accounts (.*)")]
    public void ThenTheTestDataAreCleanedUpInAcomtDbForAccounts(string accountidsTodelete) => new TestDataCleanupAComtSqlDataHelper(_objectContext, _dbConfig).CleanUpAComtTestData(Split(accountidsTodelete));

    [Then(@"the test data are cleaned up in appfb db for accounts (.*)")]
    public void ThenTheTestDataAreCleanedUpInappfbDbForAccounts(string accountidsTodelete) => new TestDataCleanupAppfbqlDataHelper(_objectContext, _dbConfig).CleanUpAppfbTestData(Split(accountidsTodelete));

    private static List<string> Split(string accountidsTodelete) => accountidsTodelete.Split(",").ToList();
}
