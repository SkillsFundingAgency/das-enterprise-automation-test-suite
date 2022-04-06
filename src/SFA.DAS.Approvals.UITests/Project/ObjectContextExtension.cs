using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.ConfigurationBuilder;
using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project
{
    public class EIApprenticeDetail
    {
        public int StartMonth;
        public int StartYear;
        public string AgeCategoryAsOfAug2021;
    }

    public static class ObjectContextExtension
    {
        #region Constants
        private const string NoOfApprentices = "noofapprentices";
        private const string ApprenticeTotalCost = "apprenticetotalcost";
        private const string CohortReference = "cohortreference";
        private const string ApprenticeId = "apprenticeid";
        private const string ReservationId = "reservationid";
        private const string ProviderMakesReservationForNonLevyEmployers = "providermakesreservationfornonlevyemployers";
        private const string EIAgeCategoryAsOfAug2021 = "EIAgeCategoryAsOfAug2021";
        private const string EIStartMonth = "EIStartMonth";
        private const string EIStartYear = "EIStartYear";
        private const string EIJourney = "IsEIJourney";
        private const string SameApprentice = "IsSameApprentice";
        private const string EIApprenticeDetailList = "eiapprenticedetaillist";
        private const string UpdateDynamicPauseGlobalRule = "updatedynamicpauseglobalrule";
        private const string CohortReferenceList = "cohortreferencelist";
        private const string BulkuploadApprentices = "bulkuploadapprentices";
        #endregion

        internal static void SetBulkuploadApprentices(this ObjectContext objectContext, List<ApprenticeDetails> list) => objectContext.Replace(BulkuploadApprentices, list);

        internal static void SetUpdateDynamicPauseGlobalRule(this ObjectContext objectContext) =>
            objectContext.Set(UpdateDynamicPauseGlobalRule, true);
        

        internal static void SetProviderMakesReservationForNonLevyEmployers(this ObjectContext objectContext) => 
            objectContext.Set(ProviderMakesReservationForNonLevyEmployers, true);

        public static void SetNoOfApprentices(this ObjectContext objectContext, int value) => objectContext.Replace(NoOfApprentices, value);

        public static void SetApprenticeTotalCost(this ObjectContext objectContext, string value) => objectContext.Replace(ApprenticeTotalCost, value);

        public static void SetCohortReference(this ObjectContext objectContext, string value) => objectContext.Set(CohortReference, value);

        public static void SetCohortReferenceList(this ObjectContext objectContext, string cohortReference)
        {
            var list = objectContext.GetCohortReferenceList();

            if (list == null) list = new List<string>();

            list.Add(cohortReference);

            objectContext.Replace(CohortReferenceList, list);
        }

        internal static void UpdateCohortReference(this ObjectContext objectContext, string value) => objectContext.Update(CohortReference, value);

        internal static void SetApprenticeId(this ObjectContext objectContext, int value) => objectContext.Set(ApprenticeId, value);

        internal static void SetReservationId(this ObjectContext objectContext, string value) => objectContext.Replace(ReservationId, value);

        internal static void SetUln(this ObjectContext objectContext, string value) => objectContext.Set($"Uln_{value}", value);

        internal static void SetEIApprenticeDetailList(this ObjectContext objectContext) => objectContext.Set(EIApprenticeDetailList, new List<EIApprenticeDetail>());

        internal static void SetEIApprenticeDetail(this ObjectContext objectContext, string eIAgeCategory, string startMonth, string startYear)
        {
            var eIApprenticeDetailList = objectContext.GetEIApprenticeDetailList();

            eIApprenticeDetailList.Add(new EIApprenticeDetail {StartMonth = int.Parse(startMonth), StartYear = int.Parse(startYear), AgeCategoryAsOfAug2021 = eIAgeCategory });
        }

        internal static void SetIsEIJourney(this ObjectContext objectContext) => objectContext.Set(EIJourney, true);

        internal static void SetEIAgeCategoryAsOfAug2021(this ObjectContext objectContext, string value) => objectContext.Replace(EIAgeCategoryAsOfAug2021, value);

        internal static void SetEIStartMonth(this ObjectContext objectContext, int value) => objectContext.Replace(EIStartMonth, value);

        internal static void SetEIStartYear(this ObjectContext objectContext, int value) => objectContext.Replace(EIStartYear, value);

        internal static bool IsProviderMakesReservationForNonLevyEmployers(this ObjectContext objectContext) => 
            objectContext.KeyExists<bool>(ProviderMakesReservationForNonLevyEmployers);

        internal static bool IsUpdateDynamicPauseGlobalRule(this ObjectContext objectContext) =>
            objectContext.KeyExists<bool>(UpdateDynamicPauseGlobalRule);

        public static List<EIApprenticeDetail> GetEIApprenticeDetailList(this ObjectContext objectContext) => objectContext.Get<List<EIApprenticeDetail>>(EIApprenticeDetailList);

        public static string GetApprenticeTotalCost(this ObjectContext objectContext) => objectContext.Get(ApprenticeTotalCost);

        internal static int GetNoOfApprentices(this ObjectContext objectContext) => objectContext.Get<int>(NoOfApprentices);

        internal static string GetCohortReference(this ObjectContext objectContext) => objectContext.Get(CohortReference);
        
        internal static List<string> GetCohortReferenceList(this ObjectContext objectContext) => objectContext.Get<List<string>>(CohortReferenceList);

        internal static string GetReservationId(this ObjectContext objectContext) => objectContext.Get(ReservationId);

        public static string GetEIAgeCategoryAsOfAug2021(this ObjectContext objectContext) => objectContext.Get(EIAgeCategoryAsOfAug2021);

        public static int GetEIStartMonth(this ObjectContext objectContext) => objectContext.Get<int>(EIStartMonth);

        public static int GetEIStartYear(this ObjectContext objectContext) => objectContext.Get<int>(EIStartYear);

        internal static bool IsEIJourney(this ObjectContext objectContext) => objectContext.KeyExists<bool>(EIJourney);

        internal static void SetIsSameApprentice(this ObjectContext objectContext) => objectContext.Replace(SameApprentice, true);

        internal static void ResetIsSameApprentice(this ObjectContext objectContext) => objectContext.Remove<bool>(SameApprentice);

        internal static bool IsSameApprentice(this ObjectContext objectContext) => objectContext.KeyExists<bool>(SameApprentice);
    }
}
