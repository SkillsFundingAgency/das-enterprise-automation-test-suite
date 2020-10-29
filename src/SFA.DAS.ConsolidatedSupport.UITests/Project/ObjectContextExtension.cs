using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string TicketId = "ticketid";
        private const string UserId = "userid";
        #endregion

        public static void SetTicketId(this ObjectContext objectContext, string value) => objectContext.Replace(TicketId, value);
        public static string GetTicketId(this ObjectContext objectContext) => objectContext.Get(TicketId);

        public static void SetUserId(this ObjectContext objectContext, string value) => objectContext.Replace(UserId, value);
        public static string GetUserId(this ObjectContext objectContext) => objectContext.Get(UserId);
    }
}
