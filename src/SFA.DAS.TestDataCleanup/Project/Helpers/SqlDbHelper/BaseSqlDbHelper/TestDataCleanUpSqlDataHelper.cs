namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.BaseSqlDbHelper;

public abstract class TestDataCleanUpSqlDataHelper : ProjectSqlDbHelper
{
    public abstract string SqlFileName { get; }

    public TestDataCleanUpSqlDataHelper(string connectionString) : base(connectionString) { }

    protected int CleanUpUsingEmail(List<string> emailsToDelete) => CleanUpTestData(emailsToDelete, (x) => $"Insert into #emails values ('{x}')", "create table #emails (email varchar(255))");

    protected int CleanUpUsingAccountIds(List<string> accountIdToDelete) => CleanUpTestData(accountIdToDelete, (x) => $"Insert into #accountids values ({x})", "create table #accountids (id bigint)");

    protected int CleanUpUsingCommtApprenticeshipIds(List<string[]> commtApprenticeshipIdsToDelete)
    {
        if (commtApprenticeshipIdsToDelete.IsNoDataFound()) return 0;

        return CleanUpTestData(commtApprenticeshipIdsToDelete.ListOfArrayToList(0), (x) => $"Insert into #commitmentsapprenticeshipid values ({x})", "create table #commitmentsapprenticeshipid (id bigint)");
    }

    protected int CleanUpTestData(List<string> listToDelete, Func<string, string> insertQueryFunc, string createQuery)
    {
        if (ExcludeEnvironments) return 0;

        var insertquery = listToDelete.Select(x => insertQueryFunc(x)).ToList();

        var sqlQuery = $"{createQuery};{insertquery.ToString(";")};" + FileHelper.GetSql(SqlFileName);

        var noOfRowsDeleted = TryExecuteSqlCommand(sqlQuery, connectionString) - listToDelete.Count;

        return noOfRowsDeleted;
    }

    protected (List<string>, List<string>) CleanUpTestData(Func<List<string>> getAccountidfunc, Func<List<string>, int> deleteAccountidfunc)
    {
        List<string> accountIdToDelete = new();

        List<string> accountIdNotDeleted = new();

        if (ExcludeEnvironments) return (accountIdToDelete, accountIdNotDeleted);

        try
        {
            accountIdToDelete = getAccountidfunc.Invoke();

            if (accountIdToDelete.IsNoDataFound()) return (new List<string>(), new List<string>());

            deleteAccountidfunc(accountIdToDelete);

        }
        catch (Exception ex)
        {
            accountIdNotDeleted.Add($"({SqlFileName}){Environment.NewLine}{ex.Message}");
        }
        finally
        {
            var accountIdNotDeletedindb = getAccountidfunc.Invoke();

            if (!accountIdNotDeletedindb.IsNoDataFound()) accountIdNotDeleted.AddRange(accountIdNotDeletedindb);
        }

        return (accountIdToDelete.Except(accountIdNotDeleted).ToList(), accountIdNotDeleted);
    }
}
