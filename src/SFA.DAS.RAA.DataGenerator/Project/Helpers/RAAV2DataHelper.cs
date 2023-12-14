using SFA.DAS.FrameworkHelpers;
using SFA.DAS.RAA.DataGenerator.Project.Config;
using System;
using System.Collections.Generic;

namespace SFA.DAS.RAA.DataGenerator
{
    public class RAAV2DataHelper
    {
        private readonly VacancyTitleDatahelper _vacancyTitleDatahelper;

        public RAAV2DataHelper(FAAConfig faaConfig, VacancyTitleDatahelper vacancyTitleDatahelper)
        {
            _vacancyTitleDatahelper = vacancyTitleDatahelper;
            CandidateFirstName = faaConfig.FAAFirstName;
            CandidateLastName = faaConfig.FAALastName;
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

        public string CandidateFirstName { get; }
        public string CandidateLastName { get; }
        public string CandidateFullName => $"{CandidateFirstName} {CandidateLastName}";

        public string VacancyTitle => $"{_vacancyTitleDatahelper.VacancyTitle} apprenticeship";
        public string TraineeshipVacancyTitle => $"{_vacancyTitleDatahelper.VacancyTitle} traineeship";

        public static string TrainingTitle => "Abattoir Worker, Level 2 (GCSE)";
        public static string SectorName => "Care services";

        public static string EmployerAddress => AvailableAddress.RandomOrDefault();

        public static string Provider => AvailableProviders.RandomOrDefault();

        public string EmployerName { get; }

        public string EmployerDescription { get; }

        public string EmployerReason { get; }

        public string EmployerWebsiteUrl { get; }

        public string ContactName { get; }

        public static string ContactNumber => "07777777777";

        public string Email { get; }

        public string VacancyShortDescription { get; }
        public string WorkExperience { get; }

        public string VacancyOutcome { get; }

        public string TrainingDetails { get; }

        public static string Duration => "52";
        public static string TraineeshipDuration => "12";

        public string WorkkingWeek { get; }

        public static string WeeklyHours => "40";

        public static string FixedWageYearlyAmount => "11000";

        public static string NationalMinimumWage => "£10,982.40 to £21,673.60";

        public static string NationalMinimumWageForApprentices => "£10,982.40";

        public static string SetAsCompetitive => "Competitive";

        public static string FixedWageForApprentices => "£11,000";

        public DateTime EditedVacancyClosing { get; }

        public DateTime EditedVacancyStart { get; }

        public DateTime VacancyClosing { get; }

        public DateTime VacancyStart { get; }

        public string VacancyBriefOverview { get; }

        public string DesiredQualificationsSubject { get; }

        public static string DesiredQualificationsGrade => "A Level";

        public static string NumberOfVacancy => "2";

        public string OptionalMessage { get; }

        public static string RandomAlphabeticString(int length) => RandomDataGenerator.GenerateRandomAlphabeticString(length);
        
        public static string RandomQuestionString(int length) => $"{RandomDataGenerator.GenerateRandomAlphabeticString(length)}?";

        private static string WebsiteUrl(string url) => $"www.{url}.com";

        private static List<string> AvailableProviders => new() { "BALTIC TRAINING SERVICES LIMITED 10019026" };

        private static List<string> AvailableAddress => new() { "CV33", "CV35", "SM3", "SW11" };
    }
}