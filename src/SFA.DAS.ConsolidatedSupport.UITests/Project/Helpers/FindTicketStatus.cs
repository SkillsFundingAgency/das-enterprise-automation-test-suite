using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project.Helpers
{
    public static class FindTicketStatus
    {
        public static bool IsNew(this string status) => status.CompareToIgnoreCase("New");
        public static bool IsOpen(this string status) => status.CompareToIgnoreCase("Open");
        public static bool IsOnHold(this string status) => status.CompareToIgnoreCase("On-Hold");
        public static bool IsPending(this string status) => status.CompareToIgnoreCase("Pending");
        public static bool IsSolved(this string status) => status.CompareToIgnoreCase("Solved");
    }
}
