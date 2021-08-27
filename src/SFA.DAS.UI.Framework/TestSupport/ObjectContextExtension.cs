using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string BrowserKey = "browser";
        private const string BrowserNameKey = "browsername";
        private const string BrowserVersionKey = "browserVersion";
        private const string BrowserstackFailedToUpdateTestResult = "browserstackfailedtoupdatetestresult";
        private const string WebDriverUrl = "webdriverurl";
        private const string CurrentApplicationName = "currentapplicationname";
        private const string ChromedriverVersion = "chromedriverVersion";
        private static readonly List<string> AuthUrls = new List<string>();
        #endregion

        public static string AuthUrlKey => UrlKeyHelper.AuthUrlKey;

        public static void SetCurrentApplicationName(this ObjectContext objectContext, string value) => objectContext.Replace(CurrentApplicationName, value);
        public static string GetCurrentApplicationName(this ObjectContext objectContext) => objectContext.Get(CurrentApplicationName);
        public static string GetBrowser(this ObjectContext objectContext) => objectContext.Get(BrowserKey);
        public static void SetBrowser(this ObjectContext objectContext, string browser) => objectContext.Set(BrowserKey, browser);
        public static void SetBrowserName(this ObjectContext objectContext, object value) => objectContext.Replace(BrowserNameKey, value);
        public static void SetBrowserVersion(this ObjectContext objectContext, object value) => objectContext.Replace(BrowserVersionKey, value);
        internal static string GetChromedriverVersion(this ObjectContext objectContext) => objectContext.Get(ChromedriverVersion);
        internal static string GetUrl(this ObjectContext objectContext) => objectContext.Get(WebDriverUrl);
        internal static void SetUrl(this ObjectContext objectContext, string value) => objectContext.Set(WebDriverUrl, value);
        public static List<string> GetAuthUrl(this ObjectContext objectContext) => objectContext.Get<List<string>>(AuthUrlKey);
        public static void InitAuthUrl(this ObjectContext objectContext) => objectContext.Set(AuthUrlKey, AuthUrls);
        internal static void SetAuthUrl(this ObjectContext objectContext, string value) => objectContext.GetAuthUrl().Add(value);
        internal static void SetBrowserstackResponse(this ObjectContext objectContext) => objectContext.Set(BrowserstackFailedToUpdateTestResult, true);
        public static bool FailedtoUpdateTestResultInBrowserStack(this ObjectContext objectContext) => objectContext.KeyExists<bool>(BrowserstackFailedToUpdateTestResult);
    }
}