using SFA.DAS.API.Framework;

namespace SFA.DAS.FAT_V2.APITests.Project
{
    public class FatV2RestClient : OuterApiRestClient
    {
        public FatV2RestClient(string subscriptionkey) : base(subscriptionkey) { }

        protected override string ApiName => "/epaoregister";
    }
}
