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
            var table = new Table("Year", "Month", "LevyDueYTD", "LevyAllowanceForFullYear", "SubmissionDate");
            table.AddRow("18-19", "10", "72000", "99000", "2019-01-15");
            table.AddRow("18-19", "11", "82000", "99000", "2019-02-15");
            table.AddRow("18-19", "12", "92000", "99000", "2019-03-15");
            return (EnglishFraction, EnglishFractioncalculatedAt, table);
        }

        public static (decimal fraction, DateTime calculatedAt, Table levyDeclarations) LevyFunds()
        {
            var table = new Table("Year", "Month", "LevyDueYTD", "LevyAllowanceForFullYear", "SubmissionDate");
            table.AddRow("19-20", "1", "62000", "80000", "2019-05-15");
            return (EnglishFraction, EnglishFractioncalculatedAt, table);
        }

        public static (decimal fraction, DateTime calculatedAt, Table levyDeclarations) LevyFunds(string duration, string levyPerMonth)
        {
            var table = GetlevyDeclarations(duration, levyPerMonth);
            return (EnglishFraction, EnglishFractioncalculatedAt, table);
        }

        private static Table GetlevyDeclarations(string duration, string levyPerMonth)
        {
            var table = new Table("Year", "Month", "LevyDueYTD", "LevyAllowanceForFullYear", "SubmissionDate");

            var noOfMonths = int.Parse(duration);
            for (int i = noOfMonths; i == 0; i--)
            {
                var date = DateTime.Now.AddMonths(-i);
                table.AddRow(GetlevyDeclarations(date));
            }


            table.AddRow("19-20", "1", "62000", "80000", "2019-05-15");
            return table;
        }

        private static string[] GetlevyDeclarations(DateTime dateTime)
        {
            date
        }

        private static string GetSubmissionDate(DateTime dateTime)
        {
            return $"{dateTime.Year.ToString()}-{dateTime.Month.ToString()}-15";
        }


        private static string GetMonth(DateTime dateTime)
        {
            int month = dateTime.Month - 3;
            if (dateTime.Month == 3)
            {
                month = 12;
            }
            else if (dateTime.Month == 2)
            {
                month = 11;
            }
            else if (dateTime.Month == 1)
            {
                month = 10;
            }

            return month.ToString();
        }

        public static string GetCurrentFinancialYear(DateTime dateTime)
        {
            int CurrentYear = dateTime.Year;
            int PreviousYear = dateTime.Year - 1;
            int NextYear = dateTime.Year + 1;
            string PreYear = PreviousYear.ToString("yy");
            string NexYear = NextYear.ToString("yy");
            string CurYear = CurrentYear.ToString("yy");
            string FinYear = dateTime.Month > 3 ? CurYear + "-" + NexYear : PreYear + "-" + CurYear;

            return FinYear.Trim();
        }
    }
}
