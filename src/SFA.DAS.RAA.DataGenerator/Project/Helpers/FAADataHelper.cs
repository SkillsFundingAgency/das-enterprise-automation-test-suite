using SFA.DAS.UI.FrameworkHelpers;
using System;

namespace SFA.DAS.RAA.DataGenerator
{
    public class FAADataHelper : RandomElementHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;

        public FAADataHelper(RandomDataGenerator randomDataGenerator) : base(randomDataGenerator)
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
            FirstName = _randomDataGenerator.GenerateRandomAlphabeticString(5);
            NewFirstName = _randomDataGenerator.GenerateRandomAlphabeticString(5);
            NewLastName = _randomDataGenerator.GenerateRandomAlphabeticString(5);            
            LastName = _randomDataGenerator.GenerateRandomAlphabeticString(10);
            DOB_Day = _randomDataGenerator.GenerateRandomDateOfMonth();
            DOB_Month = _randomDataGenerator.GenerateRandomMonth();
            DOB_Year = _randomDataGenerator.GenerateRandomDobYear();
            EmailId = _randomDataGenerator.GenerateRandomEmail();
            ChangedEmailId = _randomDataGenerator.GenerateRandomEmail();
            PhoneNumber = _randomDataGenerator.GenerateRandomNumber(10);
            NewPhoneNumber = _randomDataGenerator.GenerateRandomNumber(10);
            Password = _randomDataGenerator.GenerateRandomPassword(4, 4, 1, 1);
            VacancyClosing = DateTime.Today.AddMonths(2).AddDays(3);
            NewVacancyClosing = VacancyClosing.AddDays(15);
            NewVacancyStart = NewVacancyClosing.AddDays(15);
            OptionalMessage = _randomDataGenerator.GenerateRandomAlphabeticString(30);
        }

        public DateTime NewVacancyClosing { get; }

        public DateTime NewVacancyStart { get; }

        public DateTime VacancyClosing { get; }

        
        public string NewCustomMinWagePerWeek { get; set; }

        public string NewCustomMaxWagePerWeek { get; set; }

        public string EducationSchoolOrCollege { get; }

        public DateTime YearsAttended { get; }

        public string TypeOfQualification => "GCSE";

        public string QualificationYear { get; }

        public string QualificationSubject { get; }

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

        public string FirstName { get; }

        public string LastName { get; }
        public string NewFirstName { get; }

        public string NewLastName { get; }

        public string NewAddress { get; set; }

        public int DOB_Day { get; }

        public int DOB_Month { get; }

        public int DOB_Year { get; }

        public string EmailId { get; }

        public string ChangedEmailId { get; }

        public string PhoneNumber { get; }

        public string Password { get; }

        public string NewPhoneNumber { get; }

        public string PostCode => "1 Speedway Drive London SW17 0XW";

        public string NewPostCode => "NN5 4AB";

        public string ActivationCode => "ABC123";

        public string PhoneNumberVerificationText => "We've sent a verification code to your mobile number ";

        public string PhoneNumberVerificationCode => "1234";

        public string SuccessfulPhoneVerificationText => "You've successfully verified your mobile number";

        public string CreateAccountWithRegisteredEmailErrorMessage => "Your email address has already been activated. Please try signing in again. If you’ve forgotten your password you can reset it.";

        public string NationwideVacanciesText => "This apprenticeship has multiple positions across England.";        

        public string OptionalMessage { get; }
    }
}