namespace SFA.DAS.SupportConsole.UITests.Project.Helpers.SqlHelpers;

public class SupportConsoleSqlDataHelper
{
    private readonly AccountsSqlDataHelper _accountsSqlDataHelper;
    private readonly CommitmentsSqlDataHelper _commitmentsSqlDataHelper;

    public SupportConsoleSqlDataHelper(AccountsSqlDataHelper accountsSqlDataHelper, CommitmentsSqlDataHelper commitmentsSqlDataHelper)
    {
        _accountsSqlDataHelper = accountsSqlDataHelper;
        _commitmentsSqlDataHelper = commitmentsSqlDataHelper;
    }

    public SupportConsoleConfig GetUpdatedConfig(SupportConsoleConfig supportConsoleConfig)
    {
        string publicAccountId = supportConsoleConfig.PublicAccountId;

        var (name, createdDate, hashedId, email, fName, lName, payeref) = _accountsSqlDataHelper.GetAccountDetails(publicAccountId);

        var comtData = _commitmentsSqlDataHelper.GetCommtDetails(publicAccountId);

        var (uln, fname, lname, cohortRef, publichashedId) = comtData.Single(x => x.publichashedId == publicAccountId);

        var cohortNotAssociated = comtData.Single(x => x.publichashedId != publicAccountId);

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
            Uln = uln,
            UlnName = $"{fname} {lname}",
            CohortRef = cohortRef,
            CohortNotAssociatedToAccount = cohortNotAssociated.cohortRef
        };

        return result;
    }

}
