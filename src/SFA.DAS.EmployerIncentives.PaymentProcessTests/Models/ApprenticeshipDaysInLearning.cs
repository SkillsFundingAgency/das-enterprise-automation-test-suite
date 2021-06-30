using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Models
{
    [Dapper.Contrib.Extensions.Table("incentives.ApprenticeshipDaysInLearning")]
    [Table("ApprenticeshipDaysInLearning", Schema = "incentives")]
    public partial class ApprenticeshipDaysInLearning
    {
        [Dapper.Contrib.Extensions.ExplicitKey]
        public Guid LearnerId { get; set; }
        public int NumberOfDaysInLearning { get; set; }
        public byte CollectionPeriodNumber { get; set; }
        public short CollectionPeriodYear { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
