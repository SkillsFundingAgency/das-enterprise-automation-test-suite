using System;

namespace SFA.DAS.ApprenticeCommitments.APITests.Project
{
    public class ApprovalsCreated
    {
        public long EmployerAccountId { get; set; }
        public long CommitmentsApprenticeshipId { get; set; }
        public string CommitmentsApprovedOn { get; set; }
        public string Email { get; set; }
        public string EmployerName { get; set; }
        public long EmployerAccountLegalEntityId { get; set; }
        public long TrainingProviderId { get; set; }
    }

    public class CreateApprenticeshipViaCommitmentsJob
    {
        public long AccountId { get; set; }
        public long ApprenticeshipId { get; set; }
        public string CreatedOn { get; set; }
        public string Email { get; set; }
        public string LegalEntityName { get; set; }
        public long AccountLegalEntityId { get; set; }
        public long ProviderId { get; set; }
    }

    public class Apprentice
    {
        public Guid ApprenticeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class CreateApprenticeshipFromRegistration
    {
        public string RegistrationId { get; set; }
        public string ApprenticeId { get; set; }
    }
}
