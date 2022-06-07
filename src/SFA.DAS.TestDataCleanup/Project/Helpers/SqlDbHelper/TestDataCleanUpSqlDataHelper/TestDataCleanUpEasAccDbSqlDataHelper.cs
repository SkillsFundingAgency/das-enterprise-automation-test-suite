namespace SFA.DAS.TestDataCleanup.Project.Helpers.SqlDbHelper.TestDataCleanUpSqlDataHelper;

public class TestDataCleanUpEasAccDbSqlDataHelper : BaseSqlDbHelper.TestDataCleanUpSqlDataHelper
{
    public override string SqlFileName => "EasAccTestDataCleanUp";

    public TestDataCleanUpEasAccDbSqlDataHelper(DbConfig dbConfig) : base(dbConfig.AccountsDbConnectionString) { }

    internal List<string[]> GetAccountIds(List<string> userEmail) => GetMultipleData($"select AccountId from employer_account.Membership where UserId in (select id from employer_account.[User] where Email = {GetAccountIdsQuery(userEmail)})");

    internal List<string[]> GetUserEmailList(List<string> userEmail)
    {
        var userEmailList = GetMultipleData($"select top 100 Email from employer_account.[User] where " +
            $"Email like {GetUserEmailListQuery(userEmail)} " +
            $"and Email like '___Test__________________________@%' " +
            $"and Email not like '%perftest.com' " +
            $"and Email not like '%PerfTest%' " +
            $"and Email not like '%Nov2020%' " +
            $"and Email not like '%Dec2020%' " +
            $"and Email not like '%Jan2021%' " +
            $"and Email not like '%Feb2021%' " +
            $"and Email not like '%Mar2021%' " +
            $"and Email not like '%Apr2021%' " +
            $"and Email not like '%May2021%' " +
            $"and Email not like '%Jun2021%' " +
            $"and Email not like '%Jul2021%' " +
            $"and Email not like '%Aug2021%' " +
            $"and Email not like '%Sep2021%' " +
            $"and Email not like '%Oct2021%' " +
            $"and Email not like '%Nov2021%' " +
            $"and Email not like '%Dec2021%' " +
            $"and Email not like '%Jan2022%' " +
            $"and Email not like '%Feb2022%' " +
            $"and Email not like '%Mar2022%' " +
            $"and Email not like '%Apr2022%' " +
            $"and Email not in ({TestDataCleanUpEmailsInUse.GetInUseEmails()}) order by NEWID() desc");

        return userEmailList;
    }
   
    internal List<string[]> GetAccountIds(int greaterThan, int lessThan) => GetMultipleAccountData($"select Id from employer_account.Account where id > {greaterThan} and id < {lessThan} order by id desc");

    internal List<string[]> GetAccountHashedIds(List<string> accountIdToDelete) => GetMultipleData($"select HashedId from employer_account.Account where id in ({string.Join(",", accountIdToDelete)})");

    internal int CleanUpEasDbTestData(List<string> emailsToDelete) => CleanUpUsingEmail(emailsToDelete);

    private static string Join(string separator, List<string> list) => string.Join(separator, list.Select(x => $"('{x}')"));

    private static string GetAccountIdsQuery(List<string> userEmail) => Join(" or Email = ", userEmail);

    private static string GetUserEmailListQuery(List<string> userEmail) => Join(" or Email like ", userEmail);
}
