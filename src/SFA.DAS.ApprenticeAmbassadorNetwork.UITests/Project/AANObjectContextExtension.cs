
using SFA.DAS.Login.Service.Project.Helpers;

namespace SFA.DAS.ApprenticeAmbassadorNetwork.UITests.Project
{
    public static class AANObjectContextExtension
    {
        private const string LoggedInUser = "loggedinuser";

        internal static void SetLoginCredentials(this ObjectContext objectContext, AanBaseUser value) => objectContext.Set(LoggedInUser, value);

        public static AanBaseUser GetLoginCredentials(this ObjectContext objectContext) => objectContext.Get<AanBaseUser>(LoggedInUser);
    }
}
