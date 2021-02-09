using SFA.DAS.API.Framework;

namespace SFA.DAS.StandardsVersioning.APITests
{
    public class DasCoursesApiMiConfig : ManageIdentityOathTokenConfig
    {
        protected override string ResourceEndpoint => "das-courses-api";
    }
}