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
            EmployerName = $"{RandomAlphabeticString(10)}_EmployerName";
            EmployerDescription = $"{RandomAlphabeticString(10)}_EmployerDescription";
            EmployerReason = RandomAlphabeticString(10);
            EmployerWebsiteUrl = WebsiteUrl(EmployerName);
            ContactName = RandomAlphabeticString(5);
            Email = $"{ContactName}@lorem.com";
            VacancyShortDescription = RandomAlphabeticString(15);
            WorkExperience = RandomAlphabeticString(15);
            VacancyOutcome = RandomAlphabeticString(22);
            VacancyBriefOverview = RandomAlphabeticString(50);
            TrainingDetails = RandomAlphabeticString(28);
            WorkkingWeek = RandomAlphabeticString(15);
            VacancyClosing = DateTime.Today.AddMonths(2).AddDays(3);
            VacancyStart = VacancyClosing.AddMonths(1).AddDays(1);
            EditedVacancyClosing = VacancyStart.AddDays(14);
            EditedVacancyStart = EditedVacancyClosing.AddDays(14);
            DesiredQualificationsSubject = RandomAlphabeticString(8);
            OptionalMessage = RandomAlphabeticString(30);
        }

        public string VacancyTitle => $"{_vacancyTitleDatahelper.VacancyTitle} apprenticeship";
        public string TraineeshipVacancyTitle => $"{_vacancyTitleDatahelper.VacancyTitle} traineeship";

        public string TrainingTitle => "Abattoir Worker, Level 2 (GCSE)";
        public string SectorName => "Care services";

        public string EmployerAddress => AvailableAddress.RandomOrDefault();

        public string Provider => AvailableProviders.RandomOrDefault();

        public string EmployerName { get; }

        public string EmployerDescription { get; }

        public string EmployerReason { get; }

        public string EmployerWebsiteUrl { get; }

        public string ContactName { get; }

        public string ContactNumber => "07777777777";

        public string Email { get; }

        public string VacancyShortDescription { get; }
        public string WorkExperience { get; }

        public string VacancyOutcome { get; }

        public string TrainingDetails { get; }

        public string Duration => "52";
        public string TraineeshipDuration => "12";

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

        public string RandomAlphabeticString(int length) => RandomDataGenerator.GenerateRandomAlphabeticString(length);
        public string RandomQuestionString(int length) => RandomDataGenerator.GenerateRandomQuestionString(length);

        private string WebsiteUrl(string url) => $"www.{url}.com";

        private List<string> AvailableProviders => new List<string> { "BALTIC TRAINING SERVICES LIMITED 10019026" };

        private List<string> AvailableAddress => new List<string> { "CV33", "CV35", "SM3", "SW11" };
    }
}