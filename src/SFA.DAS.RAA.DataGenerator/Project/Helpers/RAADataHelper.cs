using SFA.DAS.FrameworkHelpers;
using SFA.DAS.RAA.DataGenerator.Project.Config;
using System;
using System.Collections.Generic;

namespace SFA.DAS.RAA.DataGenerator
{
    public class RAADataHelper
    {
        private readonly VacancyTitleDatahelper _vacancyTitleDatahelper;

        public RAADataHelper(FAAUserConfig faaConfig, VacancyTitleDatahelper vacancyTitleDatahelper)
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
            //VacancyClosing = DateTime.Today.AddMonths(2).AddDays(3);
            VacancyClosing = new DateTime(2025, 7, 23);
            //VacancyStart = VacancyClosing.AddMonths(1).AddDays(1);
            VacancyStart = new DateTime(2025, 8, 1);
            EditedVacancyClosing = VacancyStart.AddDays(14);
            EditedVacancyStart = EditedVacancyClosing.AddDays(14);
            DesiredQualificationsSubject = RandomAlphabeticString(8);
            OptionalMessage = RandomAlphabeticString(30);
        }

        public string CandidateFirstName { get; }
        public string CandidateLastName { get; }
        public string CandidateFullName => $"{CandidateFirstName} {CandidateLastName}";

        public string VacancyTitle => $"{_vacancyTitleDatahelper.VacancyTitle} apprenticeship";

        public static string TrainingTitle => "Abattoir Worker, Level 2 (GCSE)";

        public static string FoundationTrainingTitle => "Building service engineering foundation apprenticeship, Level 2 (GCSE)";

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

        public static string FixedWageYearlyAmount => "16000";

        public static string NationalMinimumWage => "£15,704 to £25,396.80 a year";

        public static string NationalMinimumWageForApprentices => "£15,704 a year";

        public static string SetAsCompetitive => "Competitive";

        public static string FixedWageForApprentices => "£16,000 a year";

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

        private static List<string> AvailableProviders => ["BALTIC TRAINING SERVICES LIMITED (10019026)"];

        private static List<string> AvailableAddress => ["SW1H 9NA", "SW1A 2AA", "SE1 8UG", "E14 4PU", "SW1A 1AA", "SW1P 3BT"];
    }
}