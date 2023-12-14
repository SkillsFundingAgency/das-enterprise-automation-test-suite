namespace SFA.DAS.SupportConsole.UITests.Project.Helpers.SqlHelpers;

public class SupportConsoleSqlDataHelper(AccountsSqlDataHelper accountsSqlDataHelper, CommitmentsSqlDataHelper commitmentsSqlDataHelper)
{
    public SupportConsoleConfig GetUpdatedConfig(SupportConsoleConfig supportConsoleConfig)
    {
        string publicAccountId = supportConsoleConfig.PublicAccountId;

        var (name, createdDate, hashedId, email, fName, lName, payeref) = accountsSqlDataHelper.GetAccountDetails(publicAccountId);

        var comtData = commitmentsSqlDataHelper.GetCommtDetails(publicAccountId);

        var result = new SupportConsoleConfig
        {
            Name = $"{fName} {lName}",
            EmailAddress = email,
            PublicAccountId = publicAccountId,
            HashedAccountId = hashedId,
            AccountName = name,
            PayeScheme = payeref,
            CurrentLevyBalance = supportConsoleConfig.CurrentLevyBalance,
            AccountDetails = $"Account ID {publicAccountId}, created {createdDate:dd/MM/yyyy}",
            CohortDetails = new CohortDetails(comtData[0]),
            CohortNotAssociatedToAccount = new CohortDetails(comtData[1]),
            CohortWithPendingChanges = new CohortDetails(comtData[2]),  
            CohortWithTrainingProviderHistory = new CohortDetails(comtData[3]),
        };

        return result;
    }

}
