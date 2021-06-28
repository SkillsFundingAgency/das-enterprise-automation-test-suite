using TechTalk.SpecFlow;

namespace SFA.DAS.PayeCreation.Project
{
    internal static class ScenarioContextExtension
    {
        #region Constants
        private const string PayeCreationConfigKey = "payecreationconfigkey";
        #endregion

        internal static void SetPayeCreationConfig(this ScenarioContext context, PayeCreationConfig value) => context.Set(value, PayeCreationConfigKey);

        internal static PayeCreationConfig GetPayeCreationConfig(this ScenarioContext context) => context.Get<PayeCreationConfig>(PayeCreationConfigKey);
    }
}
