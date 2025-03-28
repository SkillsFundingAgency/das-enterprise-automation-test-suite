namespace SFA.DAS.Registration.UITests.Project.Helpers;

public class TaskQueryResult
{
    public bool ShowLevyDeclarationTask { get; set; }
    public int NumberOfApprenticesToReview { get; set; }
    public int NumberOfCohortsReadyToReview { get; set; }
    public int NumberOfPendingTransferConnections { get; set; }
    public int NumberOfTransferRequestToReview { get; set; }
    public int NumberTransferPledgeApplicationsToReview { get; set; }
    public int NumberOfAcceptedTransferPledgeApplicationsWithNoApprentices { get; set; }
}
