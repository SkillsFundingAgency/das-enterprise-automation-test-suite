using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Models
{
    [Dapper.Contrib.Extensions.Table("incentives.LearningPeriod")]
    [Table("LearningPeriod", Schema = "incentives")]
    public partial class LearningPeriod
    {
        [Dapper.Contrib.Extensions.ExplicitKey]
        public Guid LearnerId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
