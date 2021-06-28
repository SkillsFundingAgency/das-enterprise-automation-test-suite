using System;
using System.Collections.Generic;

namespace SFA.DAS.EmployerIncentives.PaymentProcessTests.Models
{
    public class PriceEpisodeDto
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<PeriodDto> Periods { get; set; }
        public string Identifier => $"25-91-15/{StartDate.Month}/{StartDate.Year}";
    }
}
