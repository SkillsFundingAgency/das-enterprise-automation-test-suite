using System;

namespace SFA.DAS.ProvideFeedback.UITests.Project.Helpers
{
    public class AcademicYearHelper
    {
        public string GetCurrentAcademicYear()
        {
            var now = DateTime.UtcNow;
            var year = now.Year;

            if (now.Month < 8)
            {
                year--;
            }

            var startYear = (year % 100).ToString("D2");
            var endYear = ((year + 1) % 100).ToString("D2");

            return $"AY{startYear}{endYear}";
        }

        public string GetPreviousAcademicYear()
        {
            var now = DateTime.UtcNow.AddYears(-1);
            var year = now.Year;

            if (now.Month < 8)
            {
                year--;
            }

            var startYear = (year % 100).ToString("D2");
            var endYear = ((year + 1) % 100).ToString("D2");

            return $"AY{startYear}{endYear}";
        }
    }
}
