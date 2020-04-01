using System;
using System.Collections.Generic;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TestDataExport
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string BrowserKey = "browser";
        private const string DirectoryKey = "directory";
        private const string AfterScenarioExceptions = "afterscenarioexceptions";
        private const string BrowserNameKey = "browsername";
        private const string BrowserVersionKey = "browserVersion";
        private const string BrowserstackFailedToUpdateTestResult = "browserstackfailedtoupdatetestresult";
        private const string WebDriverUrl = "webdriverurl";
        private const string CurrentApplicationName = "currentapplicationname";
        #endregion

        public static void SetDirectory(this ObjectContext objectContext, string value) => objectContext.Set(DirectoryKey, value);
        public static string GetDirectory(this ObjectContext objectContext) => objectContext.Get(DirectoryKey);
        public static void SetAfterScenarioException(this ObjectContext objectContext, Exception value) => objectContext.GetAfterScenarioExceptions().Add(value);
        public static void SetAfterScenarioExceptions(this ObjectContext objectContext, List<Exception> afterscenarioexceptions) => objectContext.Set(AfterScenarioExceptions, afterscenarioexceptions);
        public static List<Exception> GetAfterScenarioExceptions(this ObjectContext objectContext) => objectContext.Get<List<Exception>>(AfterScenarioExceptions);
    }
}