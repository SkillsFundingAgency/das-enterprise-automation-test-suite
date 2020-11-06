using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.RoatpAdmin.UITests.Project
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string ClarificationJourney = "clarificationjourney";
        private const string UploadFile = "uploadfile";
        #endregion

        internal static void SetClarificationJourney(this ObjectContext objectContext) => objectContext.Set(ClarificationJourney, true);

        internal static bool IsClarificationJourney(this ObjectContext objectContext) => objectContext.KeyExists<bool>(ClarificationJourney);

        internal static void SetIsUploadFile(this ObjectContext objectContext) => objectContext.Set(UploadFile, true);

        internal static void ResetIsUploadFile(this ObjectContext objectContext) => objectContext.Remove<bool>(UploadFile);

        internal static bool IsUploadFile(this ObjectContext objectContext) => objectContext.KeyExists<bool>(UploadFile);
    }
}
