namespace SFA.DAS.SupportConsole.UITests.Project;


public class CohortDetails
{
    public CohortDetails((string uln, string fname, string lname, string cohortRef) data)
    {
        Uln = data.uln;
        UlnName = $"{data.fname} {data.lname}";
        CohortRef = data.cohortRef;
    }

    public string Uln { get; set; }
    public string UlnName { get; init; }
    public string CohortRef { get; set; }

    public override string ToString() => $"Uln : '{Uln}', UlnName : '{UlnName}', CohortRef : '{CohortRef}'";

}

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

    public CohortDetails CohortDetails { get; init; }

    public CohortDetails CohortNotAssociatedToAccount { get; init; }

    public CohortDetails CohortWithPendingChanges { get; init; }

    public CohortDetails CohortWithTrainingProviderHistory { get; init; }

    public string Uln => CohortDetails.Uln;
    public string UlnName => CohortDetails.UlnName;
    public string CohortRef => CohortDetails.CohortRef;

    public override string ToString() => $"UserName :{Name}, Account Name : '{AccountName}', EmailAddress : '{EmailAddress}', AccountDetails : '{AccountDetails}'" +
        $", HashedId : '{HashedAccountId}', PublicHashedId : '{PublicAccountId}'" +
        $", PayeScheme : '{PayeScheme}', CurrentLevyBalance : '{CurrentLevyBalance}'" +
        $", CohortDetails : '{CohortDetails}', CohortNotAssociatedToAccount : '{CohortNotAssociatedToAccount}'" +
        $", CohortWithPendingChanges : '{CohortWithPendingChanges}', CohortWithTrainingProviderHistory : '{CohortWithTrainingProviderHistory}'";

}