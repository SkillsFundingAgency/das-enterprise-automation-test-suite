using System;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class CreateApprenticeship
    {
        public long AccountId { get; set; }
        public long ApprenticeshipId { get; set; }
        public string AgreedOn { get; set; }
        public string CreatedOn { get; set; }
        public string Email { get; set; }
        public string LegalEntityName { get; set; }
        public long AccountLegalEntityId { get; set; }
        public long ProviderId { get; set; }
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
