using Microsoft.Extensions.Configuration;

namespace SFA.DAS.ConfigurationBuilder
{
    public class ConfigSection : IConfigSection
    {
        private readonly IConfigurationRoot _configurationRoot;

        public ConfigSection(IConfigurationRoot configurationRoot) => _configurationRoot = configurationRoot;
        
        public T GetConfigSection<T>() => _configurationRoot.GetSection(typeof(T).Name).Get<T>();
    }
}