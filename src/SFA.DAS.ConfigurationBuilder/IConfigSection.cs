namespace SFA.DAS.ConfigurationBuilder
{
    public interface IConfigSection
    {
        T GetConfigSection<T>();
    }
}