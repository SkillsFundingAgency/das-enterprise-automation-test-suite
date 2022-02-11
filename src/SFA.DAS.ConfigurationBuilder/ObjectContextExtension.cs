namespace SFA.DAS.ConfigurationBuilder
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string DirectoryKey = "directory";
        #endregion

        public static string GetDirectory(this ObjectContext objectContext) => objectContext.Get(DirectoryKey);

        internal static void SetDirectory(this ObjectContext objectContext, string value) => objectContext.Set(DirectoryKey, value);
    }
}