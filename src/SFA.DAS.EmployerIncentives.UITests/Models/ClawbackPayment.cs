using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SFA.DAS.EmployerIncentives.UITests.Models
{
    [Dapper.Contrib.Extensions.Table("incentives.ClawbackPayment")]
    [Table("ClawbackPayment", Schema = "incentives")]
    public partial class ClawbackPayment
    {
        [Dapper.Contrib.Extensions.ExplicitKey]
        public Guid Id { get; set; }
        public Guid ApprenticeshipIncentiveId { get; set; }
        public Guid PendingPaymentId { get; set; }
        public long AccountId { get; set; }
        public long AccountLegalEntityId { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateClawbackCreated { get; set; }
        public DateTime? DateClawbackSent { get; set; }
        public byte? CollectionPeriod { get; set; }
        public short? CollectionPeriodYear { get; set; }
        public SubnominalCode SubnominalCode { get; set; }
        public Guid PaymentId { get; set; }
    }
}
