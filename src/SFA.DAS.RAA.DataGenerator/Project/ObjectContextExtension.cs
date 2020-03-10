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
        private const string FAALoginWithNewAccountUsername = "faaLoginWithNewAccountusername";
        private const string FAALoginWithNewAccountPassword = "faaLoginWithNewAccountpassword";
        private const string FAALoginWithNewAccountFirstname = "faaLoginWithNewAccountfirstname";
        private const string FAALoginWithNewAccountLastname  = "faaLoginWithNewAccountlastname";
        #endregion

        public static void SetApprenticeshipVacancyType(this ObjectContext objectContext)
        {
            objectContext.Set(VacancyType, true);
        }

        public static void SetFAANewAccount(this ObjectContext objectContext, string username, string password, string firstname, string lastname)
        {
            objectContext.SetFAANewUsername(username);
            objectContext.Set(FAALoginWithNewAccountPassword, password);
            objectContext.Set(FAALoginWithNewAccountFirstname, firstname);
            objectContext.Set(FAALoginWithNewAccountLastname, lastname);
        }

        public static void SetFAANewUsername(this ObjectContext objectContext, string username) => objectContext.Replace(FAALoginWithNewAccountUsername, username);

        public static (string username, string password, string firstname, string lastname) GetFAANewAccount(this ObjectContext objectContext)
        {
            return (objectContext.Get(FAALoginWithNewAccountUsername), 
                objectContext.Get(FAALoginWithNewAccountPassword),
                objectContext.Get(FAALoginWithNewAccountFirstname),
                objectContext.Get(FAALoginWithNewAccountLastname));
        }

        public static bool IsApprenticeshipVacancyType(this ObjectContext objectContext)
        {
            return objectContext.KeyExists<bool>(VacancyType);
        }
        
        public static void SetRAAV2Employer(this ObjectContext objectContext)
        {
            objectContext.Set(RAAV2Employer, true);
        }

        public static bool IsRAAV2Employer(this ObjectContext objectContext)
        {
            return objectContext.KeyExists<bool>(RAAV2Employer);
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
