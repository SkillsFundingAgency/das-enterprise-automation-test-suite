using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataCleanup;
using System;

namespace SFA.DAS.TestDataExport
{
    public static class ObjectContextExtension
    {
        #region Constants
        private const string AfterStepInformations = "afterstepinformations";
        private const string AfterScenarioExceptions = "afterscenarioexceptions";
        #endregion

        public static void SetAfterScenarioException(this ObjectContext objectContext, Exception value) => objectContext.GetAfterScenarioExceptions().Add(value);

        public static FrameworkList<Exception> GetAfterScenarioExceptions(this ObjectContext objectContext) => objectContext.Get<FrameworkList<Exception>>(AfterScenarioExceptions);

        public static void SetAfterStepInformation(this ObjectContext objectContext, string value) => objectContext.GetAfterStepInformations().Add(value);

        private static FrameworkList<string> GetAfterStepInformations(this ObjectContext objectContext) => objectContext.Get<FrameworkList<string>>(AfterStepInformations);

        public static void SetTestDataList(this ObjectContext objectContext)
        {
            objectContext.SetAfterStepInformations();
            objectContext.SetAfterScenarioExceptions();
            objectContext.SetAfterScenarioTestDataTearDown();
        }

        private static void SetAfterStepInformations(this ObjectContext objectContext) => objectContext.Set(AfterStepInformations, new FrameworkList<string>() { $"{string.Empty}" });

        private static void SetAfterScenarioExceptions(this ObjectContext objectContext) => objectContext.Set(AfterScenarioExceptions, new FrameworkList<Exception>() { null });
    }
}