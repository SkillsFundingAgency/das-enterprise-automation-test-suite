using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.API.Framework.Configs
{
    public class Inner_CoursesApiAuthTokenConfig : Inner_ApiAuthTokenConfig
    {
        protected override string ApiName => $"das-{EnvironmentConfig.EnvironmentName}-crsapi-as-ar";
    }
}