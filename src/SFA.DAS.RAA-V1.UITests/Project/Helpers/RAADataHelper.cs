using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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



    public class RAADataHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;
        private readonly RegexHelper _regexHelper;

        public RAADataHelper(RandomDataGenerator randomDataGenerator, RegexHelper regexHelper)
        {
            var datetime = System.DateTime.Now;
            _randomDataGenerator = randomDataGenerator;
            _regexHelper = regexHelper;
            EmployerDescription = _randomDataGenerator.GenerateRandomAlphabeticString(10);
            EmployerReason = _randomDataGenerator.GenerateRandomAlphabeticString(10);
            EmployerBody = _randomDataGenerator.GenerateRandomAlphabeticString(25);
            EmployerWebsiteUrl = WebsiteUrl(EmployerDescription);
            VacancyTitle = $"{_randomDataGenerator.GenerateRandomAlphabeticString(10)}_{datetime.ToString("ddMMMyyyy_HHmmss")}";
            VacancyShortDescription = _randomDataGenerator.GenerateRandomAlphabeticString(15);
            VacancyDescription = _randomDataGenerator.GenerateRandomAlphabeticString(50);
            VacancyWebsiteUrl = WebsiteUrl(VacancyShortDescription);
            ApplicationProcess = _randomDataGenerator.GenerateRandomAlphabeticString(40);
            TrainingDetails = _randomDataGenerator.GenerateRandomAlphabeticString(28);
            TrainingContactName = _randomDataGenerator.GenerateRandomAlphabeticString(5);
            TrainingEmail = $"{TrainingContactName}@lorem.com";
            WorkkingWeek = _randomDataGenerator.GenerateRandomAlphabeticString(15);
            VacancyClosing = DateTime.Today.AddMonths(2).AddDays(3);
            VacancyStart = VacancyClosing.AddMonths(1).AddDays(1);
            DesiredSkills = _randomDataGenerator.GenerateRandomAlphabeticString(18);
            PersonalQualities = _randomDataGenerator.GenerateRandomAlphabeticString(20);
            DesiredQualifications = _randomDataGenerator.GenerateRandomAlphabeticString(24);
            FutureProspects = _randomDataGenerator.GenerateRandomAlphabeticString(30);
            ThingsToConsider = _randomDataGenerator.GenerateRandomAlphabeticString(35);
            FirstQuestion = _randomDataGenerator.GenerateRandomAlphabeticString(15);
            SecondQuestion = _randomDataGenerator.GenerateRandomAlphabeticString(15);
            AdditionalLocationInformation = _randomDataGenerator.GenerateRandomAlphabeticString(5);
        }

        public string EmployerErn { get; private set; }

        public IWebElement Employers(List<IWebElement> links)
        {
            var randomEmployerLink = _randomDataGenerator.GenerateRandomNumberBetweenTwoValues(0, links.Count - 1);

            var randomEmployer = links[randomEmployerLink];

            EmployerErn = _regexHelper.GetEmployerERN(randomEmployer.GetAttribute("href"));

            return randomEmployer;
        }

        public string EmployerDescription { get; }

        public string EmployerReason { get; }

        public string EmployerBody { get; }
        
        public string EmployerWebsiteUrl { get; }

        public string VacancyTitle { get; }

        public string VacancyShortDescription { get; }

        public string VacancyWebsiteUrl { get; }

        public string ApplicationProcess { get; }

        public string TrainingDetails { get; }

        public int RandomCourse => _randomDataGenerator.GenerateRandomNumberBetweenTwoValues(2, 20);

        public string TrainingContactName { get; }

        public string TrainingContactNumber => "07777777777";

        public string TrainingEmail { get; }

        public string WorkkingWeek { get; }

        public DateTime VacancyClosing { get; }

        public DateTime VacancyStart { get; }

        public string VacancyDescription { get; }

        public string DesiredSkills { get;}
        
        public string PersonalQualities { get; }
        
        public string DesiredQualifications { get; }
        
        public string FutureProspects { get; }
        
        public string ThingsToConsider { get; }

        public string SecondQuestion { get; }
        
        public string FirstQuestion { get; }

        public string AdditionalLocationInformation { get;}
        
        public string NumberOfVacancy => "2" ;

        private string WebsiteUrl(string url) => $"https://www.{url}.com";
    }
}

