using SFA.DAS.EmployerIncentives.PaymentProcessTests.Messages;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class IncentiveApplicationHelper
    {
        private readonly EISqlHelper _sqlHelper;
        private readonly StopWatchHelper _stopWatchHelper;
        private readonly EIFunctionsHelper _eiFunctionsHelper;
        private readonly EIServiceBusHelper _eIServiceBusHelper;
        private readonly TestData _testData;

        public IncentiveApplicationHelper(ScenarioContext context)
        {
            _sqlHelper = context.Get<EISqlHelper>();
            _stopWatchHelper = context.Get<StopWatchHelper>();
            _eiFunctionsHelper = context.Get<EIFunctionsHelper>();
            _eIServiceBusHelper = context.Get<EIServiceBusHelper>();
            _testData = context.Get<TestData>();
        }

        public async Task Submit(IncentiveApplication application, int signedAgreementVersion = 6)
        {
            _stopWatchHelper.Start("SubmitIncentiveApplication");
            await _sqlHelper.CreateAccount(application.AccountId, application.AccountLegalEntityId, signedAgreementVersion);
            await _sqlHelper.CreateIncentiveApplication(application);
            //await _eiFunctionsHelper.TriggerEarningsResilienceCheck();

            foreach (var apprenticeship in application.Apprenticeships)
            {
                await _sqlHelper.CreateEarnings(application, apprenticeship);
                _testData.ApprenticeshipIncentiveId = await _sqlHelper.GetApprenticeshipIncentiveIdWhenExists(apprenticeship.Id, TimeSpan.FromMinutes(2));
                _testData.IncentiveIds.Add(_testData.ApprenticeshipIncentiveId);
                await _sqlHelper.WaitUntilEarningsExist(_testData.ApprenticeshipIncentiveId, TimeSpan.FromMinutes(1));
            }
            _stopWatchHelper.Stop("SubmitIncentiveApplication");
        }

        public async Task Delete(IncentiveApplication application)
        {
            _stopWatchHelper.Start("DeleteApplicationData");
            await _sqlHelper.DeleteApplicationData(application.Id);
            _stopWatchHelper.Stop("DeleteApplicationData");
        }

        public async Task DeleteAccount((long AccountId, long AccountLegalEntityId) account)
        {
            _stopWatchHelper.Start("DeleteAccount");
            await _sqlHelper.DeleteAccount(account);
            _stopWatchHelper.Stop("DeleteAccount");
        }
    }
}
