using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Models
{
    [Dapper.Contrib.Extensions.Table("incentives.ApprenticeshipBreakInLearning")]
    [Table("ApprenticeshipBreakInLearning", Schema = "incentives")]
    public partial class ApprenticeshipBreakInLearning
    {
        [Dapper.Contrib.Extensions.ExplicitKey]
        public Guid ApprenticeshipIncentiveId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
