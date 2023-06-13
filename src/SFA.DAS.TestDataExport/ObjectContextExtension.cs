using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataCleanup;
using System;
using System.Collections.Generic;

namespace SFA.DAS.TestDataExport
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string AfterStepInformations = "afterstepinformations";
        private const string AfterScenarioExceptions = "afterscenarioexceptions";
        private const string DebugInformations = "testdebuginformations";
        private const string AccessibilityInformations = "accessibilityinformations";
        #endregion

        internal static void SetTestDataList(this ObjectContext objectContext)
        {
            objectContext.SetDebugInformations();
            objectContext.SetAccessibilityInformations();
            objectContext.SetAfterStepInformations();
            objectContext.SetAfterScenarioExceptions();
            objectContext.SetAfterScenarioTestDataTearDown();
        }

        #region AfterStepInformations

        private static void SetAfterStepInformations(this ObjectContext objectContext) => objectContext.Set(AfterStepInformations, new List<string>() { $"{string.Empty}" });

        internal static void SetAfterStepInformation(this ObjectContext objectContext, string value) => objectContext.GetAfterStepInformations().Add(value);

        private static List<string> GetAfterStepInformations(this ObjectContext objectContext) => objectContext.Get<List<string>>(AfterStepInformations);
        #endregion

        #region AfterScenarioExceptions

        private static void SetAfterScenarioExceptions(this ObjectContext objectContext) => objectContext.Set(AfterScenarioExceptions, new FrameworkList<Exception>() { null });

        public static void SetAfterScenarioException(this ObjectContext objectContext, Exception value) => objectContext.GetAfterScenarioExceptions().Add(value);

        public static FrameworkList<Exception> GetAfterScenarioExceptions(this ObjectContext objectContext) => objectContext.Get<FrameworkList<Exception>>(AfterScenarioExceptions);
        #endregion

        #region DebugInformations

        private static void SetDebugInformations(this ObjectContext objectContext) => objectContext.Set(DebugInformations, new FrameworkList<string>() { $"{string.Empty}" });

        public static void SetDebugInformation(this ObjectContext objectContext, string value) => objectContext.GetDebugInformations().Add($"-> {DateTime.UtcNow:dd/MM HH:mm:ss}: {value}");
        
        private static FrameworkList<string> GetDebugInformations(this ObjectContext objectContext) => objectContext.Get<FrameworkList<string>>(DebugInformations);
        #endregion

        #region AccessibilityInformations

        private static void SetAccessibilityInformations(this ObjectContext objectContext) => objectContext.Set(AccessibilityInformations, new FrameworkList<string>() { $"{string.Empty}" });

        public static void SetAccessibilityInformation(this ObjectContext objectContext, string value) => objectContext.GetAccessibilityInformations().Add($"-> {value}");

        public static FrameworkList<string> GetAccessibilityInformations(this ObjectContext objectContext) => objectContext.Get<FrameworkList<string>>(AccessibilityInformations);
        #endregion

    }
}