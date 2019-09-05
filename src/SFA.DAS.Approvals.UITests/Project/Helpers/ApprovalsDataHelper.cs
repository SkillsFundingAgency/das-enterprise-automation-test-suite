using System;
using System.Collections.Generic;
using System.Text;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public class ApprovalsDataHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;
        private readonly ObjectContext _objectContext;

        public ApprovalsDataHelper(ObjectContext objectContext, RandomDataGenerator randomDataGenerator)
        {
            _objectContext = objectContext;
            _randomDataGenerator = randomDataGenerator;
            RandomNumber = _randomDataGenerator.GenerateRandomNumberBetweenTwoValues(1, 10);
            ApprenticeFirstname = _randomDataGenerator.GenerateRandomAlphabeticString(10);
            ApprenticeLastname = _randomDataGenerator.GenerateRandomAlphabeticString(10);
            DateOfBirthDay = _randomDataGenerator.GenerateRandomDateOfMonth();
            DateOfBirthMonth = _randomDataGenerator.GenerateRandomMonth();
            DateOfBirthYear = _randomDataGenerator.GenerateRandomDobYear();
            CourseStartDate = GenerateCourseStartDate();
            CourseEndDate = GetCourseEndDate();
            TrainingPrice = "1" + _randomDataGenerator.GenerateRandomNumber(3);
            EmployerReference = _randomDataGenerator.GenerateRandomAlphanumericString(10);
        }

        public string ApprenticeFirstname { get; }

        public string ApprenticeLastname { get; }

        public int DateOfBirthDay { get; }

        public int DateOfBirthMonth { get; }

        public int DateOfBirthYear { get; }

        public string StandardCourseOption => "34";

        public string FrameworkCourseOption => "454-3-1";

        public int CourseDurationInMonths => 15;

        public DateTime CourseStartDate { get; }

        public DateTime CourseEndDate { get; }

        public string TrainingPrice { get; }

        public string EmployerReference { get; }

        public string MessageToProvider => $"Apprentice Total Cost {_objectContext.GetApprenticeTotalCost()}, {_randomDataGenerator.GenerateRandomAlphanumericString(20)}";

        public string MessageToEmployer => $"Added ulns, {MessageToProvider}";

        public int RandomNumber { get; }

        public string Uln => _randomDataGenerator.GenerateRandomUln();

        private DateTime GenerateCourseStartDate()
        {
            DateTime start = GetCurrentAcademicYearStartDate();
            DateTime end = (RandomNumber % 2 == 0) ? GetNextAcademicYearEndDate() : DateTime.Now;
            int range = (end - start).Days;
            return start.AddDays(new Random().Next(range));
        }

        private DateTime GetCurrentAcademicYearStartDate()
        {
            var now = DateTime.Now;
            var cutoff = new DateTime(now.Year, 8, 1);
            return now >= cutoff ? cutoff : new DateTime(now.Year - 1, 8, 1);
        }

        private DateTime GetNextAcademicYearEndDate()
        {
            var date = GetCurrentAcademicYearStartDate();
            if ((date.Year).Equals(DateTime.Now.Year))
                return new DateTime(date.Year + 1, 7, 31);
            else
                return new DateTime(date.Year + 2, 7, 31);
        }
        private DateTime GetCourseEndDate()
        {
            return CourseStartDate.AddMonths(CourseDurationInMonths);
        }

        public string RandomCourse()
        {
            return (RandomNumber % 2 == 0) ? StandardCourseOption : FrameworkCourseOption;
        }
    }
}
