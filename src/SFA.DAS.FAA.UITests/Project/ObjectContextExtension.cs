using SFA.DAS.UI.Framework.TestSupport;

namespace SFA.DAS.FAA.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string VacancyReference = "vacancyreference";
        private const string VacancyTitle = "vacancytitle";
        private const string VacancyType = "vacancytype";
        #endregion

        public static void SetApprenticeshipVacancyType(this ObjectContext objectContext)
        {
            objectContext.Set(VacancyType, true);
        }

        public static bool IsApprenticeshipVacancyType(this ObjectContext objectContext)
        {
            return objectContext.KeyExists<bool>(VacancyType);
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
            objectContext.Set(VacancyTitle, value);
        }

        public static string GetVacancyTitle(this ObjectContext objectContext)
        {
            return objectContext.KeyExists<bool>(VacancyTitle) ? objectContext.Get(VacancyTitle) : string.Empty;
        }
    }
}
