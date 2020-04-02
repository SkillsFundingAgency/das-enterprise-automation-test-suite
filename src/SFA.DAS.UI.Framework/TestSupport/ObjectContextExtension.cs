using System;
using System.Collections.Generic;
using SFA.DAS.ConfigurationBuilder;

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
        #endregion

        public static void SetCurrentApplicationName(this ObjectContext objectContext, string value) => objectContext.Replace(CurrentApplicationName, value);
        public static string GetCurrentApplicationName(this ObjectContext objectContext) => objectContext.Get(CurrentApplicationName);
        public static string GetBrowser(this ObjectContext objectContext) => objectContext.Get(BrowserKey);
        public static void SetBrowser(this ObjectContext objectContext, string browser) => objectContext.Set(BrowserKey, browser);
        public static void SetBrowserName(this ObjectContext objectContext, object value) => objectContext.Set(BrowserNameKey, value);
        public static void SetBrowserVersion(this ObjectContext objectContext, object value) => objectContext.Set(BrowserVersionKey, value);
        internal static string GetUrl(this ObjectContext objectContext) => objectContext.Get(WebDriverUrl);
        internal static void SetUrl(this ObjectContext objectContext, string value) => objectContext.Set(WebDriverUrl, value);
        internal static void SetBrowserstackResponse(this ObjectContext objectContext) => objectContext.Set(BrowserstackFailedToUpdateTestResult, true);
        public static bool FailedtoUpdateTestResultInBrowserStack(this ObjectContext objectContext) => objectContext.KeyExists<bool>(BrowserstackFailedToUpdateTestResult);
    }
}