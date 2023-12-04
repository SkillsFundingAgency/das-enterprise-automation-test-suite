
using SFA.DAS.Login.Service.Project.Helpers;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project
{
    public static class AANObjectContextExtension
    {
        private const string LoggedInUser = "loggedinuser";

        internal static void SetLoginCredentials(this ObjectContext objectContext, AanBaseUser value) => objectContext.Set(LoggedInUser, value);

        public static AanBaseUser GetLoginCredentials(this ObjectContext objectContext) => objectContext.Get<AanBaseUser>(LoggedInUser);


        private const string AanAdminEventId = "aanadmineventid";

        internal static void SetAanAdminEventId(this ObjectContext objectContext, string value) => objectContext.Set(AanAdminEventId, value);

        public static string GetAanAdminEventId(this ObjectContext objectContext) => objectContext.Get(AanAdminEventId);

        private const string AanEventTitle= "aaneventtitle";

        internal static void SetAanEventTitle(this ObjectContext objectContext, string value) => objectContext.Replace(AanEventTitle, value);

        public static string GetAanEventTitle(this ObjectContext objectContext) => objectContext.Get(AanEventTitle);
    }
}
