using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.RAA.DataGenerator.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string EmployerName = "employername";
        private const string VacancyReference = "vacancyreference";
        private const string VacancyTitle = "vacancytitle";
        private const string VacancyType = "vacancytype";
        private const string FAARestart = "faarestart";
        private const string RAAV1 = "raav1";
        #endregion

        public static void SetApprenticeshipVacancyType(this ObjectContext objectContext)
        {
            objectContext.Set(VacancyType, true);
        }

        public static bool IsApprenticeshipVacancyType(this ObjectContext objectContext)
        {
            return objectContext.KeyExists<bool>(VacancyType);
        }

        public static void SetRAAV1(this ObjectContext objectContext)
        {
            objectContext.Set(RAAV1, true);
        }

        public static bool IsRAAV1(this ObjectContext objectContext)
        {
            return objectContext.KeyExists<bool>(RAAV1);
        }

        public static void SetFAARestart(this ObjectContext objectContext)
        {
            objectContext.Set(FAARestart, true);
        }

        public static bool IsFAARestart(this ObjectContext objectContext)
        {
            return objectContext.KeyExists<bool>(FAARestart);
        }

        public static void SetVacancyReference(this ObjectContext objectContext, string value)
        {
            objectContext.Set(VacancyReference, value);
        }

        public static string GetVacancyReference(this ObjectContext objectContext)
        {
            return objectContext.Get(VacancyReference);
        }

        public static void SetVacancyTitle(this ObjectContext objectContext, string value)
        {
            objectContext.Replace(VacancyTitle, value);
        }

        public static string GetVacancyTitle(this ObjectContext objectContext)
        {
            return objectContext.KeyExists<bool>(VacancyTitle) ? objectContext.Get(VacancyTitle) : string.Empty;
        }

        public static void SetEmployerName(this ObjectContext objectContext, string value)
        {
            objectContext.Set(EmployerName, value);
        }

        public static string GetEmployerName(this ObjectContext objectContext)
        {
            return objectContext.Get(EmployerName);
        }
    }
}
