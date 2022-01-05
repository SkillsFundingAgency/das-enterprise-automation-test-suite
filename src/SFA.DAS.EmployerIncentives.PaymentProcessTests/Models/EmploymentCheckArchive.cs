using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Models
{
    [Dapper.Contrib.Extensions.Table("archive.EmploymentCheck")]
    [Table("EmploymentCheck", Schema = "archive")]
    public partial class EmploymentCheckArchive
    {
        [Dapper.Contrib.Extensions.ExplicitKey]
        public Guid EmploymentCheckId { get; set; }
        public Guid ApprenticeshipIncentiveId { get; set; }
        public string CheckType { get; set; }
        public DateTime MinimumDate { get; set; }
        public DateTime MaximumDate { get; set; }
        public Guid CorrelationId { get; set; }
        public bool? Result { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
        public DateTime? ResultDateTime { get; set; }
        public DateTime ArchiveDateUTC { get; set; }
    }
}
