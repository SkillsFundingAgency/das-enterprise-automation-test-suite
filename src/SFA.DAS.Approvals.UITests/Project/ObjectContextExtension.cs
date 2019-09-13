using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.Approvals.UITests.Project
{
    internal static class ObjectContextExtension
    {
        #region Constants
        private const string NoOfApprentices = "noofapprentices";
        private const string ApprenticeTotalCost = "apprenticetotalcost";
        private const string CohortReference = "cohortreference";

        #endregion
        internal static void SetNoOfApprentices(this ObjectContext objectContext, string value)
        {
            objectContext.Replace(NoOfApprentices, value);
        }

        internal static void SetApprenticeTotalCost(this ObjectContext objectContext, string value)
        {
            objectContext.Replace(ApprenticeTotalCost, value);
        }

        internal static void SetCohortReference(this ObjectContext objectContext, string value)
        {
            objectContext.Set(CohortReference, value);
        }

        internal static void SetUln(this ObjectContext objectContext, string value)
        {
            objectContext.Set($"Uln_{value}", value);
        }

        internal static string GetApprenticeTotalCost(this ObjectContext objectContext)
        {
            return objectContext.Get(ApprenticeTotalCost);
        }

        internal static string GetNoOfApprentices(this ObjectContext objectContext)
        {
            return objectContext.Get(NoOfApprentices);
        }

        internal static string GetCohortReference(this ObjectContext objectContext)
        {
            return objectContext.Get(CohortReference);
        }

        
    }

}
