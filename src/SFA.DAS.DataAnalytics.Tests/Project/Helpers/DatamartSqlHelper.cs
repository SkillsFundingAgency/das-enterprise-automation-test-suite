namespace SFA.DAS.DataAnalytics.Tests.Project.Helpers;

public class DatamartSqlHelper : SqlDbHelper
{
    public DatamartSqlHelper(ObjectContext objectContext, DbConfig dBConfig) : base(objectContext, dBConfig.DatamartDbConnectionString) { }

    public List<string[]> GetPaymentsData() => GetMultipleData("select LearnerUln, ApprenticeshipId from StgPmts.Payment GROUP by LearnerUln, ApprenticeshipId");

    public void ExecuteSqlCommand(List<string> queryToExecute) => ExecuteSqlCommand(string.Join(string.Empty, queryToExecute));
}
