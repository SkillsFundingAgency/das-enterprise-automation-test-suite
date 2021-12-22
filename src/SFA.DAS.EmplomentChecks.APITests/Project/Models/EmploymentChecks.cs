using Dapper.Contrib.Extensions;
using System;


namespace SFA.DAS.EmploymentChecks.APITests.Project.Models
{
    [Table("EmploymentChecks")]
    public class EmploymentChecksDb
    {
        public long Id { get; set; }

        public long ULN { get; set; }

        public string NationalInsuranceNumber { get; set; }

        public long UKPRN { get; set; }

        public long ApprenticeshipId { get; set; }

        public long AccountId { get; set; }

        public DateTime MinDate { get; set; }

        public DateTime MaxDate { get; set; }

        public string CheckType { get; set; }

        public bool? IsEmployed { get; set; }

        public DateTime? LastUpdated { get; set; }

        public DateTime? CreatedDate { get; set; }

        public bool HasBeenChecked { get; set; }
    }
}
