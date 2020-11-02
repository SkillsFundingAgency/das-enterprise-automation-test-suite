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

        public static string GetDirectory(this ObjectContext objectContext) => objectContext.Get(DirectoryKey);
        
        public static void SetAfterScenarioException(this ObjectContext objectContext, Exception value) => objectContext.GetAfterScenarioExceptions().Add(value);
        
        public static FrameworkList<Exception> GetAfterScenarioExceptions(this ObjectContext objectContext) => objectContext.Get<FrameworkList<Exception>>(AfterScenarioExceptions);

        internal static void SetDirectory(this ObjectContext objectContext, string value) => objectContext.Set(DirectoryKey, value);

        internal static void SetTestDataList(this ObjectContext objectContext)
        {
            objectContext.Set(AfterStepInformations, new FrameworkList<string>() { $"{string.Empty}" });
            objectContext.Set(AfterScenarioExceptions, new FrameworkList<Exception>() { null });
        }
        internal static void SetAfterStepInformation(this ObjectContext objectContext, string value) => objectContext.GetAfterStepInformations().Add(value);

        private static FrameworkList<string> GetAfterStepInformations(this ObjectContext objectContext) => objectContext.Get<FrameworkList<string>>(AfterStepInformations);
        
    }
}