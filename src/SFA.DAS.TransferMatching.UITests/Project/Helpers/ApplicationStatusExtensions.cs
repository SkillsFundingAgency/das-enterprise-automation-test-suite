namespace SFA.DAS.TransferMatching.UITests.Project.Helpers
{
    public static class ApplicationStatusExtensions
    {
        public static string GetLabelForReceiver(this ApplicationStatus status)
        {
            return status switch
            {
                ApplicationStatus.Pending => "Awaiting approval",
                ApplicationStatus.Approved => "Approved, awaiting your acceptance",
                ApplicationStatus.Rejected => "Rejected",
                ApplicationStatus.Accepted => "Funds available to add apprentice",
                ApplicationStatus.FundsUsed => "Funds used",
                ApplicationStatus.Declined => "Withdrawn",
                ApplicationStatus.Withdrawn => "Withdrawn",
                ApplicationStatus.WithdrawnAfterAcceptance => "Withdrawn",
                _ => string.Empty,
            };
        }

        public static string GetLabelForSender(this ApplicationStatus status)
        {           
            return status switch
            {
                ApplicationStatus.Pending => "Awaiting your approval",
                ApplicationStatus.Accepted => "Offer of funding accepted",
                ApplicationStatus.FundsUsed => "Funds used",
                ApplicationStatus.Rejected => "Rejected",
                ApplicationStatus.Declined => "Declined by applicant",
                ApplicationStatus.Withdrawn => "Withdrawn by applicant",
                ApplicationStatus.WithdrawnAfterAcceptance => "Withdrawn by applicant",
                ApplicationStatus.FundsExpired => "Funds no longer available",
                _ => string.Empty,
            };
        }
    }
}
