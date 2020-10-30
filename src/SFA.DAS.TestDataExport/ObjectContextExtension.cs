using System;
using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.TestDataExport
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string DirectoryKey = "directory";
        private const string AfterScenarioExceptions = "afterscenarioexceptions";
        private const string AfterStepInformations = "afterstepinformations";
        #endregion

        public static void SetDirectory(this ObjectContext objectContext, string value) => objectContext.Set(DirectoryKey, value);
        public static string GetDirectory(this ObjectContext objectContext) => objectContext.Get(DirectoryKey);
        public static void SetAfterScenarioException(this ObjectContext objectContext, Exception value) => objectContext.GetAfterScenarioExceptions().Add(value);
        public static void SetAfterScenarioExceptions(this ObjectContext objectContext) => objectContext.Set(AfterScenarioExceptions, new FrameworkList<Exception>() { null });
        public static FrameworkList<Exception> GetAfterScenarioExceptions(this ObjectContext objectContext) => objectContext.Get<FrameworkList<Exception>>(AfterScenarioExceptions);
        public static void SetAfterStepInformations(this ObjectContext objectContext) => objectContext.Set(AfterStepInformations, new FrameworkList<string>() { $"{string.Empty}" });
        public static FrameworkList<string> GetAfterStepInformations(this ObjectContext objectContext) => objectContext.Get<FrameworkList<string>>(AfterStepInformations);
        public static void SetAfterStepInformation(this ObjectContext objectContext, string value) => objectContext.GetAfterStepInformations().Add(value);
        internal static void ReplaceAfterStepInformation(this ObjectContext objectContext)
        {
            var tempList = objectContext.GetAfterStepInformations();

            objectContext.Remove(AfterStepInformations);

            objectContext.Set(AfterStepInformations, tempList);
        }
    }
}