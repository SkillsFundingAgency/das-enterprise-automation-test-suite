namespace SFA.DAS.UI.Framework.TestSupport
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string BrowserKey = "browser";
        private const string DirectoryKey = "directory";
        #endregion

        public static string GetBrowser(this ObjectContext objectContext)
        {
            return objectContext.Get(BrowserKey);
        }

        public static void ReplaceBrowser(this ObjectContext objectContext, string browser)
        {
            objectContext.Replace(BrowserKey, browser);
        }

        public static void SetDirectory(this ObjectContext objectContext, string value)
        {
            objectContext.Set(DirectoryKey, value);
        }

        public static string GetDirectory(this ObjectContext objectContext)
        {
            return objectContext.Get(DirectoryKey);
        }
    }
}
