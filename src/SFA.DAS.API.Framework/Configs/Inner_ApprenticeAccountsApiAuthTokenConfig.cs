namespace SFA.DAS.API.Framework.Configs;

public class Inner_ApprenticeAccountsApiAuthTokenConfig : Inner_ApiAuthConfigUsingMI
{
    private readonly Inner_ApiConfig _config;

    protected override string AppServiceName => _config.ApprenticeAccountsAppServiceName;

    public Inner_ApprenticeAccountsApiAuthTokenConfig(Inner_ApiConfig config) : base(config) => _config = config;
}