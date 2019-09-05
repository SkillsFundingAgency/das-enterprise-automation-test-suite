namespace SFA.DAS.UI.Framework.TestSupport
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string BrowserKey = "browser";
        #endregion

        public static string GetBrowser(this ObjectContext objectContext)
        {
            return objectContext.Get(BrowserKey);
        }

        public static void ReplaceBrowser(this ObjectContext objectContext, string browser)
        {
            objectContext.Replace(BrowserKey, browser);
        }
    }
}
