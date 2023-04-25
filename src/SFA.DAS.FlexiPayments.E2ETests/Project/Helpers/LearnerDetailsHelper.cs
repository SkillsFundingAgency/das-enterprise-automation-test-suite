using SFA.DAS.FlexiPayments.E2ETests.Project.Helpers.SqlDbHelpers;
using SFA.DAS.LearnerVerification.Service.Project;
using SFA.DAS.LearnerVerification.Service.Project.Helpers;
using SFA.DAS.LearnerVerification.Service.Project.Helpers.Models;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.FlexiPayments.E2ETests.Project.Helpers
{
    public class LearnerDetailsHelper
    {
        private readonly ApprenticeshipsSqlDbHelper _apprenticeshipsSqlDbHelper;
        private readonly LearnerRegistrationApiHelper _learnerRegistrationApiHelper;
        private readonly LearnerVerificationConfig _config;

        public LearnerDetailsHelper(ScenarioContext context)
        {
            _config = context.GetLearnerVerificationProcessConfig<LearnerVerificationConfig>();
            _apprenticeshipsSqlDbHelper = context.Get<ApprenticeshipsSqlDbHelper>();
            _learnerRegistrationApiHelper = new LearnerRegistrationApiHelper(context, _config);
        }

        public async Task<LearnerRegistrationResponse> RegisterLearner(LearnerRegistrationParameters parameters)
        {
            bool isUlnUnique = false;
            LearnerRegistrationResponse response = null;
            int numberOfAttempts = 0;

            while (isUlnUnique & numberOfAttempts < _config.LV_MaxNumberOfLearnerRegistrationAttempts)
            {
                response = await _learnerRegistrationApiHelper.RegisterLearnerAsync(parameters.FirstName, parameters.LastName, parameters.PostCode, parameters.DateOfBirth, ((int)parameters.Gender).ToString());
                isUlnUnique = _apprenticeshipsSqlDbHelper.VerifyUlnIsUnique(response.Uln);
                numberOfAttempts++;
            }
            return response;
        }
    }
}