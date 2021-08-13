using System;
using System.Collections.Generic;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Models
{
    public class PriceEpisodeDto
    {
        public string AcademicYear { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<PeriodDto> Periods { get; set; }
    }
}
