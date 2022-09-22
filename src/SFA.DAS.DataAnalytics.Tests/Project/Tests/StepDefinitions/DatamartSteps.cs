namespace SFA.DAS.DataAnalytics.Tests.Project.Tests.StepDefinitions
{
    [Binding]
    public class DatamartSteps
    {
        private readonly DbConfig _dbConfig;
        private readonly DatamartSqlHelper _datamartSqlHelper;
        private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;

        public DatamartSteps(ScenarioContext context)
        {
            _dbConfig = context.Get<DbConfig>();
            _datamartSqlHelper = new DatamartSqlHelper(_dbConfig);
            _commitmentsSqlDataHelper = new CommitmentsSqlDataHelper(_dbConfig);
        }

        [Given(@"I update Payments data in datamart")]
        public void GivenIUpdatePaymentsDataInDatamart()
        {
            var datamartList = _datamartSqlHelper.GetPaymentsData();

            var commtList = _commitmentsSqlDataHelper.GetCommtData(datamartList.Count);

            Assert.That(commtList.Count, Is.GreaterThanOrEqualTo(datamartList.Count), "Not enough data found in commitments");

            List<string> updateQuery = new();

            for (int i = 0; i < datamartList.Count; i++)
            {
                var datamart = datamartList[i];
                var commt = commtList[i];
                updateQuery.Add($"update StgPmts.Payment set LearnerUln = {commt[1]}, ApprenticeshipId = {commt[0]} where LearnerUln = {datamart[0]} and ApprenticeshipId = {datamart[1]};");
            }

            _datamartSqlHelper.ExecuteSqlCommand(updateQuery);
        }
    }
}
