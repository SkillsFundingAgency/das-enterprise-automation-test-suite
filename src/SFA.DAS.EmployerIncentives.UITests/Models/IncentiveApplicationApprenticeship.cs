using System;
using System.ComponentModel.DataAnnotations.Schema;
using SFA.DAS.Common.Domain.Types;

namespace SFA.DAS.EmployerIncentives.UITests.Models
{
    /// <summary>
    /// Once this moves out of PoC stage, these types should be pulled from sfa.das.employerincentives
    /// </summary>
    [Dapper.Contrib.Extensions.Table("IncentiveApplicationApprenticeship")]
    [Table("IncentiveApplicationApprenticeship")]
    public partial class IncentiveApplicationApprenticeship
    {
        [Dapper.Contrib.Extensions.ExplicitKey]
        public Guid Id { get; set; }
        public Guid IncentiveApplicationId { get; set; }
        public long ApprenticeshipId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long ULN { get; set; }
        public DateTime PlannedStartDate { get; set; }
        public ApprenticeshipEmployerType ApprenticeshipEmployerTypeOnApproval { get; set; }
        public decimal TotalIncentiveAmount { get; set; }
        public long? UKPRN { get; set; }
        public bool EarningsCalculated { get; set; }
        public bool WithdrawnByEmployer { get; set; }
        public bool WithdrawnByCompliance { get; set; }
        public string CourseName { get; set; }
    }
}
