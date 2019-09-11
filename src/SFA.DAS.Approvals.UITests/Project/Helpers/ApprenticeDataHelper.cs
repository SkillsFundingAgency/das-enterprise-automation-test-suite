using System;
using System.Collections.Generic;
using System.Text;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Helpers
{
    public class ApprenticeDataHelper : RandomCourseHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;
        private readonly ObjectContext _objectContext;
        private readonly DateTime _currentAcademicYearStartDate;
        private readonly bool _isLiveApprentice;

        public ApprenticeDataHelper(ObjectContext objectContext, RandomDataGenerator randomDataGenerator, bool isLiveApprentice)
        {
            _objectContext = objectContext;
            _randomDataGenerator = randomDataGenerator;
            _isLiveApprentice = isLiveApprentice;
            RandomNumber = _randomDataGenerator.GenerateRandomNumberBetweenTwoValues(1, 10);
            ApprenticeFirstname = _randomDataGenerator.GenerateRandomAlphabeticString(10);
            ApprenticeLastname = _randomDataGenerator.GenerateRandomAlphabeticString(10);
            DateOfBirthDay = _randomDataGenerator.GenerateRandomDateOfMonth();
            DateOfBirthMonth = _randomDataGenerator.GenerateRandomMonth();
            DateOfBirthYear = _randomDataGenerator.GenerateRandomDobYear();
            _currentAcademicYearStartDate = GetCurrentAcademicYearStartDate();
            CourseStartDate = GenerateCourseStartDate();
            CourseEndDate = GetCourseEndDate();
            TrainingPrice = "1" + _randomDataGenerator.GenerateRandomNumber(3);
            EmployerReference = _randomDataGenerator.GenerateRandomAlphanumericString(10);
            Ulns = new List<string>();
            Course = RandomCourse();
        }

        public string ApprenticeFirstname { get; }      

        public string ApprenticeLastname { get; }

        public string ApprenticeFullName => $"{ApprenticeFirstname} {ApprenticeLastname}";

        public int DateOfBirthDay { get; }

        public int DateOfBirthMonth { get; }

        public int DateOfBirthYear { get; }

        public int CourseDurationInMonths => 15;

        public DateTime CourseStartDate { get; }

        public DateTime CourseEndDate { get; }

        public string TrainingPrice { get; }

        public string EmployerReference { get; }

        public string MessageToProvider => $"Apprentice Total Cost {_objectContext.GetApprenticeTotalCost()}, {_randomDataGenerator.GenerateRandomAlphanumericString(20)}";

        public string MessageToEmployer => $"Added ulns, {MessageToProvider}";

        public List<string> Ulns { get; private set; }

        public string Uln()
        {
            var uln = _randomDataGenerator.GenerateRandomUln();
            Ulns.Add(uln);
            return uln;
        }

        public string Course { get; }

        private DateTime GenerateCourseStartDate()
        {
            DateTime start = _currentAcademicYearStartDate;
            DateTime end = (RandomNumber % 2 == 0) ? GetNextAcademicYearEndDate() : DateTime.Now;
            int range = (end - start).Days;
            var randomStartDate = start.AddDays(new Random().Next(range));
            return _isLiveApprentice && randomStartDate.Date > DateTime.Now.Date ? _currentAcademicYearStartDate : randomStartDate;
        }

        private DateTime GetNextAcademicYearEndDate()
        {
            var date = _currentAcademicYearStartDate;
            if ((date.Year).Equals(DateTime.Now.Year))
                return new DateTime(date.Year + 1, 7, 31);
            else
                return new DateTime(date.Year + 2, 7, 31);
        }

        private DateTime GetCourseEndDate()
        {
            return CourseStartDate.AddMonths(CourseDurationInMonths);
        }

        private DateTime GetCurrentAcademicYearStartDate()
        {
            var now = DateTime.Now;
            var cutoff = new DateTime(now.Year, 8, 1);
            return now >= cutoff ? cutoff : new DateTime(now.Year - 1, 8, 1);
        }
    }
}
