using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public static class GenericConfigurator
    {
        public static T GetConfigSection<T>(this ScenarioContext context)
        {
            return context.GetConfigurationRoot().GetSection(typeof(T).Name).Get<T>();
        }
    }
}