using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.RAA_V1.UITests.Project.Helpers
{
    public class FAADataHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public FAADataHelper(RandomDataGenerator randomDataGenerator)
        {
            var datetime = DateTime.Now;
            _randomDataGenerator = randomDataGenerator;
            EducationSchoolOrCollege = _randomDataGenerator.GenerateRandomAlphabeticString(10);
            YearsAttended = datetime.AddYears(-1);
            QualificationYear = YearsAttended.Year.ToString();
            QualificationSubject = _randomDataGenerator.GenerateRandomAlphabeticString(5);
            QualificationGrade = _randomDataGenerator.GenerateRandomAlphabeticString(1);
            WorkExperienceEmployer = _randomDataGenerator.GenerateRandomAlphabeticString(8);
            WorkExperienceJobTitle = _randomDataGenerator.GenerateRandomAlphabeticString(15);
            WorkExperienceMainDuties = _randomDataGenerator.GenerateRandomAlphabeticString(29);
            WorkExperienceFinished = YearsAttended.AddMonths(-5);
            WorkExperienceStarted = WorkExperienceFinished.AddMonths(-5);
            TrainingCoursesProvider = WorkExperienceEmployer;
            TrainingCoursesCourseTitle = QualificationSubject;
            TrainingCoursesTo = WorkExperienceFinished;
            TrainingCoursesFrom = WorkExperienceStarted;
            Strengths = _randomDataGenerator.GenerateRandomAlphabeticString(99);
            Skills = _randomDataGenerator.GenerateRandomAlphabeticString(99);
            HobbiesAndInterests = _randomDataGenerator.GenerateRandomAlphabeticString(99);
            AdditionalQuestions1 = _randomDataGenerator.GenerateRandomAlphabeticString(59);
            AdditionalQuestions2 = _randomDataGenerator.GenerateRandomAlphabeticString(59);
            InterviewSupport = _randomDataGenerator.GenerateRandomAlphabeticString(22);

        }

        public string EducationSchoolOrCollege { get; }

        public DateTime YearsAttended { get; }

        public string TypeOfQualification => "GCSE";

        public string QualificationYear { get; }

        public string QualificationSubject{ get; }

        public string QualificationGrade { get; }

        public string WorkExperienceEmployer { get; }

        public string WorkExperienceJobTitle { get; }

        public string WorkExperienceMainDuties { get; }

        public DateTime WorkExperienceStarted { get; }

        public DateTime WorkExperienceFinished { get; }

        public string TrainingCoursesProvider { get; }

        public string TrainingCoursesCourseTitle { get; }

        public DateTime TrainingCoursesFrom { get; }

        public DateTime TrainingCoursesTo { get; }

        public string Strengths { get; }

        public string Skills { get; }

        public string HobbiesAndInterests { get; }

        public string AdditionalQuestions1 { get; }

        public string AdditionalQuestions2 { get; }
        
        public string InterviewSupport { get; }
    }
}

