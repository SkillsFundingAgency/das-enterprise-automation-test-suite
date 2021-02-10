using System;
using SFA.DAS.Common.Domain.Types;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers.Requests
{
    public class IncentiveApplicationApprenticeshipDto
    {
        public long ApprenticeshipId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long ULN { get; set; }
        public DateTime PlannedStartDate { get; set; }
        public ApprenticeshipEmployerType ApprenticeshipEmployerTypeOnApproval { get; set; }
        public long? UKPRN { get; set; }
        public string CourseName { get; set; }
    }
}
