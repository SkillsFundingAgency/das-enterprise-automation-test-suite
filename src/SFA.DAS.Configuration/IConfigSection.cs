namespace SFA.DAS.Configuration
{
    public interface IConfigSection
    {
        T GetConfigSection<T>();
    }
}