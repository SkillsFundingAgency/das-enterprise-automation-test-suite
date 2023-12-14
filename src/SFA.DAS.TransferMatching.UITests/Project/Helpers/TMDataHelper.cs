using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.TransferMatching.UITests.Project.Helpers
{
    public class TMDataHelper(CourseDetails courseDetails)
    {
        public static string ApprenticeshipMoreDetails => RandomDataGenerator.GenerateRandomAlphabeticString(25);

        public static int GenerateRandomNumberMoreThanMaxAmount(int max) => Func(max + 1, max * 2);

        public static int GenerateRandomNumberLessThanMaxAmount(int max) => Func(1, max);

        public int GenerateRandomNumberMoreThanMinAmount(int max) => Func(MinAmount, max);

        public static string GetRandomLocation() => RandomDataGenerator.GetRandomElementFromListOfElements(Locations);

        public string Course { get; } = courseDetails.Course.title;

        public int Cost { get; set; } = courseDetails.Course.proposedMaxFunding;

        public int NoOfApprentice { get; set; } = 1;

        public int Duration { get; set; } = courseDetails.Course.proposedTypicalDuration;

        public int MinAmount => Cost * NoOfApprentice;
        
        public int MinimalPledgeAmount => Cost * (NoOfApprentice + 1);

        public DateTime CourseStartDate { get; set; } = DateTime.Now;

        private static int Func(int min, int max) => RandomDataGenerator.GenerateRandomNumberBetweenTwoValues(min, max);

        private static List<string> Locations =>
        [
            "Coventry, West Midlands",
            "Greater London, Berkshire",
            "Grays, Essex",
            "Manchester, Greater Manchester",
            "Sheffield, South Yorkshire",
            "Hatfield, Hertfordshire",
            "Sutton, Greater London",
            "Cheam, Greater London",
            "Worcester, Worcestershire"
        ];

        public string GetEstimatedCostOfTrainingForApplicationDetail()
        {
            var totalCost = Cost * NoOfApprentice;

            if (Duration <= 12)
            {
                return totalCost.ToString("N0");
            }

            var firstYear = (totalCost * 0.8) / Duration * 12;
            return firstYear.ToString("N0");
        }
    }
}

