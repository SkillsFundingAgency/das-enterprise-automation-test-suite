using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Models
{
    /// <summary>
    /// Once this moves out of PoC stage, these types should be pulled from sfa.das.employerincentives
    /// </summary>
    [Dapper.Contrib.Extensions.Table("IncentiveApplication")]
    [Table("IncentiveApplication")]
    public partial class IncentiveApplication
    {
        public IncentiveApplication()
        {
            Apprenticeships = new List<IncentiveApplicationApprenticeship>();
        }
        [Dapper.Contrib.Extensions.ExplicitKey]
        public Guid Id { get; set; }
        public long AccountId { get; set; }
        public long AccountLegalEntityId { get; set; }
        public DateTime DateCreated { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public IncentiveApplicationStatus Status { get; set; }
        public DateTime? DateSubmitted { get; set; }
        public string SubmittedByEmail { get; set; }
        public string SubmittedByName { get; set; }
        [Dapper.Contrib.Extensions.Write(false)]
        public IList<IncentiveApplicationApprenticeship> Apprenticeships { get; set; }
    }
}
