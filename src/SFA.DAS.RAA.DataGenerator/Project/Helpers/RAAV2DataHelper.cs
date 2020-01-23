using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.RAA.DataGenerator
{
    public class RAAV2DataHelper : RandomElementHelper
    {
        private readonly RandomDataGenerator _randomDataGenerator;
        private readonly VacancyTitleDatahelper _vacancyTitleDatahelper;

        public RAAV2DataHelper(RandomDataGenerator randomDataGenerator, VacancyTitleDatahelper vacancyTitleDatahelper) : base(randomDataGenerator)
        {
            _randomDataGenerator = randomDataGenerator;
            _vacancyTitleDatahelper = vacancyTitleDatahelper;
            EmployerTradingName = $"{_randomDataGenerator.GenerateRandomAlphabeticString(10)}_EmployerName";
            EmployerDescription = $"{_randomDataGenerator.GenerateRandomAlphabeticString(10)}_EmployerDescription";
            EmployerReason = _randomDataGenerator.GenerateRandomAlphabeticString(10);
            EmployerWebsiteUrl = WebsiteUrl(EmployerTradingName);
            ContactName = _randomDataGenerator.GenerateRandomAlphabeticString(5);
            Email = $"{ContactName}@lorem.com";
            VacancyShortDescription = _randomDataGenerator.GenerateRandomAlphabeticString(15);
            VacancyOutcome = _randomDataGenerator.GenerateRandomAlphabeticString(22);
            VacancyBriefOverview = _randomDataGenerator.GenerateRandomAlphabeticString(50);
            TrainingDetails = _randomDataGenerator.GenerateRandomAlphabeticString(28);
            WorkkingWeek = _randomDataGenerator.GenerateRandomAlphabeticString(15);
            VacancyClosing = DateTime.Today.AddMonths(2).AddDays(3);
            VacancyStart = VacancyClosing.AddMonths(1).AddDays(1);
            EditedVacancyClosing = VacancyStart.AddMonths(2).AddDays(3);
            EditedVacancyStart = EditedVacancyClosing.AddMonths(1).AddDays(1);
            DesiredQualificationsSubject = _randomDataGenerator.GenerateRandomAlphabeticString(8);
            OptionalMessage = _randomDataGenerator.GenerateRandomAlphabeticString(30);
        }

        public string VacancyTitle => $"{_vacancyTitleDatahelper.VacancyTitle} apprenticeship";

        public string TrainingTitle => AvailableTraining.RandomOrDefault();

        public string EmployerAddress => AvailableAddress.RandomOrDefault();

        public string Provider => AvailableProviders.RandomOrDefault();

        public string EmployerTradingName { get; }

        public string EmployerDescription { get; }

        public string EmployerReason { get; }
        
        public string EmployerWebsiteUrl { get; }
        
        public string ContactName { get; }

        public string ContactNumber => "07777777777";

        public string Email { get; }

        public string VacancyShortDescription { get; }

        public string VacancyOutcome { get; }

        public string TrainingDetails { get; }

        public string Duration => "52";

        public string WorkkingWeek { get; }

        public string WeeklyHours => "40";

        public string FixedWageYearlyAmount => "10000";

        public string NationalMinimumWage => "£9,048 - £17,076.80";

        public string NationalMinimumWageForApprentices => "£8,112";

        public string FixedWageForApprentices => "£10,000";

        public DateTime EditedVacancyClosing { get; }

        public DateTime EditedVacancyStart { get; }

        public DateTime VacancyClosing { get; }

        public DateTime VacancyStart { get; }

        public string VacancyBriefOverview { get; }

        public string DesiredQualificationsSubject { get; }

        public string DesiredQualificationsGrade => "A Level";

        public string NumberOfVacancy => "2" ;

        public string OptionalMessage { get; }

        private string WebsiteUrl(string url) => $"https://www.{url}.com";

        private List<string> AvailableProviders => new List<string> { "BALTIC TRAINING SERVICES LIMITED 10019026" };

        private List<string> AvailableTraining => new List<string> 
        {
            "Aerospace Engineer (degree), Level 6 (Degree with honours)",
            "Agriculture: Agriculture, Level 3 (A level)",
            "Broadcast production assistant, Level 3 (A level)",
            "Construction Building: Maintenance Operations, Level 2 (GCSE)",
            "Event Assistant, Level 3 (A level)",
            "Financial services administrator, Level 3 (A level)",
            "Groundworker, Level 2 (GCSE)",
            "Healthcare support worker, Level 2 (GCSE)",
            "IT Solutions Technician, Level 3 (A level)",
            "Junior journalist, Level 3 (A level)",
            "Software Development Technician, Level 3 (A level)",
            "Software tester, Level 4 (Higher national certificate)",
            "Lifting Technician, Level 2 (GCSE)",
            "Legal Services: Property, Level 3 (A level)"
        };

        private List<string> AvailableAddress => new List<string>
        {"0","1", "2", "3", "4", "5", "6", "7", "8", "9"};
    }
}