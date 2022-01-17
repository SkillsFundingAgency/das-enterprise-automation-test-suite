using System;
using System.Collections.Generic;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.ConfigurationBuilder
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string DirectoryKey = "directory";
        private const string AfterScenarioExceptions = "afterscenarioexceptions";
        private const string AfterStepInformations = "afterstepinformations";
        private const string AfterScenarioTestDataTearDown = "afterscenariotestdatateardown";
        #endregion

        public static string GetDirectory(this ObjectContext objectContext) => objectContext.Get(DirectoryKey);

        public static void SetDbNameToTearDown(this ObjectContext objectContext, string dbName, string value)
        {
            var dictionary = objectContext.GetDbNameToTearDown();

            if (!dictionary.ContainsKey(dbName)) dictionary.Add(dbName, new HashSet<string> { });

            dictionary[dbName].Add(value);
        }

        public static void SetAfterScenarioException(this ObjectContext objectContext, Exception value) => objectContext.GetAfterScenarioExceptions().Add(value);

        public static FrameworkList<Exception> GetAfterScenarioExceptions(this ObjectContext objectContext) => objectContext.Get<FrameworkList<Exception>>(AfterScenarioExceptions);

        internal static void SetDirectory(this ObjectContext objectContext, string value) => objectContext.Set(DirectoryKey, value);

        internal static void SetTestDataList(this ObjectContext objectContext)
        {
            objectContext.Set(AfterStepInformations, new FrameworkList<string>() { $"{string.Empty}" });
            objectContext.Set(AfterScenarioExceptions, new FrameworkList<Exception>() { null });
            objectContext.Set(AfterScenarioTestDataTearDown, new Dictionary<string, HashSet<string>>());
        }

        public static void SetAfterStepInformation(this ObjectContext objectContext, string value) => objectContext.GetAfterStepInformations().Add(value);

        public static Dictionary<string, HashSet<string>> GetDbNameToTearDown(this ObjectContext objectContext) => objectContext.Get<Dictionary<string, HashSet<string>>>(AfterScenarioTestDataTearDown);

        private static FrameworkList<string> GetAfterStepInformations(this ObjectContext objectContext) => objectContext.Get<FrameworkList<string>>(AfterStepInformations);


    }
}