using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Models
{
    [Dapper.Contrib.Extensions.Table("incentives.EmploymentCheck")]
    [Table("EmploymentCheck", Schema = "incentives")]
    public partial class EmploymentCheck
    {
        [Dapper.Contrib.Extensions.ExplicitKey]
        public Guid Id { get; set; }
        public Guid ApprenticeshipIncentiveId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public EmploymentCheckType CheckType { get; set; }
        public DateTime MinimumDate { get; set; }
        public DateTime MaximumDate { get; set; }
        public Guid CorrelationId { get; set; }
        public bool? Result { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public DateTime? ResultDateTime { get; set; }
    }
}
