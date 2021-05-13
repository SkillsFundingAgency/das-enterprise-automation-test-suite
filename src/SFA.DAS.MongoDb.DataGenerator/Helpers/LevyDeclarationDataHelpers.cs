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
            (string duration, string year) = GetPreviousTaxYearEnd(DateTime.Now.Date);

            var table = GetTableHeader();
            table.AddRow(duration, "10", "72000", "99000", $"{year}-01-15");
            table.AddRow(duration, "11", "82000", "99000", $"{year}-02-15");
            table.AddRow(duration, "12", "92000", "99000", $"{year}-03-15");
            return (EnglishFraction, EnglishFractioncalculatedAt, table);
        }

        public static (string, string) GetPreviousTaxYearEnd(DateTime dateTime)
        {
            int currentYear = dateTime.Year;
            int previous2Year = currentYear - 2;
            int previousYear = currentYear - 1;
            int nextYear = currentYear + 1;


            if ((dateTime >= new DateTime(currentYear, 4, 6).Date) && (dateTime <= new DateTime(nextYear, 4, 5).Date))
            {
                string duration = $"{TrimYear(previousYear)}-{TrimYear(currentYear)}";
                return (duration, currentYear.ToString());
            }
            else
            {
                string duration = $"{TrimYear(previous2Year)}-{TrimYear(previousYear)}";
                return (duration, previousYear.ToString());
            }
        }

        public static (decimal fraction, DateTime calculatedAt, Table levyDeclarations) LevyFunds() => LevyFunds("15", "9999");

        public static (decimal fraction, DateTime calculatedAt, Table levyDeclarations) LevyFunds(string duration, string levyPerMonth, DateTime dateTime = default(DateTime))
        {
            dateTime = dateTime == default(DateTime) ? DateTime.Now : dateTime;

            (DateTime englishFractioncalculatedAt, Table levyDeclarations) = GetlevyDeclarations(duration, levyPerMonth, dateTime);
            return (EnglishFraction, englishFractioncalculatedAt, levyDeclarations);
        }

        private static Table GetTableHeader() => new Table("Year", "Month", "LevyDueYTD", "LevyAllowanceForFullYear", "SubmissionDate");

        private static (DateTime calculatedAt, Table levyDeclarations) GetlevyDeclarations(string duration, string levyPerMonth, DateTime dateTime)
        {
            var table = GetTableHeader();

            int noOfMonths = int.TryParse(duration, out noOfMonths) ? noOfMonths : 15;
            int levyDueYTD = int.TryParse(levyPerMonth, out levyDueYTD) ? levyDueYTD : 10000;

            int levyAllowanceForFullYear = levyDueYTD * noOfMonths;

            for (int i = 0; i < noOfMonths; i++)
            {
                var date = dateTime.AddMonths(i - noOfMonths);
                int levythisMonth = levyDueYTD * (i + 1);

                var levy = GetlevyDeclarations(date, levythisMonth, levyAllowanceForFullYear);
                table.AddRow(levy);
            }

            var englishFractioncalculatedAt = dateTime.AddMonths(-(noOfMonths + 1));
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
