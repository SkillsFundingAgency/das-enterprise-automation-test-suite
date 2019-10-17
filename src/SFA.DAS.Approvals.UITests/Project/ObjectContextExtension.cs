using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.Approvals.UITests.Project
{
    internal static class ObjectContextExtension
    {
        #region Constants
        private const string NoOfApprentices = "noofapprentices";
        private const string ApprenticeTotalCost = "apprenticetotalcost";
        private const string Ukprn = "ukprn";
        private const string CohortReference = "cohortreference";
        private const string ApprenticeId = "apprenticeid";
        private const string ReservationId = "reservationid";

        #endregion
        internal static void SetNoOfApprentices(this ObjectContext objectContext, int value)
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

        internal static void SetApprenticeId(this ObjectContext objectContext, int value)
        {
            objectContext.Set(ApprenticeId, value);
        }

        internal static void SetReservationId(this ObjectContext objectContext, string value)
        {
            objectContext.Set(ReservationId, value);
        }

        internal static void SetUln(this ObjectContext objectContext, string value)
        {
            objectContext.Set($"Uln_{value}", value);
        }

        internal static void SetUkprn(this ObjectContext objectContext, string value)
        {
            objectContext.Replace(Ukprn, value);
        }
        
        internal static string GetUkprn(this ObjectContext objectContext)
        {
            return objectContext.Get(Ukprn);
        }

        internal static string GetApprenticeTotalCost(this ObjectContext objectContext)
        {
            return objectContext.Get(ApprenticeTotalCost);
        }

        internal static int GetNoOfApprentices(this ObjectContext objectContext)
        {
            return objectContext.Get<int>(NoOfApprentices);
        }

        internal static string GetCohortReference(this ObjectContext objectContext)
        {
            return objectContext.Get(CohortReference);
        }

        internal static string GetReservationId(this ObjectContext objectContext)
        {
            return objectContext.Get(ReservationId);
        }
    }
}
