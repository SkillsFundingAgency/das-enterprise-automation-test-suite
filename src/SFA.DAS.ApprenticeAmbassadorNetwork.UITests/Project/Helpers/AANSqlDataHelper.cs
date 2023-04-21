namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project.Helpers;

public class AANSqlDataHelper : SqlDbHelper
{
    public AANSqlDataHelper(DbConfig dbConfig) : base(dbConfig.AANDbConnectionString) { }

    public void ClearRegulation(string ukprn, string larsCode) => ExecuteSqlCommand($"update providercourse set IsApprovedByRegulator = NULL " +
        $"where LarsCode = '{larsCode}' and providerid = (select Id from provider where ukprn = {ukprn})");

}
