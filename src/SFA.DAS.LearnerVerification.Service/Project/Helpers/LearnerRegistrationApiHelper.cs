using LrsWcfWebServiceReference;
using SFA.DAS.LearnerVerification.Service.Project.Helpers.LRSWebService;
using SFA.DAS.LearnerVerification.Service.Project.Helpers.Models;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.LearnerVerification.Service.Project.Helpers
{
    public class LearnerRegistrationApiHelper
    {
        private LearnerVerificationConfig _config { get; set; }

        public LearnerRegistrationApiHelper(ScenarioContext context)
        {
            _config = context.GetLearnerVerificationProcessConfig<LearnerVerificationConfig>();
        }

        public async Task<LearnerRegistrationResponse> RegisterLearner(LearnerRegistrationParameters parameters)
        {
            var response = await RegisterLearnerAsync(parameters.FirstName, parameters.LastName, parameters.PostCode, parameters.DateOfBirth, ((int)parameters.Gender).ToString());
            return response;
        }

        private async Task<LearnerRegistrationResponse> RegisterLearnerAsync(string firstName, string lastName, string postcode, DateTime dateOfBirth, string gender)
        {
            await using var service = new ClientProvider(_config).Get();
            var learnerRegistrationResponse = await service.RegisterLearnerAsync(new RegisterSingleLearnerRqst()
            {
                OrganisationRef = _config.LV_OrganisationRef,
                OrgPassword = _config.LV_OrgPassword,
                UserName = _config.LV_UserName,
                Learner = new LearnerToRegister()
                {
                    GivenName = firstName,
                    FamilyName = lastName,
                    LastKnownPostCode = postcode,
                    DateOfBirth = dateOfBirth.ToString("yyyy-MM-dd"),
                    Gender = gender,
                    VerificationType = "0",
                    AbilityToShare = "1"
                }
            });
            var response = learnerRegistrationResponse.RegisterLearnerResponse;

            if (!Enum.TryParse(response.ResponseCode, true, out LearnerRegistrationResponseCode parsedResponseCode))
            {
                throw new ArgumentException($"Value {response.ResponseCode} could not be parsed to {nameof(LearnerRegistrationResponseCode)}.", nameof(response.ResponseCode));
            }

            return new LearnerRegistrationResponse
            {
                ResponseCode = parsedResponseCode,
                Uln = response.ULN
            };
        }
    }
}