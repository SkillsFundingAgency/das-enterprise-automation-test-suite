using LrsWcfWebServiceReference;
using System;
using System.Threading.Tasks;

namespace SFA.DAS.LearnerVerification.Service.Project.Helpers.LRSWebService
{
    public class ClientWrapper
    {
        private readonly LearnerPortTypeClient _client;

        public ClientWrapper(LearnerPortTypeClient client)
        {
            _client = client;
        }

        public Task<registerSingleLearnerResponse> RegisterLearnerAsync(RegisterSingleLearnerRqst RegisterLearner)
        {
            return _client.registerSingleLearnerAsync(RegisterLearner);
        }

        public async ValueTask DisposeAsync()
        {
            await (_client as IAsyncDisposable).DisposeAsync();
        }
    }
}