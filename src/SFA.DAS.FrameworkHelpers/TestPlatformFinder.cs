namespace SFA.DAS.FrameworkHelpers;

public static class TestPlatformFinder
{
    public static readonly bool IsAdoExecution;

    static TestPlatformFinder()
    {
        IsAdoExecution = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("AGENT_MACHINENAME"));
    }
}