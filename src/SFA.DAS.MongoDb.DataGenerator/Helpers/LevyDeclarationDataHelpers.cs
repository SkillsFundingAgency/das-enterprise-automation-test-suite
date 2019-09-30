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
    }
}
