namespace SFA.DAS.TransferMatching.UITests.Project.Helpers;
public enum ApplicationStatus : byte
{
    Pending = 0,
    Approved = 1,
    Rejected = 2,
    Accepted = 3,
    FundsUsed = 4,
    Declined = 5,
    Withdrawn = 6,
    WithdrawnAfterAcceptance = 7
}
