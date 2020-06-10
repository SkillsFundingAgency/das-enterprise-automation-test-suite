using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.RAA.DataGenerator
{
    public class RAAV2DataHelper : RandomElementHelper
    {
        private readonly VacancyTitleDatahelper _vacancyTitleDatahelper;

        public RAAV2DataHelper(RandomDataGenerator randomDataGenerator, VacancyTitleDatahelper vacancyTitleDatahelper) : base(randomDataGenerator)
        {
            _vacancyTitleDatahelper = vacancyTitleDatahelper;
            EmployerTradingName = $"{randomDataGenerator.GenerateRandomAlphabeticString(10)}_EmployerName";
            EmployerDescription = $"{randomDataGenerator.GenerateRandomAlphabeticString(10)}_EmployerDescription";
            EmployerReason = randomDataGenerator.GenerateRandomAlphabeticString(10);
            EmployerWebsiteUrl = WebsiteUrl(EmployerTradingName);
            ContactName = randomDataGenerator.GenerateRandomAlphabeticString(5);
            Email = $"{ContactName}@lorem.com";
            VacancyShortDescription = randomDataGenerator.GenerateRandomAlphabeticString(15);
            VacancyOutcome = randomDataGenerator.GenerateRandomAlphabeticString(22);
            VacancyBriefOverview = randomDataGenerator.GenerateRandomAlphabeticString(50);
            TrainingDetails = randomDataGenerator.GenerateRandomAlphabeticString(28);
            WorkkingWeek = randomDataGenerator.GenerateRandomAlphabeticString(15);
            VacancyClosing = DateTime.Today.AddMonths(2).AddDays(3);
            VacancyStart = VacancyClosing.AddMonths(1).AddDays(1);
            EditedVacancyClosing = VacancyStart.AddDays(14);
            EditedVacancyStart = EditedVacancyClosing.AddDays(14);
            DesiredQualificationsSubject = randomDataGenerator.GenerateRandomAlphabeticString(8);
            OptionalMessage = randomDataGenerator.GenerateRandomAlphabeticString(30);
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

        public string NationalMinimumWage => "£9,464 - £18,137.60";

        public string NationalMinimumWageForApprentices => "£8,632";

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

        private string WebsiteUrl(string url) => $"www.{url}.com";

        private List<string> AvailableProviders => new List<string> { "BALTIC TRAINING SERVICES LIMITED 10019026" };

        private List<string> AvailableTraining => new List<string>
        {
            "Software Tester, Level 4 (Higher national certificate)",
        };

        private List<string> AvailableAddress => new List<string>
        {"0","1", "2", "3", "4", "5", "6", "7", "8", "9"};
    }
}