using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.ConsolidatedSupport.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string TicketId = "ticketid";
        #endregion

        public static void SetTicketId(this ObjectContext objectContext, string value) => objectContext.Replace(TicketId, value);
        public static string GetTicketId(this ObjectContext objectContext) => objectContext.Get(TicketId);
    }
}
