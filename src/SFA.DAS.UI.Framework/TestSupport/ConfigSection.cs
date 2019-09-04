using Microsoft.Extensions.Configuration;

namespace SFA.DAS.UI.Framework.TestSupport
{
    public class ConfigSection : IConfigSection
    {
        private readonly IConfigurationRoot _configurationRoot;

        public ConfigSection(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }
        
        public T GetConfigSection<T>()
        {
            return _configurationRoot.GetSection(typeof(T).Name).Get<T>();
        }
    }
}