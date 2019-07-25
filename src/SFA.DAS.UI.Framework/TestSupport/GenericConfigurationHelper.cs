using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public static class GenericConfigurationHelper
    {
        public static void SetConfigurationRoot(this ScenarioContext context, IConfigurationRoot configurationRoot)
        {
            context.Set(configurationRoot, "root");
        }

        public static IConfigurationRoot GetConfigurationRoot(this ScenarioContext context)
        {
            return context.Get<IConfigurationRoot>("root");
        }
    }

}