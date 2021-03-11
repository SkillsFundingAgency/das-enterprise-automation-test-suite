using System;
using System.Collections.Generic;

namespace SFA.DAS.EmployerIncentives.UITests.Models
{
    public class LearnerSubmissionDto
    {
        public DateTime StartDate { get; set; }
        public DateTime IlrSubmissionDate { get; set; }
        public int IlrSubmissionWindowPeriod { get; set; }
        public int AcademicYear { get; set; }
        public long Ukprn { get; set; }
        public long Uln { get; set; }
        public string RawJson { get; set; }

        public IList<TrainingDto> Training { get; set; }
    }
}
