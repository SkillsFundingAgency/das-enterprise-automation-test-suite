namespace SFA.DAS.API.Framework.Configs;

public abstract class Inner_ApiAuthConfigUsingMI : Inner_ApiBaseAuthConfig
{
    public Inner_ApiAuthConfigUsingMI(Inner_ApiConfig config) => Tenant = config.Tenant;
}
