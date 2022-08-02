namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Helpers
{
    internal static class StatusHelper
    {
        internal static string OverviewSectionComplete => "COMPLETE";

        internal static string OverviewSectionInComplete => "INCOMPLETE";

        internal static string OverviewSectionWaitingForCorrection => "WAITING FOR CORRECTION";

        internal static string DashboardInCompleteStatus => "INCOMPLETE";

        internal static string DashboardUnConfimredStatusForCoC => "UNCONFIRMED";

        internal static string DashboardStoppedStatus => "STOPPED";

        internal static string DashboardCmadSectionTextWhenInCompleteOrUnConfirmed = "Confirm details of your employer, training provider and apprenticeship.";

        internal static string DashboardCmadSectionTextWhenFullyConfirmed = "Details of your employer, training provider and apprenticeship.";

        internal static string DashboardCmadSectionTextWhenUnConfirmed = "Changes have been made to your apprenticeship details. Confirm your new details.";

        internal static string DashboardHelpAndSupportDashboardText = "Who to contact if you have questions or concerns during your apprenticeship.";

        internal static string FullyConfirmedOverviewRolesSubText = "You can read through the roles and responsibilities for you, your employer and your training provider.";

        internal static string FullyConfirmedOverviewHYAWDSubText = "View details of how your apprenticeship will be delivered.";
    }
}
