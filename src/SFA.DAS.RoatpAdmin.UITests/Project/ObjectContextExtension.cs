using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.RoatpAdmin.UITests.Project.Helpers;

namespace SFA.DAS.RoatpAdmin.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string ClarificationJourney = "clarificationjourney";
        private const string ApplicationRoute = "applicationroute";
        private const string UploadFile = "uploadfile";
        #endregion

        internal static void SetClarificationJourney(this ObjectContext objectContext) => objectContext.Set(ClarificationJourney, true);

        internal static void SetApplicationRoute(this ObjectContext objectContext, ApplicationRoute applicationRoute) => objectContext.Set(ApplicationRoute, applicationRoute);

        internal static bool IsClarificationJourney(this ObjectContext objectContext) => objectContext.KeyExists<bool>(ClarificationJourney);

        internal static void SetIsUploadFile(this ObjectContext objectContext) => objectContext.Replace(UploadFile, true);

        internal static void ResetIsUploadFile(this ObjectContext objectContext) => objectContext.Remove<bool>(UploadFile);

        internal static bool IsUploadFile(this ObjectContext objectContext) => objectContext.KeyExists<bool>(UploadFile);

        internal static ApplicationRoute GetApplicationRoute(this ObjectContext objectContext) => objectContext.Get<ApplicationRoute>(ApplicationRoute);
    }
}
