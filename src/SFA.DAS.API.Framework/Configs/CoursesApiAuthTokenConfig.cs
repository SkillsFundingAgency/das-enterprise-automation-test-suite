using SFA.DAS.ConfigurationBuilder;

namespace SFA.DAS.API.Framework.Configs
{
    public class CoursesApiAuthTokenConfig : InnerApiAuthTokenConfig
    {
        protected override string ApiName => $"das-{EnvironmentConfig.EnvironmentName}-crsapi-as-ar";
    }
}