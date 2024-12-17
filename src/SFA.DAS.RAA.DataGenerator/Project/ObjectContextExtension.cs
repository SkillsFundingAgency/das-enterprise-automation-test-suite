using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.RAA.DataGenerator.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string EmployerName = "employername";
        private const string EmployerNameAsShownInTheAdvert = "employernameasshownintheadvert";
        private const string VacancyReference = "vacancyreference";
        private const string VacancyType = "vacancytype";
        private const string FAAUsername = "faaLoginWithNewAccountusername";
        private const string FAAPassword = "faaLoginWithNewAccountpassword";
        private const string FAAFirstname = "faaLoginWithNewAccountfirstname";
        private const string FAALastname = "faaLoginWithNewAccountlastname";
        #endregion

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

        public static void SetVacancyReference(this ObjectContext objectContext, string value) => objectContext.Set(VacancyReference, value);
        public static string GetVacancyReference(this ObjectContext objectContext) => objectContext.Get(VacancyReference);
        public static void SetEmployerName(this ObjectContext objectContext, string value) => objectContext.Set(EmployerName, value);
        public static string GetEmployerName(this ObjectContext objectContext) => objectContext.Get(EmployerName);
        public static void SetEmployerNameAsShownInTheAdvert(this ObjectContext objectContext, string value) => objectContext.Set(EmployerNameAsShownInTheAdvert, value);
        public static string GetEmployerNameAsShownInTheAdvert(this ObjectContext objectContext) => objectContext.Get(EmployerNameAsShownInTheAdvert);
        
    }
}
