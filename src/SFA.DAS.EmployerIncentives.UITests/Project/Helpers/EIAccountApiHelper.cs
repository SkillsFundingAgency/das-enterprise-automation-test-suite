using System.Threading.Tasks;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers.Requests;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    public class EIAccountApiHelper
    {
        private ApiClient _apiClient;

        public EIAccountApiHelper(EIConfig config)
        {
            _apiClient = new ApiClient(config);
        }

        public async Task UpsertLegalEntity(long accountId, AccountLegalEntityCreateRequest legalEntity)
        {
            await _apiClient.Post($"/accounts/{accountId}/legalEntities", legalEntity);
        }
    }
}
