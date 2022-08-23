namespace SFA.DAS.API.Framework.Configs;

public class Inner_CoursesApiAuthTokenConfig : Inner_ApiAuthConfigUsingOAuth
{
    protected override string AppServiceName => $"das-{EnvironmentConfig.EnvironmentName}-crsapi-as-ar";
}