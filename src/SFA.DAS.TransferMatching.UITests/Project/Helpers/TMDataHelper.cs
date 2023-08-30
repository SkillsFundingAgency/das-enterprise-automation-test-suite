using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.TransferMatching.UITests.Project.Helpers
{
    public class TMDataHelper
    {
        public TMDataHelper(CourseDetails courseDetails)
        {
            Course = courseDetails.Course.title;
            Cost = courseDetails.Course.proposedMaxFunding;
            Duration = courseDetails.Course.proposedTypicalDuration;
            NoOfApprentice = 1;
            CourseStartDate = DateTime.Now;
        }

        public string ApprenticeshipMoreDetails => RandomDataGenerator.GenerateRandomAlphabeticString(25);

        public int GenerateRandomNumberMoreThanMaxAmount(int max) => Func(max + 1, max * 2);

        public int GenerateRandomNumberLessThanMaxAmount(int max) => Func(1, max);

        public int GenerateRandomNumberMoreThanMinAmount(int max) => Func(MinAmount, max);

        public string GetRandomLocation() => RandomDataGenerator.GetRandomElementFromListOfElements(Locations);

        public string Course { get; }

        public int Cost { get; set; }

        public int NoOfApprentice { get; set; }

        public int Duration { get; set; }

        public int MinAmount => Cost * NoOfApprentice;
        
        public int MinimalPledgeAmount => Cost * (NoOfApprentice + 1);

        public DateTime CourseStartDate { get; set; }

        private static int Func(int min, int max) => RandomDataGenerator.GenerateRandomNumberBetweenTwoValues(min, max);

        private List<string> Locations => new List<string>()
        {
            "Coventry, West Midlands",
            "Greater London, Berkshire",
            "Grays, Essex",
            "Manchester, Greater Manchester",
            "Sheffield, South Yorkshire",
            "Hatfield, Hertfordshire",
            "Sutton, Greater London",
            "Cheam, Greater London",
            "Worcester, Worcestershire"
        };

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

