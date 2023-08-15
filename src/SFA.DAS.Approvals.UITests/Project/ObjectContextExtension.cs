using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers.BulkUpload;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

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
        private const string SameApprentice = "IsSameApprentice";
        private const string UpdateDynamicPauseGlobalRule = "updatedynamicpauseglobalrule";
        private const string CohortReferenceList = "cohortreferencelist";
        private const string BulkuploadApprentices = "bulkuploadapprentices";
        private const string StartDate = "startDate";
        private const string UlnOltd = "UlnOltd";
        private const string EndDate = "endDate";

        #endregion Constants

        internal static void SetBulkuploadApprentices(this ObjectContext objectContext, List<BulkUploadApprenticeDetails> list) => objectContext.Replace(BulkuploadApprentices, list);

        internal static List<BulkUploadApprenticeDetails> GetBulkuploadApprentices(this ObjectContext objectContext) => objectContext.Get<List<BulkUploadApprenticeDetails>>(BulkuploadApprentices);

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

            list ??= new List<string>();

            if (list.Any(x => x == cohortReference)) return;

            list.Add(cohortReference);

            objectContext.Replace(CohortReferenceList, list);
        }

        internal static void UpdateCohortReference(this ObjectContext objectContext, string value) => objectContext.Update(CohortReference, value);

        internal static void ReplaceCohortReference(this ObjectContext objectContext, string value) => objectContext.Replace(CohortReference, value);

        internal static void SetApprenticeId(this ObjectContext objectContext, int value) => objectContext.Set(ApprenticeId, value);

        internal static void SetReservationId(this ObjectContext objectContext, string value) => objectContext.Replace(ReservationId, value);

        internal static bool IsProviderMakesReservationForNonLevyEmployers(this ObjectContext objectContext) =>
            objectContext.KeyExists<bool>(ProviderMakesReservationForNonLevyEmployers);

        internal static bool IsUpdateDynamicPauseGlobalRule(this ObjectContext objectContext) =>
            objectContext.KeyExists<bool>(UpdateDynamicPauseGlobalRule);

        public static string GetApprenticeTotalCost(this ObjectContext objectContext) => objectContext.Get(ApprenticeTotalCost);

        internal static int GetNoOfApprentices(this ObjectContext objectContext) => objectContext.Get<int>(NoOfApprentices);

        internal static string GetCohortReference(this ObjectContext objectContext) => objectContext.Get(CohortReference);

        internal static List<string> GetCohortReferenceList(this ObjectContext objectContext) => objectContext.Get<List<string>>(CohortReferenceList);

        internal static string GetReservationId(this ObjectContext objectContext) => objectContext.Get(ReservationId);

        internal static void SetIsSameApprentice(this ObjectContext objectContext) => objectContext.Replace(SameApprentice, true);

        internal static bool IsSameApprentice(this ObjectContext objectContext) => objectContext.KeyExists<bool>(SameApprentice);

        internal static void SetStartDate(this ObjectContext objectContext, string value) => objectContext.Replace(StartDate, value);

        internal static bool HasStartDate(this ObjectContext objectContext) => objectContext.KeyExists<bool>(StartDate);

        public static DateTime GetStartDate(this ObjectContext objectContext)
        {
            var dateTimeString = objectContext.Get<string>(StartDate);
            DateTime.TryParse(dateTimeString, out var date);
            return date;
        }

        internal static string GetUlnForOLTD(this ObjectContext objectContext) => objectContext.Get<string>(UlnOltd);

        internal static bool HasUlnForOLTD(this ObjectContext objectContext) => objectContext.KeyExists<bool>(UlnOltd);

        internal static void SetUlnForOLTD(this ObjectContext objectContext, string value) => objectContext.Replace(UlnOltd, value);

        internal static void SetEndDate(this ObjectContext objectContext, string value) => objectContext.Replace(EndDate, value);

        internal static bool HasEndDate(this ObjectContext objectContext) => objectContext.KeyExists<bool>(EndDate);

        public static DateTime GetEndDate(this ObjectContext objectContext)
        {
            var dateTimeString = objectContext.Get<string>(EndDate);
            DateTime.TryParse(dateTimeString, out var date);
            return date;
        }

        internal static void UpdateEndDate(this ObjectContext objectContext, string value) => objectContext.Update(EndDate, value);

        internal static void UpdateStartDate(this ObjectContext objectContext, string value) => objectContext.Update(StartDate, value);
    }
}