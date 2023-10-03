namespace SFA.DAS.ConfigurationBuilder
{
    public interface IConfigSection
    {
        T GetConfigSection<T>();

        T GetConfigSection<T>(string sectionName);

        string GetDebugView();
    }
}