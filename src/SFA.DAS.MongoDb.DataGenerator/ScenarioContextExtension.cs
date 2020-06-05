using TechTalk.SpecFlow;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.MongoDb.DataGenerator
{
    public static class ScenarioContextExtension
    {
        #region Constants
        private const string MongoDbConfigKey = "mongodbconfigkey";
        #endregion

        public static void SetMongoDbConfig(this ScenarioContext context, MongoDbConfig value)
        {
            context.Set(value, MongoDbConfigKey);
        }

        public static MongoDbConfig GetMongoDbConfig(this ScenarioContext context)
        {
            return context.Get<MongoDbConfig>(MongoDbConfigKey);
        }
    }
}
