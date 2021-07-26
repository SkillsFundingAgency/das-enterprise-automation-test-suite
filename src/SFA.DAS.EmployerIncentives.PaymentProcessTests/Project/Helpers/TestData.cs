using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;
using System;
using System.Collections.Generic;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Project.Helpers
{
    public class TestData
    {
        public long AccountId { get; set; }
        public long ApprenticeshipId { get; set; }
        public long UKPRN { get; set; }
        public long ULN { get; set; }
        public IList<Guid> IncentiveIds { get; set; }
        public Guid ApprenticeshipIncentiveId { get; set; }
        public IncentiveApplication IncentiveApplication { get; set; }

        public TestData()
        {
            IncentiveIds = new List<Guid>();
        }
    }
}
