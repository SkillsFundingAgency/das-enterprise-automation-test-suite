using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.Approvals.UITests.Project
{
    internal static class ObjectContextExtension
    {
        #region Constants
        private const string ApprenticeTotalCost = "apprenticetotalcost";
        private const string CohortReference = "cohortreference";
        
        #endregion

        internal static void SetApprenticeTotalCost(this ObjectContext objectContext, string accountid)
        {
            objectContext.Set(ApprenticeTotalCost, accountid);
        }

        internal static void SetCohortReference(this ObjectContext objectContext, string accountid)
        {
            objectContext.Set(CohortReference, accountid);
        }

        internal static string GetApprenticeTotalCost(this ObjectContext objectContext)
        {
            return objectContext.Get(ApprenticeTotalCost);
        }

        internal static string GetCohortReference(this ObjectContext objectContext)
        {
            return objectContext.Get(CohortReference);
        }
    }

}
