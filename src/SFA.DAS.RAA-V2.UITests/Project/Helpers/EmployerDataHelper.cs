using OpenQA.Selenium;
using SFA.DAS.FAA.UITests.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SFA.DAS.RAA_V2.UITests.Project.Helpers
{
    public class EmployerDataHelper : RandomElementHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;
        private readonly VacancyTitleDatahelper _vacancyTitleDatahelper;

        public EmployerDataHelper(RandomDataGenerator randomDataGenerator, VacancyTitleDatahelper vacancyTitleDatahelper) : base(randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
            _vacancyTitleDatahelper = vacancyTitleDatahelper;
            EmployerDescription = _randomDataGenerator.GenerateRandomAlphabeticString(10);
            EmployerReason = _randomDataGenerator.GenerateRandomAlphabeticString(10);
            EmployerBody = _randomDataGenerator.GenerateRandomAlphabeticString(25);
            EmployerWebsiteUrl = WebsiteUrl(EmployerDescription);
            VacancyShortDescription = _randomDataGenerator.GenerateRandomAlphabeticString(15);
            VacancyOutcome = _randomDataGenerator.GenerateRandomAlphabeticString(22);
            VacancyBriefOverview = _randomDataGenerator.GenerateRandomAlphabeticString(50);
            VacancyWebsiteUrl = WebsiteUrl(VacancyShortDescription);
            ApplicationProcess = _randomDataGenerator.GenerateRandomAlphabeticString(40);
            TrainingDetails = _randomDataGenerator.GenerateRandomAlphabeticString(28);
            TrainingContactName = _randomDataGenerator.GenerateRandomAlphabeticString(5);
            TrainingEmail = $"{TrainingContactName}@lorem.com";
            WorkkingWeek = _randomDataGenerator.GenerateRandomAlphabeticString(15);
            FixedWagePerWeek = _randomDataGenerator.GenerateRandomNumberBetweenTwoValues(300, 350).ToString();
            CustomMinWagePerWeek = FixedWagePerWeek;
            CustomMaxWagePerWeek = (int.Parse(FixedWagePerWeek) + _randomDataGenerator.GenerateRandomNumberBetweenTwoValues(50, 100)).ToString();
            VacancyClosing = DateTime.Today.AddMonths(2).AddDays(3);
            VacancyStart = VacancyClosing.AddMonths(1).AddDays(1);
            DesiredSkills = _randomDataGenerator.GenerateRandomAlphabeticString(18);
            PersonalQualities = _randomDataGenerator.GenerateRandomAlphabeticString(20);
            DesiredQualificationsSubject = _randomDataGenerator.GenerateRandomAlphabeticString(8);
            FutureProspects = _randomDataGenerator.GenerateRandomAlphabeticString(30);
            ThingsToConsider = _randomDataGenerator.GenerateRandomAlphabeticString(35);
            FirstQuestion = _randomDataGenerator.GenerateRandomAlphabeticString(15);
            SecondQuestion = _randomDataGenerator.GenerateRandomAlphabeticString(15);
            AdditionalLocationInformation = _randomDataGenerator.GenerateRandomAlphabeticString(5);
            ShareApplicationEmail = $"{TrainingContactName}@gmail.com";
            OptionalMessage = _randomDataGenerator.GenerateRandomAlphabeticString(30);
        }

        public string VacancyTitle => $"{_vacancyTitleDatahelper.VacancyTitle} apprenticeship";

        public string TrainingTitle => AvailableTraining.RandomOrDefault();

        public string EmployerDescription { get; }

        public string EmployerReason { get; }

        public string EmployerBody { get; }
        
        public string EmployerWebsiteUrl { get; }

        public string VacancyShortDescription { get; }

        public string VacancyOutcome { get; }

        public string VacancyWebsiteUrl { get; }

        public string ApplicationProcess { get; }

        public string TrainingDetails { get; }

        public int RandomNumber => _randomDataGenerator.GenerateRandomNumberBetweenTwoValues(2, 20);

        public string TrainingContactName { get; }

        public string TrainingContactNumber => "07777777777";

        public string TrainingEmail { get; }

        public string WorkkingWeek { get; }

        public string FixedWagePerWeek { get; }

        public string CustomMinWagePerWeek { get; }

        public string CustomMaxWagePerWeek { get; }

        public DateTime VacancyClosing { get; }

        public DateTime VacancyStart { get; }

        public string VacancyBriefOverview { get; }

        public string DesiredSkills { get;}
        
        public string PersonalQualities { get; }
        
        public string DesiredQualificationsSubject { get; }

        public string DesiredQualificationsGrade => "A Level";

        public string FutureProspects { get; }
        
        public string ThingsToConsider { get; }

        public string SecondQuestion { get; }
        
        public string FirstQuestion { get; }

        public string AdditionalLocationInformation { get;}
        
        public string NumberOfVacancy => "2" ;

        public string ShareApplicationEmail { get; }

        public string OptionalMessage { get; }

        private string WebsiteUrl(string url) => $"https://www.{url}.com";


        private List<string> AvailableTraining => new List<string> 
        { 
            "Agriculture: Agriculture, Level 3 (A level)",
            "Construction Building: Maintenance Operations, Level 2 (GCSE)",
            "Business to Business Sales Professional (degree), Level 6 (Degree with honours)",
            "Aerospace engineer, Level 6 (Degree with honours)",
            "Software Development Technician, Level 3 (A level)",
            "Software tester, Level 4 (Higher national certificate)",
            "Lifting Technician, Level 2 (GCSE)",
            "Legal Services: Property, Level 3 (A level)"
        };
    }
}