using SFA.DAS.Common.Domain.Types;
using System;
using SFA.DAS.EmployerIncentives.PaymentProcessTests.Models;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Messages
{
    public class CreateIncentiveCommand(
        long accountId,
        long accountLegalEntityId, Guid incentiveApplicationApprenticeshipId, long apprenticeshipId,
        string firstName, string lastName, DateTime dateOfBirth, long uln, DateTime plannedStartDate,
        ApprenticeshipEmployerType apprenticeshipEmployerTypeOnApproval, long? ukprn, DateTime submittedDate,
        string submittedByEmail, string courseName, DateTime employmentStartDate, Phase phase)
    {
        public long AccountId { get; } = accountId;
        public long AccountLegalEntityId { get; } = accountLegalEntityId;
        public Guid IncentiveApplicationApprenticeshipId { get; } = incentiveApplicationApprenticeshipId;
        public long ApprenticeshipId { get; } = apprenticeshipId;
        public string FirstName { get; } = firstName;
        public string LastName { get; } = lastName;
        public DateTime DateOfBirth { get; } = dateOfBirth;
        public long Uln { get; } = uln;
        public DateTime PlannedStartDate { get; } = plannedStartDate;
        public ApprenticeshipEmployerType ApprenticeshipEmployerTypeOnApproval { get; } = apprenticeshipEmployerTypeOnApproval;
        public long? UKPRN { get; } = ukprn;
        public DateTime SubmittedDate { get; } = submittedDate;
        public string SubmittedByEmail { get; } = submittedByEmail;
        public string CourseName { get; } = courseName;
        public DateTime EmploymentStartDate { get; } = employmentStartDate;
        public Phase Phase { get; } = phase;
    }
}
