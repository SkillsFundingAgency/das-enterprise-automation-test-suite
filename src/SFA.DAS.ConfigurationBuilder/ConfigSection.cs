using Microsoft.Extensions.Configuration;

namespace SFA.DAS.ConfigurationBuilder
{
    public class ConfigSection(IConfigurationRoot configurationRoot) : IConfigSection
    {
        public T GetConfigSection<T>() => configurationRoot.GetSection(typeof(T).Name).Get<T>();

        public T GetConfigSection<T>(string sectionName) => configurationRoot.GetSection(sectionName).Get<T>();
    }
}