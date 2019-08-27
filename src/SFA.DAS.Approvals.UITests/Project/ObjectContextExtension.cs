using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.Approvals.UITests.Project
{
    internal static class ObjectContextExtension
    {
        #region Constants
        private const string ApprenticeTotalCost = "apprenticetotalcost";
        #endregion

        internal static void SetApprenticeTotalCost(this ObjectContext objectContext, string accountid)
        {
            objectContext.Set(ApprenticeTotalCost, accountid);
        }

        internal static string GetApprenticeTotalCost(this ObjectContext objectContext)
        {
            return objectContext.Get(ApprenticeTotalCost);
        }
    }

}
