namespace SFA.DAS.FrameworkHelpers
{
    public static class OC_TestDataListExtension
    {
        #region Constants
        private const string AfterStepInformations = "afterstepinformations";
        private const string AfterScenarioExceptions = "afterscenarioexceptions";
        private const string DebugInformations = "testdebuginformations";
        private const string AccessibilityInformations = "accessibilityinformations";
        private const string AccessibilityPageTitle = "accessibilitypagetitle";
        private const string RetryInformations = "testretryinformations";

        #endregion

        public static void SetTestDataList(this ObjectContext objectContext, string[] tags)
        {
            objectContext.SetDebugInformations(tags);
            objectContext.SetAccessibilityInformations();
            objectContext.SetAccessibilityPageTitles();
            objectContext.SetAfterStepInformations();
            objectContext.SetAfterScenarioExceptions();
            objectContext.SetAfterScenarioTestDataTearDown();
            objectContext.SetRetryInformations();
        }



        #region RetryInformations

        private static void SetRetryInformations(this ObjectContext objectContext) => objectContext.Set(RetryInformations, new FrameworkList<string>() { $"{string.Empty}" });

        public static void SetRetryInformation(this ObjectContext objectContext, string value) => objectContext.GetRetryInformations().Add($"{value}");

        private static FrameworkList<string> GetRetryInformations(this ObjectContext objectContext) => objectContext.Get<FrameworkList<string>>(RetryInformations);
        #endregion

        #region AfterStepInformations

        private static void SetAfterStepInformations(this ObjectContext objectContext) => objectContext.Set(AfterStepInformations, new List<string>() { $"{string.Empty}" });

        public static void SetAfterStepInformation(this ObjectContext objectContext, string value) => objectContext.GetAfterStepInformations().Add(value);

        private static List<string> GetAfterStepInformations(this ObjectContext objectContext) => objectContext.Get<List<string>>(AfterStepInformations);
        #endregion

        #region AfterScenarioExceptions

        private static void SetAfterScenarioExceptions(this ObjectContext objectContext) => objectContext.Set(AfterScenarioExceptions, new FrameworkList<Exception>() { null });

        public static void SetAfterScenarioException(this ObjectContext objectContext, Exception value) => objectContext.GetAfterScenarioExceptions().Add(value);

        public static FrameworkList<Exception> GetAfterScenarioExceptions(this ObjectContext objectContext) => objectContext.Get<FrameworkList<Exception>>(AfterScenarioExceptions);
        #endregion

        #region DebugInformations

        private static void SetDebugInformations(this ObjectContext objectContext, string[] tags)
        {
            objectContext.Set(DebugInformations, new FrameworkList<string>() { $"{string.Empty}" });

            objectContext.SetDebugInformation($"Scenario tags - {string.Join(", ", tags.Select(x => x))}");
        }

        public static void SetDebugInformation(this ObjectContext objectContext, string value) => objectContext.GetDebugInformations().Add($"-> {DateTime.UtcNow:dd/MM HH:mm:ss}: {value}");

        private static FrameworkList<string> GetDebugInformations(this ObjectContext objectContext) => objectContext.Get<FrameworkList<string>>(DebugInformations);
        #endregion

        #region AccessibilityInformations

        private static void SetAccessibilityInformations(this ObjectContext objectContext) => objectContext.Set(AccessibilityInformations, new FrameworkList<string>() { $"{string.Empty}" });

        public static void SetAccessibilityInformation(this ObjectContext objectContext, string value) => objectContext.GetAccessibilityInformations().Add($"-> {value}");

        public static FrameworkList<string> GetAccessibilityInformations(this ObjectContext objectContext) => objectContext.Get<FrameworkList<string>>(AccessibilityInformations);
        #endregion

        #region AccessibilityPageTitle

        private static void SetAccessibilityPageTitles(this ObjectContext objectContext) => objectContext.Set(AccessibilityPageTitle, new FrameworkList<string>());

        public static void SetAccessibilityPageTitle(this ObjectContext objectContext, string value) => objectContext.GetAccessibilityPageTitles().Add(value);

        public static FrameworkList<string> GetAccessibilityPageTitles(this ObjectContext objectContext) => objectContext.Get<FrameworkList<string>>(AccessibilityPageTitle);
        #endregion

    }
}