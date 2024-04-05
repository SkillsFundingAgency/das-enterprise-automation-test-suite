namespace SFA.DAS.FrameworkHelpers;

public static class TestPlatformFinder
{
    public static readonly bool IsAzureExecution;

    static TestPlatformFinder()
    {
        IsAzureExecution = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AGENT_MACHINENAME"));
    }
}