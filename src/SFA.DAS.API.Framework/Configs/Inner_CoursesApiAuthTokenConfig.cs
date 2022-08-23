namespace SFA.DAS.API.Framework.Configs;

public class Inner_CoursesApiAuthTokenConfig : Inner_ApiAuthConfigUsingMI
{
    private readonly Inner_ApiConfig _config;

    protected override string AppServiceName => _config.CoursesAppServiceName;

    public Inner_CoursesApiAuthTokenConfig(Inner_ApiConfig config) : base(config) => _config = config;
}