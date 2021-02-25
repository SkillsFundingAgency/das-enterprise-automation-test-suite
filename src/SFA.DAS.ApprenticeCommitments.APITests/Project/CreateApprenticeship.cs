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

    public class VerifyIdentityRegistrationCommand
    {
        public string RegistrationId { get; set; }
        public string UserIdentityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string NationalInsuranceNumber { get; set; }
    }
}
