using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.Approvals.UITests.Project
{
    internal static class ObjectContextExtension
    {
        #region Constants
        private const string NoOfApprentices = "noofapprentices";
        private const string ApprenticeTotalCost = "apprenticetotalcost";
        private const string CohortReference = "cohortreference";
        private const string ApprenticeId = "apprenticeid";
        private const string ReservationId = "reservationid";
        private const string ProviderMakesReservationForNonLevyEmployers = "providermakesreservationfornonlevyemployers";
        private const string EIAgeCategoryAsOfAug2020 = "EIAgeCategoryAsOfAug2020";
        private const string EIStartMonth = "EIStartMonth";
        private const string EIStartYear = "EIStartYear";
        private const string IsEIJourney = "IsEIJourney";
        #endregion

        internal static void SetProviderMakesReservationForNonLevyEmployers(this ObjectContext objectContext) => 
            objectContext.Set(ProviderMakesReservationForNonLevyEmployers, true);

        internal static void SetNoOfApprentices(this ObjectContext objectContext, int value) => objectContext.Replace(NoOfApprentices, value);

        internal static void SetApprenticeTotalCost(this ObjectContext objectContext, string value) => objectContext.Replace(ApprenticeTotalCost, value);

        internal static void SetCohortReference(this ObjectContext objectContext, string value) => objectContext.Set(CohortReference, value);

        internal static void UpdateCohortReference(this ObjectContext objectContext, string value) => objectContext.Update(CohortReference, value);

        internal static void SetApprenticeId(this ObjectContext objectContext, int value) => objectContext.Set(ApprenticeId, value);

        internal static void SetReservationId(this ObjectContext objectContext, string value) => objectContext.Replace(ReservationId, value);

        internal static void SetUln(this ObjectContext objectContext, string value) => objectContext.Set($"Uln_{value}", value);

        internal static void SetIsEIJourney(this ObjectContext objectContext, bool value) => objectContext.Replace(IsEIJourney, value);

        internal static void SetEIAgeCategoryAsOfAug2020(this ObjectContext objectContext, string value) => objectContext.Replace(EIAgeCategoryAsOfAug2020, value);

        internal static void SetEIStartMonth(this ObjectContext objectContext, int value) => objectContext.Replace(EIStartMonth, value);

        internal static void SetEIStartYear(this ObjectContext objectContext, int value) => objectContext.Replace(EIStartYear, value);

        internal static bool IsProviderMakesReservationForNonLevyEmployers(this ObjectContext objectContext) => 
            objectContext.KeyExists<bool>(ProviderMakesReservationForNonLevyEmployers);
        
        internal static string GetApprenticeTotalCost(this ObjectContext objectContext) => objectContext.Get(ApprenticeTotalCost);

        internal static int GetNoOfApprentices(this ObjectContext objectContext) => objectContext.Get<int>(NoOfApprentices);

        internal static string GetCohortReference(this ObjectContext objectContext) => objectContext.Get(CohortReference);

        internal static string GetReservationId(this ObjectContext objectContext) => objectContext.Get(ReservationId);

        internal static string GetEIAgeCategoryAsOfAug2020(this ObjectContext objectContext) => objectContext.Get(EIAgeCategoryAsOfAug2020);

        internal static int GetEIStartMonth(this ObjectContext objectContext) => objectContext.Get<int>(EIStartMonth);

        internal static int GetEIStartYear(this ObjectContext objectContext) => objectContext.Get<int>(EIStartYear);

        internal static bool GetIsEIJourney(this ObjectContext objectContext) => objectContext.Get<bool>(IsEIJourney);
    }
}
