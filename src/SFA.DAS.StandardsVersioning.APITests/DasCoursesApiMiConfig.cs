using SFA.DAS.API.Framework;

namespace SFA.DAS.StandardsVersioning.APITests
{
    public class DasCoursesApiMiConfig : ManageIdentityOathTokenConfig
    {
        protected override string ApiName => "das-at-crsapi-as-ar";
    }
}