namespace SFA.DAS.SupportConsole.UITests.Project;

public class SupportConsoleConfig
{
    public string Name { get; init; }
    public string EmailAddress { get; init; }
    public string PublicAccountId { get; init; }
    public string HashedAccountId { get; init; }
    public string AccountName { get; init; }
    public string PayeScheme { get; init; }
    public string CurrentLevyBalance {get;init;}
    public string AccountDetails { get; init; }
    public string Uln { get; init; }
    public string UlnName { get; init; }
    public string CohortRef { get; init; }
    public string CohortNotAssociatedToAccount { get; init; }

    public override string ToString() => $"UserName :{Name}, Account Name : '{AccountName}', EmailAddress : '{EmailAddress}', AccountDetails : '{AccountDetails}'" +
        $", HashedId : '{HashedAccountId}', PublicHashedId : '{PublicAccountId}'" +
        $", PayeScheme : '{PayeScheme}', CurrentLevyBalance : '{CurrentLevyBalance}'" +
        $", Uln : '{Uln}', UlnName : '{UlnName}', CohortRef : '{CohortRef}', CohortNotAssociatedToAccount : '{CohortNotAssociatedToAccount}'";

}