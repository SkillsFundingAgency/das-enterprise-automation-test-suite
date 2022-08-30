namespace SFA.DAS.API.Framework.Configs;

public class Inner_ApiFrameworkConfig 
{
    public Inner_ApiAuthTokenConfig config;

    public Inner_ApiFrameworkConfig(Inner_ApiAuthTokenConfig config) => this.config = config;

    internal bool IsVstsExecution { get; init; }

    public string GetResource(string appServiceName) => UriHelper.GetAbsoluteUri($"https://{config.Tenant}", appServiceName);
}
