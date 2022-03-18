using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.TransferMatching.UITests.Project.Helpers
{
    public class TMDataHelper
    {
        public TMDataHelper()
        {
            var randomCourse = RandomDataGenerator.GetRandomElementFromListOfElements(Courses);
            Course = randomCourse.Course;
            Cost = randomCourse.Cost;
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

        public int MinAmount => Cost * NoOfApprentice;

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

        private List<(string Course, int Cost)> Courses => new List<(string, int)>()
        {
            ("Abattoir worker" ,1500),
            ("Software tester" ,3000),
            ("Software developer",3000)
        };
    }

}

