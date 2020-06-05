using SFA.DAS.ConfigurationBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.Campaigns.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string VacancyTitleKey = "vacancytitlekey";
        private const string CourseIdKey = "courseid";
        private const string ProviderIdKey = "providerid";
        private const string ProviderIdLocationKey = "providerlocationid";
        #endregion

        internal static void SetVacancyTitle(this ObjectContext objectContext, string value) => objectContext.Replace(VacancyTitleKey, value);
        internal static void SetCourseId(this ObjectContext objectContext, string value) => objectContext.Replace(CourseIdKey, value);
        internal static void SetProviderId(this ObjectContext objectContext, string value) => objectContext.Replace(ProviderIdKey, value);
        internal static void SetProviderLocationId(this ObjectContext objectContext, string value) => objectContext.Replace(ProviderIdLocationKey, value);

        internal static string GetVacancyTitle(this ObjectContext objectContext) => objectContext.Get(VacancyTitleKey);
        internal static string GetCourseId(this ObjectContext objectContext) => objectContext.Get(CourseIdKey);
        internal static string GetProviderId(this ObjectContext objectContext) => objectContext.Get(ProviderIdKey);
        internal static string GetProviderLocationId(this ObjectContext objectContext) => objectContext.Get(ProviderIdLocationKey);
    }
}
