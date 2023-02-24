using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string TicketId = "ticketid";
        private const string UserId = "userid";
        private const string UserCreatedEvent = "usercreatedevent";
        private const string OrgCreatedEvent = "orgcreatedevent";
        #endregion

        public static void SetTicketId(this ObjectContext objectContext, string value) => objectContext.Replace(TicketId, value);
        public static string GetTicketId(this ObjectContext objectContext) => objectContext.Get(TicketId);

        public static void SetUserId(this ObjectContext objectContext, string value) => objectContext.Replace(UserId, value);
        public static string GetUserId(this ObjectContext objectContext) => objectContext.Get(UserId);

        public static void SetUserCreated(this ObjectContext objectContext) => objectContext.Replace(UserCreatedEvent, true);

        public static bool IsUserCreated(this ObjectContext objectContext) => objectContext.KeyExists<bool>(UserCreatedEvent);

        public static void SetOrgCreated(this ObjectContext objectContext) => objectContext.Replace(OrgCreatedEvent, true);

        public static bool IsOrgCreated(this ObjectContext objectContext) => objectContext.KeyExists<bool>(OrgCreatedEvent);
    }
}
