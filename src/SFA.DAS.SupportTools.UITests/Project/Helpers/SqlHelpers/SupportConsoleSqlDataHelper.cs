namespace SFA.DAS.SupportTools.UITests.Project.Helpers.SqlHelpers;

public class SupportConsoleSqlDataHelper(AccountsSqlDataHelper accountsSqlDataHelper, CommitmentsSqlDataHelper commitmentsSqlDataHelper)
{
    public SupportConsoleConfig GetUpdatedConfig(SupportConsoleConfig supportConsoleConfig)
    {
        var publicAccountId = supportConsoleConfig.PublicAccountId;

        var (name, createdDate, hashedId, email, fName, lName, payeref) = accountsSqlDataHelper.GetAccountDetails(publicAccountId);

        var commitmentsData = commitmentsSqlDataHelper.GetCommtDetails(publicAccountId);

        return new SupportConsoleConfig
        {
            Name = $"{fName} {lName}",
            EmailAddress = email,
            PublicAccountId = publicAccountId,
            HashedAccountId = hashedId,
            AccountName = name,
            PayeScheme = payeref,
            CurrentLevyBalance = supportConsoleConfig.CurrentLevyBalance,
            AccountDetails = $"Account ID {publicAccountId}, created {createdDate:dd/MM/yyyy}",
            CohortDetails = new CohortDetails(commitmentsData[0]),
            CohortNotAssociatedToAccount = new CohortDetails(commitmentsData[1]),
            CohortWithPendingChanges = new CohortDetails(commitmentsData[2]),
            CohortWithTrainingProviderHistory = new CohortDetails(commitmentsData[3]),
        };
    }
}
