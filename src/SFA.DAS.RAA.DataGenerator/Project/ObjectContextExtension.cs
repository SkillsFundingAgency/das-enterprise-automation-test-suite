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
        private const string RAAV2Employer = "raav2employer";
        private const string FAAUsername = "faaLoginWithNewAccountusername";
        private const string FAAPassword = "faaLoginWithNewAccountpassword";
        private const string FAAFirstname = "faaLoginWithNewAccountfirstname";
        private const string FAALastname  = "faaLoginWithNewAccountlastname";
        private const string VacancyShortDesc = "vacancyshortdesc";
        #endregion

        public static void SetApprenticeshipVacancyType(this ObjectContext objectContext) => objectContext.Set(VacancyType, true);

        public static void SetFAALogin(this ObjectContext objectContext, string username, string password, string firstname, string lastname)
        {
            objectContext.SetFAAUsername(username);
            objectContext.Set(FAAPassword, password);
            objectContext.Set(FAAFirstname, firstname);
            objectContext.Set(FAALastname, lastname);
        }

        public static void SetFAAUsername(this ObjectContext objectContext, string username) => objectContext.Replace(FAAUsername, username);

        public static (string username, string password, string firstname, string lastname) GetFAALogin(this ObjectContext objectContext)
        {
            return (objectContext.Get(FAAUsername), 
                objectContext.Get(FAAPassword),
                objectContext.Get(FAAFirstname),
                objectContext.Get(FAALastname));
        }

        public static bool IsApprenticeshipVacancyType(this ObjectContext objectContext) => objectContext.KeyExists<bool>(VacancyType);
        public static void SetRAAV2Employer(this ObjectContext objectContext) => objectContext.Set(RAAV2Employer, true);
        public static bool IsRAAV2Employer(this ObjectContext objectContext) => objectContext.KeyExists<bool>(RAAV2Employer);
        public static void SetRAAV1(this ObjectContext objectContext) => objectContext.Set(RAAV1, true);
        public static bool IsRAAV1(this ObjectContext objectContext) => objectContext.KeyExists<bool>(RAAV1);
        public static void SetFAARestart(this ObjectContext objectContext) => objectContext.Set(FAARestart, true);
        public static bool IsFAARestart(this ObjectContext objectContext) => objectContext.KeyExists<bool>(FAARestart);
        public static void SetVacancyReference(this ObjectContext objectContext, string value) => objectContext.Set(VacancyReference, value);
        public static string GetVacancyReference(this ObjectContext objectContext) => objectContext.Get(VacancyReference);     
        public static void SetVacancyTitle(this ObjectContext objectContext, string value) => objectContext.Replace(VacancyTitle, value);
        public static string GetVacancyTitle(this ObjectContext objectContext) => objectContext.KeyExists<bool>(VacancyTitle) ? objectContext.Get(VacancyTitle) : string.Empty;
        public static void SetEmployerName(this ObjectContext objectContext, string value) => objectContext.Set(EmployerName, value);
        public static string GetEmployerName(this ObjectContext objectContext) => objectContext.Get(EmployerName);
        public static void SetVacancyShortDescription(this ObjectContext objectContext, string value) => objectContext.Set(VacancyShortDesc, value);
        public static string GetVacancyShortDescription(this ObjectContext objectContext) => objectContext.Get(VacancyShortDesc);
    }
}
