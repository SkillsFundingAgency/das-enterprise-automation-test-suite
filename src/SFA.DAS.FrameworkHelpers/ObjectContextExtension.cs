using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.TestDataExport
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string RetryInformations = "testretryinformations";
        #endregion

        public static void SetRetryInformationList(this ObjectContext objectContext) => objectContext.SetRetryInformations();

       
        #region RetryInformations

        private static void SetRetryInformations(this ObjectContext objectContext) => objectContext.Set(RetryInformations, new FrameworkList<string>() { $"{string.Empty}" });

        public static void SetRetryInformation(this ObjectContext objectContext, string value) => objectContext.GetRetryInformations().Add($"{value}");

        private static FrameworkList<string> GetRetryInformations(this ObjectContext objectContext) => objectContext.Get<FrameworkList<string>>(RetryInformations);
        #endregion

    }
}