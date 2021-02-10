using System.Threading.Tasks;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers.Requests;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    public class EIApplicationsApiHelper
    {
        private ApiClient _apiClient;

        public EIApplicationsApiHelper(EIConfig config)
        {
            _apiClient = new ApiClient(config);
        }

        public async Task CreateApplication(CreateIncentiveApplicationRequest application)
        {
            await _apiClient.Post($"/applications", application);
        }

        public async Task SubmitApplication(SubmitIncentiveApplicationRequest application)
        {
            await _apiClient.Patch($"/applications/{application.IncentiveApplicationId}", application);
        }
    }
}
