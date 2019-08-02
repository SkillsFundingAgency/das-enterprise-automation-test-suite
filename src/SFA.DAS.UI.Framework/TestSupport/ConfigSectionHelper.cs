using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public class ConfigSectionHelper : IConfigSection
    {
        private readonly IConfigurationRoot _configurationRoot;

        public ConfigSectionHelper(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }
        
        public T GetConfigSection<T>()
        {
            return _configurationRoot.GetSection(typeof(T).Name).Get<T>();
        }
    }
}