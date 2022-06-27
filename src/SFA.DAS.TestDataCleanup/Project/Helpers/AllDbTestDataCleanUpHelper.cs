namespace SFA.DAS.TestDataCleanup.Project.Helpers;

public class AllDbTestDataCleanUpHelper 
{
    private readonly DbConfig _dbConfig;

    private string _sqlFileName, _dbName;

    private readonly List<string> usersdeleted = new();

    private readonly List<string> userswithconstraints = new();

    private List<string[]> _apprenticeIds;

    public AllDbTestDataCleanUpHelper(DbConfig dbConfig) => _dbConfig = dbConfig;

    public (List<string>, List<string>) CleanUpAllDbTestData(string email) => CleanUpAllDbTestData(new List<string> { email });

    public (List<string>, List<string>) CleanUpAllDbTestData(List<string> email)
    {
        (var easAccDbSqlDataHelper, var userEmailListArray) = GetUserEmailList(email);

        if (userEmailListArray.IsNoDataFound()) return (usersdeleted, userswithconstraints);

        var userEmailList = userEmailListArray.ListOfArrayToList(0);

        AddInUseEmails(userEmailList);

        CleanUpTestData(easAccDbSqlDataHelper, userEmailList);

        return (usersdeleted, userswithconstraints);
    }

    private (TestDataCleanUpEasAccDbSqlDataHelper, List<string[]>) GetUserEmailList(List<string> email)
    {
        var easAccDbSqlDataHelper = new TestDataCleanUpEasAccDbSqlDataHelper(_dbConfig);

        SetDetails(easAccDbSqlDataHelper);

        return (easAccDbSqlDataHelper, easAccDbSqlDataHelper.GetUserEmailList(email));
    }

    private static void AddInUseEmails(List<string> userEmailList) => TestDataCleanUpEmailsInUse.AddInUseEmails(userEmailList);

    private void CleanUpTestData(TestDataCleanUpEasAccDbSqlDataHelper easAccDbSqlDataHelper, List<string> userEmailList)
    {
        try
        {
            var accountIdsListArray = easAccDbSqlDataHelper.GetAccountIds(userEmailList);

            var noOfRowsDeleted = CleanUpUsersDbTestData(userEmailList) + CleanUpPregDbTestData(userEmailList);

            var accountidsTodelete = accountIdsListArray.ListOfArrayToList(0);

            if (!string.IsNullOrEmpty(accountidsTodelete[0])) noOfRowsDeleted += CleanUpTestDataUsingAccountId(accountidsTodelete);

            noOfRowsDeleted += CleanUpEasDbTestData(easAccDbSqlDataHelper, userEmailList);

            int x = userEmailList.Count;

            if (x < 15) usersdeleted.Add($"{userEmailList.ToString(",")}");
            if (accountidsTodelete.Count < 15) usersdeleted.Add($"{accountidsTodelete.ToString(",")}");
            usersdeleted.Add($"{noOfRowsDeleted} total rows deleted across the dbs");
            usersdeleted.Add($"{userEmailList.Count} email account{(x == 1 ? string.Empty : "s")} deleted");
        }
        catch (Exception ex)
        {
            userswithconstraints.Add($"{userEmailList.ToString(",")},{_dbName}({_sqlFileName}){Environment.NewLine}{ex.Message}");
        }
    }

    private int CleanUpTestDataUsingAccountId(List<string> accountidsTodelete) 
    {
        return CleanUpRsvrTestData(accountidsTodelete) 
            + CleanUpPrelTestData(accountidsTodelete) 
            + CleanUpPsrTestData(accountidsTodelete) 
            + CleanUpPfbeTestData(accountidsTodelete) 
            + CleanUpEmpFcastTestData(accountidsTodelete)
            + CleanUpAppfbTestData(accountidsTodelete)
            + CleanUpEmpFinTestData(accountidsTodelete) 
            + CleanUpEmpIncTestData(accountidsTodelete) 
            + CleanUpAComtTestData() 
            + CleanUpEasLtmTestData(accountidsTodelete) 
            + CleanUpComtTestData(accountidsTodelete);
    }

    private int CleanUpEasDbTestData(TestDataCleanUpEasAccDbSqlDataHelper helper, List<string> emailsToDelete)
    {
        SetDetails(helper);

        return SetDebugMessage(() => helper.CleanUpEasDbTestData(emailsToDelete));
    }

    private int CleanUpComtTestData(List<string> accountidsTodelete)
    {
        var helper = new TestDataCleanupComtSqlDataHelper(_dbConfig);

        SetDetails(helper);

        return SetDebugMessage(() => helper.CleanUpComtTestData(accountidsTodelete));
    }

    private int CleanUpEasLtmTestData(List<string> accountidsTodelete)
    {
        var helper = new TestDataCleanUpEasLtmcSqlDataHelper(_dbConfig);

        SetDetails(helper);

        return SetDebugMessage(() => helper.CleanUpEasLtmTestData(accountidsTodelete));
    }

    private int CleanUpAppfbTestData(List<string> accountidsTodelete)
    {
        var helper = new TestDataCleanupAppfbqlDataHelper(_dbConfig);

        SetDetails(helper);

        _apprenticeIds = new GetSupportDataHelper(_dbConfig).GetApprenticeIds(accountidsTodelete);

        return SetDebugMessage(() => helper.CleanUpAppfbTestData(_apprenticeIds));
    }

    private int CleanUpAComtTestData()
    {
        var helper = new TestDataCleanupAComtSqlDataHelper(_dbConfig);

        SetDetails(helper);

        return SetDebugMessage(() => helper.CleanUpAComtTestData(_apprenticeIds));
    }

    private int CleanUpEmpIncTestData(List<string> accountidsTodelete)
    {
        var helper = new TestDataCleanUpEmpIncSqlDataHelper(_dbConfig);

        SetDetails(helper);

        return SetDebugMessage(() => helper.CleanUpEmpIncTestData(accountidsTodelete));
    }

    private int CleanUpEmpFinTestData(List<string> accountidsTodelete)
    {
        var helper = new TestDataCleanUpEmpFinSqlDataHelper(_dbConfig);

        SetDetails(helper);

        return SetDebugMessage(() => helper.CleanUpEmpFinTestData(accountidsTodelete));
    }

    private int CleanUpEmpFcastTestData(List<string> accountidsTodelete)
    {
        var helper = new TestDataCleanUpEmpFcastSqlDataHelper(_dbConfig);

        SetDetails(helper);

        return SetDebugMessage(() => helper.CleanUpEmpFcastTestData(accountidsTodelete));
    }

    private int CleanUpPfbeTestData(List<string> accountidsTodelete)
    {
        var helper = new TestDataCleanUpPfbeDbSqlDataHelper(_dbConfig);

        SetDetails(helper);

        return SetDebugMessage(() => helper.CleanUpPfbeTestData(accountidsTodelete));
    }

    private int CleanUpPsrTestData(List<string> accountidsTodelete)
    {
        var helper = new TestDataCleanUpPsrDbSqlDataHelper(_dbConfig);

        SetDetails(helper);

        return SetDebugMessage(() => helper.CleanUpPsrTestData(accountidsTodelete));
    }

    private int CleanUpPrelTestData(List<string> accountidsTodelete)
    {
        var helper = new TestDataCleanUpPrelDbSqlDataHelper(_dbConfig);

        SetDetails(helper);

        return SetDebugMessage(() => helper.CleanUpPrelTestData(accountidsTodelete));
    }

    private int CleanUpRsvrTestData(List<string> accountidsTodelete)
    {
        var helper = new TestDataCleanUpRsvrSqlDataHelper(_dbConfig);
        
        SetDetails(helper);

        return SetDebugMessage(() => helper.CleanUpRsvrTestData(accountidsTodelete));
    }

    private int CleanUpPregDbTestData(List<string> emailsToDelete)
    {
        var helper = new TestDataCleanUpPregDbSqlDataHelper(_dbConfig);
        
        SetDetails(helper);
        
        return SetDebugMessage(() => helper.CleanUpPregDbTestData(emailsToDelete));
    }

    private int CleanUpUsersDbTestData(List<string> emailsToDelete)
    {
        var helper = new TestDataCleanUpUsersDbSqlDataHelper(_dbConfig);
        
        SetDetails(helper);
        
        return SetDebugMessage(() => helper.CleanUpUsersDbTestData(emailsToDelete));
    }

    private void SetDetails(TestDataCleanUpSqlDataHelper helper)
    {
        _dbName = helper.dbName;

        _sqlFileName = helper.SqlFileName;
    }

    private int SetDebugMessage(Func<int> func) 
    {
        int noOfrowsDeleted;

        string message;

        try
        {
            noOfrowsDeleted = func();

            message = $"{noOfrowsDeleted} rows deleted from {_dbName}";
        }
        catch (Exception ex)
        {
            noOfrowsDeleted = 0;

            message = $"FAILED to delete from {_dbName}({_sqlFileName})";

            userswithconstraints.Add($"{_dbName}({_sqlFileName}){Environment.NewLine}{ex.Message}");
        }

        usersdeleted.Add(message);

        return noOfrowsDeleted;
    }
}
