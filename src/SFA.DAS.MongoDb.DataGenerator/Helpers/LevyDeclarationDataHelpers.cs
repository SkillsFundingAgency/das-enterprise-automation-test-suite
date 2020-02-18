using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.MongoDb.DataGenerator.Helpers
{
    public static class LevyDeclarationDataHelper
    {
        private static readonly decimal EnglishFraction = 1.00m;

        private static readonly DateTime EnglishFractioncalculatedAt = new DateTime(2019, 01, 15);

        public static (decimal fraction, DateTime calculatedAt, Table levyDeclarations) TransferslevyFunds()
        {
            var table = GetTableHeader();
            table.AddRow("18-19", "10", "72000", "99000", "2019-01-15");
            table.AddRow("18-19", "11", "82000", "99000", "2019-02-15");
            table.AddRow("18-19", "12", "92000", "99000", "2019-03-15");
            return (EnglishFraction, EnglishFractioncalculatedAt, table);
        }

        public static (decimal fraction, DateTime calculatedAt, Table levyDeclarations) LevyFunds()
        {
            var table = GetTableHeader();
            table.AddRow("19-20", "1", "62000", "80000", "2019-05-15");
            return (EnglishFraction, EnglishFractioncalculatedAt, table);
        }

        public static (decimal fraction, DateTime calculatedAt, Table levyDeclarations) LevyFunds(string duration, string levyPerMonth)
        {
            (DateTime englishFractioncalculatedAt, Table levyDeclarations) = GetlevyDeclarations(duration, levyPerMonth);
            return (EnglishFraction, englishFractioncalculatedAt, levyDeclarations);
        }

        private static Table GetTableHeader() => new Table("Year", "Month", "LevyDueYTD", "LevyAllowanceForFullYear", "SubmissionDate");

        private static (DateTime calculatedAt, Table levyDeclarations) GetlevyDeclarations(string duration, string levyPerMonth)
        {
            var table = GetTableHeader();
            int.TryParse(duration, out int noOfMonths);
            int.TryParse(levyPerMonth, out int monthlyLevy);

            int levyAllowanceForFullYear = monthlyLevy * noOfMonths;

            for (int i = 0; i < noOfMonths; i++)
            {
                var date = DateTime.Now.AddMonths(i - noOfMonths);
                int levythisMonth = monthlyLevy * (i + 1);

                var levy = GetlevyDeclarations(date, levythisMonth, levyAllowanceForFullYear);
                table.AddRow(levy);
            }

            var englishFractioncalculatedAt = DateTime.Now.AddMonths(-(noOfMonths + 1));
            return (englishFractioncalculatedAt, table);
        }

        public static string[] GetlevyDeclarations(DateTime date, int levyPerMonth, int levyAllowanceForFullYear)
        {
            return new string[] { GetCurrentFinancialYear(date), GetCurrentFinancialMonth(date), levyPerMonth.ToString(), levyAllowanceForFullYear.ToString(), GetSubmissionDate(date) };
        }

        public static string GetSubmissionDate(DateTime dateTime) => $"{dateTime.Year.ToString()}-{dateTime.ToString("MM")}-15";

        public static string GetCurrentFinancialMonth(DateTime dateTime)
        {
            int month = dateTime.Month == 3 ? 12 : dateTime.Month == 2 ? 11 : dateTime.Month == 1 ? 10 : dateTime.Month - 3;

            return month.ToString();
        }

        public static string GetCurrentFinancialYear(DateTime dateTime)
        {
            int CurrentYear = dateTime.Year;
            int PreviousYear = dateTime.Year - 1;
            int NextYear = dateTime.Year + 1;
            string PreYear = TrimYear(PreviousYear);
            string NexYear = TrimYear(NextYear);
            string CurYear = TrimYear(CurrentYear);
            string FinYear = dateTime.Month > 3 ? CurYear + "-" + NexYear : PreYear + "-" + CurYear;
            return FinYear.Trim();
        }

        private static string TrimYear(int year) => year.ToString().Substring(2, 2);
    }
}
