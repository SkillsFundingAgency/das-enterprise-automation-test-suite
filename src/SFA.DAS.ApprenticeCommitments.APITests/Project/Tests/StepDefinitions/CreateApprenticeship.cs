using System;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project.Tests.StepDefinitions
{
    public class CreateApprenticeship
    {
        public long EmployerAccountId { get; set; }
        public long ApprenticeshipId { get; set; }
        public string Email => $"CreateApprenticeship{DateTime.Now:ddMMMyyyy_HHmmss}@mailinator.com";
        public string Organisation { get; set; }
    }
}
