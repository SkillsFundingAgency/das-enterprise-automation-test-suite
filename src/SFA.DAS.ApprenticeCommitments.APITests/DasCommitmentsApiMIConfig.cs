using SFA.DAS.API.Framework;

namespace SFA.DAS.ApprenticeCommitments.APITests
{
    public class DasCommitmentsApiMIConfig : ManageIdentityOathTokenConfig
    {
        protected override string ApiName => "das-commitments-api";
    }
}