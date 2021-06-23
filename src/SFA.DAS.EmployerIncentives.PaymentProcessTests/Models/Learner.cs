using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Models
{
    [Dapper.Contrib.Extensions.Table("incentives.Learner")]
    [Table("Learner", Schema = "incentives")]
    public partial class Learner
    {
        [Dapper.Contrib.Extensions.ExplicitKey]
        public Guid Id { get; set; }
        public Guid ApprenticeshipIncentiveId { get; set; }
        public long ApprenticeshipId { get; set; }
        public long Ukprn { get; set; }
        public long ULN { get; set; }
        public bool SubmissionFound { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public bool? LearningFound { get; set; }
        public bool? HasDataLock { get; set; }
        public DateTime? StartDate { get; set; }
        public bool? InLearning { get; set; }
        public DateTime? LearningStoppedDate { get; set; }
        public DateTime? LearningResumedDate { get; set; }
        public bool SuccessfulLearnerMatch { get; set; }
        public string RawJSON { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [Dapper.Contrib.Extensions.Write(false)]
        public ICollection<LearningPeriod> LearningPeriods { get; set; }
        [Dapper.Contrib.Extensions.Write(false)]
        public ICollection<ApprenticeshipDaysInLearning> DaysInLearnings { get; set; }

        public Learner()
        {
            LearningPeriods = new List<LearningPeriod>();
            DaysInLearnings = new List<ApprenticeshipDaysInLearning>();
        }
    }
}
