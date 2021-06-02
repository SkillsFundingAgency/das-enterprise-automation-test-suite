using System;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class CreateApprenticeship
    {
        public long EmployerAccountId { get; set; }
        public long ApprenticeshipId { get; set; }
        public string Email { get; set; }
        public string EmployerName { get; set; }
        public long EmployerAccountLegalEntityId { get; set; }
        public long TrainingProviderId { get; set; }
        public string TrainingProviderName { get; set; }
        public string Course { get; set; }
    }

    public class VerifyIdentityRegistrationCommand
    {
        public string ApprenticeId { get; set; }
        public string UserIdentityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class ApprenticeEmailAddressRequest
    {
        public string Email { get; set; }
    }
}
