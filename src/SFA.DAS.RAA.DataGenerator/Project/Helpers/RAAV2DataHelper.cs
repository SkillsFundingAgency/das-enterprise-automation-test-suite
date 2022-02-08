using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.RAA.DataGenerator
{
    public class RAAV2DataHelper
    {
        private readonly VacancyTitleDatahelper _vacancyTitleDatahelper;

        public RAAV2DataHelper(VacancyTitleDatahelper vacancyTitleDatahelper)
        {
            _vacancyTitleDatahelper = vacancyTitleDatahelper;
            EmployerTradingName = $"{RandomDataGenerator.GenerateRandomAlphabeticString(10)}_EmployerName";
            EmployerDescription = $"{RandomDataGenerator.GenerateRandomAlphabeticString(10)}_EmployerDescription";
            EmployerReason = RandomDataGenerator.GenerateRandomAlphabeticString(10);
            EmployerWebsiteUrl = WebsiteUrl(EmployerTradingName);
            ContactName = RandomDataGenerator.GenerateRandomAlphabeticString(5);
            Email = $"{ContactName}@lorem.com";
            VacancyShortDescription = RandomDataGenerator.GenerateRandomAlphabeticString(15);
            VacancyOutcome = RandomDataGenerator.GenerateRandomAlphabeticString(22);
            VacancyBriefOverview = RandomDataGenerator.GenerateRandomAlphabeticString(50);
            TrainingDetails = RandomDataGenerator.GenerateRandomAlphabeticString(28);
            WorkkingWeek = RandomDataGenerator.GenerateRandomAlphabeticString(15);
            VacancyClosing = DateTime.Today.AddMonths(2).AddDays(3);
            VacancyStart = VacancyClosing.AddMonths(1).AddDays(1);
            EditedVacancyClosing = VacancyStart.AddDays(14);
            EditedVacancyStart = EditedVacancyClosing.AddDays(14);
            DesiredQualificationsSubject = RandomDataGenerator.GenerateRandomAlphabeticString(8);
            OptionalMessage = RandomDataGenerator.GenerateRandomAlphabeticString(30);
        }

        public string VacancyTitle => $"{_vacancyTitleDatahelper.VacancyTitle} apprenticeship";

        public string TrainingTitle => "Abattoir Worker, Level 2 (GCSE)";

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

        public string FixedWageYearlyAmount => "11000";

        public string NationalMinimumWage => "£10,004.80 to £19,760";

        public string NationalMinimumWageForApprentices => "£10,004.80";

        public string FixedWageForApprentices => "£11,000";

        public DateTime EditedVacancyClosing { get; }

        public DateTime EditedVacancyStart { get; }

        public DateTime VacancyClosing { get; }

        public DateTime VacancyStart { get; }

        public string VacancyBriefOverview { get; }

        public string DesiredQualificationsSubject { get; }

        public string DesiredQualificationsGrade => "A Level";

        public string NumberOfVacancy => "2";

        public string OptionalMessage { get; }

        private string WebsiteUrl(string url) => $"www.{url}.com";

        private List<string> AvailableProviders => new List<string> { "BALTIC TRAINING SERVICES LIMITED 10019026" };

        private List<string> AvailableAddress => new List<string> {"0","1", "2", "3", "4", "5", "6", "7", "8", "9"};
    }
}