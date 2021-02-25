using System;
using System.Collections.Generic;

namespace SFA.DAS.EmployerIncentives.UITests.Models
{
    public class PriceEpisodeDto
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<PeriodDto> Periods { get; set; }
    }
}
