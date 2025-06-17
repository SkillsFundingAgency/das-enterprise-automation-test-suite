using System;
using System.Collections.Generic;

namespace SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers
{
    public static class AvailableCourses
    {
        internal static List<CourseDetails> GetAvailableCourses()
            => [SoftwareTester, SoftwareDeveloper, AbattoirWorker, SoftwareDevelopmentTechnician, FoodIndustryTechnologist];

        private static CourseDetails SoftwareTester => new()
        {
            Course = ("91", "Software tester", new DateTime(2016, 04, 21), 24, 18000)
        };

        private static CourseDetails SoftwareDeveloper => new()
        {
            Course = ("2", "Software developer", new DateTime(2021, 06, 01), 24, 18000)
        };

        private static CourseDetails AbattoirWorker => new()
        {
            Course = ("274", "Abattoir worker", new DateTime(2018, 05, 08), 16, 6000)
        };

        private static CourseDetails SoftwareDevelopmentTechnician => new()
        {
            Course = ("154", "Software development technician", new DateTime(2022, 05, 16), 18, 15000)
        };

        private static CourseDetails FoodIndustryTechnologist => new()
        {
            Course = ("131", "Food industry technologist", new DateTime(2024, 05, 01), 24, 18000)
        };
    }
}