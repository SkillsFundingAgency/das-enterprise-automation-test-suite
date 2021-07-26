using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class LearnerDataHelper
    {
        private readonly EISqlHelper _sqlHelper;

        public LearnerDataHelper(ScenarioContext context)
        {
            _sqlHelper = context.Get<EISqlHelper>();
        }

        public async Task VerifyLearningRecordsExist(Guid apprenticeshipIncentiveId)
        {
            var exist = await _sqlHelper.VerifyLearningRecordsExist(apprenticeshipIncentiveId);
            Assert.IsTrue(exist);
        }

        public async Task VerifyPaymentRecordsExist(Guid apprenticeshipIncentiveId)
        {
            var exist = await _sqlHelper.VerifyPaymentRecordsExist(apprenticeshipIncentiveId);
            Assert.IsTrue(exist);
        }
    }
}
