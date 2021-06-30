using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Models
{
    [Dapper.Contrib.Extensions.Table("incentives.ChangeOfCircumstance")]
    [Table("ChangeOfCircumstance", Schema = "incentives")]
    public partial class ChangeOfCircumstance
    {
        [Dapper.Contrib.Extensions.ExplicitKey]
        public Guid Id { get; set; }
        public Guid ApprenticeshipIncentiveId { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        public ChangeOfCircumstanceType ChangeType { get; set; }
        public string PreviousValue { get; set; }
        public string NewValue { get; set; }
        public DateTime ChangedDate { get; set; }
    }
    public enum ChangeOfCircumstanceType : byte
    {
        StartDate = 1,
        LearningStopped = 2,
        LearningResumed = 3
    }
}
