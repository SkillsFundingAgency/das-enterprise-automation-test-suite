using NUnit.Framework;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class LearnerDataHelper(ScenarioContext context)
    {
        private readonly EISqlHelper _sqlHelper = context.Get<EISqlHelper>();

        public async Task VerifyLearningRecordsExist(long apprenticeshipId)
        {
            var exist = await _sqlHelper.VerifyLearningRecordsExist(apprenticeshipId);
            Assert.IsTrue(exist);
        }

        public async Task VerifyLearningRecordsDoNotExist(long apprenticeshipId)
        {
            var exist = await _sqlHelper.VerifyLearningRecordsExist(apprenticeshipId);
            Assert.IsFalse(exist);
        }

        public async Task VerifyPaymentRecordsExist(Guid apprenticeshipIncentiveId, bool paymentsSent = false)
        {
            var exist = await _sqlHelper.VerifyPaymentRecordsExist(apprenticeshipIncentiveId, paymentsSent);
            Assert.IsTrue(exist);
        }
    }
}
