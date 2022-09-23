namespace SFA.DAS.DataAnalytics.Tests.Project.Helpers;

public class CommitmentsSqlDataHelper : SqlDbHelper
{
    public CommitmentsSqlDataHelper(DbConfig dBConfig) : base(dBConfig.CommitmentsDbConnectionString) { }

    public List<string[]> GetCommtData(int count)
    {
        int propostion = Math.Abs(2 * count / 3);

        string query1 = $"select distinct top {propostion} id,ULN,PaymentStatus,hashaddatalocksuccess,enddate,LastUpdated " +
            "from dbo.apprenticeship group by id,ULN,PaymentStatus,hashaddatalocksuccess,enddate,LastUpdated " +
            "having uln is not null and PaymentStatus = 1 and hashaddatalocksuccess = 0 and enddate< '2021-08-01' and LastUpdated > '2020-12-01'";

        string query2 = $"select distinct top {count - propostion} id,ULN,PaymentStatus,hashaddatalocksuccess,enddate,LastUpdated " +
            "from dbo.apprenticeship group by id, ULN, PaymentStatus, hashaddatalocksuccess, enddate, LastUpdated " +
            "having uln is not null and PaymentStatus = 1 and hashaddatalocksuccess = 1 and enddate< '2021-08-01' and LastUpdated > '2020-06-01' ";

        var result1 = GetMultipleData(query1);

        var result2 = GetMultipleData(query2);

        result1.AddRange(result2);

        return result1;
    }
}
