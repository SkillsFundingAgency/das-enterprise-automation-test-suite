using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.TransferMatching.UITests.Project.Helpers
{
    public class TMDataHelper : RandomElementHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public TMDataHelper(RandomDataGenerator randomDataGenerator) : base(randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
            
            var randomCourse = GetRandomElementFromListOfElements(Courses);
            Course = randomCourse.Course;
            Cost = randomCourse.Cost;
            NoOfApprentice = 1;
            CourseStartDate = DateTime.Now.AddMonths(2);
        }

        public string ApprenticeshipMoreDetails => _randomDataGenerator.GenerateRandomAlphabeticString(25);

        public int GenerateRandomNumberMoreThanMaxAmount(int max) => Func(max + 1, max * 2);

        public int GenerateRandomNumberLessThanMaxAmount(int max) => Func(1, max);

        public int GenerateRandomNumberMoreThanMinAmount(int max) => Func(MinAmount, max);

        public string GetRandomLocation() => GetRandomElementFromListOfElements(Locations);

        public string Course { get; }

        public int Cost { get; }

        public int NoOfApprentice { get; set; }

        public int MinAmount => Cost * NoOfApprentice;

        public DateTime CourseStartDate { get; set; } 

        public string GetRandomElementFromListOfElements(List<string> list) => base.GetRandomElementFromListOfElements(list);

        private int Func(int min, int max) => _randomDataGenerator.GenerateRandomNumberBetweenTwoValues(min, max);

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

        private List<(string Course, int Cost)> Courses => new List<(string,int)>()
        {
            ("Abattoir worker" ,1500),
            ("Software tester" ,3000),
            ("Software developer",3000)
        };
    }
}
