using System;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class CreateApprenticeship
    {
        public long EmployerAccountId { get; set; }
        public long ApprenticeshipId { get; set; }
        public string Email { get; set; }
        public string Organisation { get; set; }
    }
}
