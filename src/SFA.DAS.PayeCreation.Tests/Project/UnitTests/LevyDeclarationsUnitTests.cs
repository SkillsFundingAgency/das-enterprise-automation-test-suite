using NUnit.Framework;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SFA.DAS.PayeCreation.Project.UnitTests
{
    [TestFixture]
    public class LevyDeclarationsUnitTests
    {
        [TestCase(2020, 04, 24, "19-20", "2020")]
        [TestCase(2021, 04, 24, "20-21", "2021")]
        [TestCase(2022, 04, 05, "20-21", "2021")]
        [TestCase(2022, 04, 06, "21-22", "2022")]
        [TestCase(2022, 04, 24, "21-22", "2022")]
        public void GetPreviousTaxYearEnd(int year, int month, int date, string expectedduraration, string expectedyear)
        {
            (string actualduration, string actualyear) = LevyDeclarationDataHelper.GetPreviousTaxYearEnd(new DateTime(year, month, date));

            Assert.Multiple(() => 
            {
                StringAssert.AreEqualIgnoringCase(expectedduraration, actualduration);
                StringAssert.AreEqualIgnoringCase(expectedyear, actualyear);
            });
        }

        [TestCase(2018, 12, 24, "18-19")]
        [TestCase(2019, 03, 24, "18-19")]
        [TestCase(2019, 04, 24, "19-20")]
        [TestCase(2019, 12, 24, "19-20")]
        [TestCase(2020, 01, 24, "19-20")]
        [TestCase(2020, 02, 24, "19-20")]
        [TestCase(2020, 03, 24, "19-20")]
        [TestCase(2020, 04, 24, "20-21")]
        public void GetCurrentFinancialYear(int year, int month, int date, string result)
        {
            var finyear = LevyDeclarationDataHelper.GetCurrentFinancialYear(new DateTime(year, month, date));

            StringAssert.AreEqualIgnoringCase(result, finyear);
        }
        
        [TestCase(2019, 05, 24, "2")]
        [TestCase(2019, 06, 24, "3")]
        [TestCase(2019, 07, 24, "4")]
        [TestCase(2019, 08, 24, "5")]
        [TestCase(2019, 09, 24, "6")]
        [TestCase(2019, 10, 24, "7")]
        [TestCase(2019, 11, 24, "8")]
        [TestCase(2019, 12, 24, "9")]
        [TestCase(2020, 01, 24, "10")]
        [TestCase(2020, 02, 24, "11")]
        [TestCase(2020, 03, 24, "12")]
        [TestCase(2020, 04, 24, "1")]
        public void GetCurrentFinancialMonth(int year, int month, int date, string result)
        {
            var finmonth = LevyDeclarationDataHelper.GetCurrentFinancialMonth(new DateTime(year, month, date));

            StringAssert.AreEqualIgnoringCase(result, finmonth);
        }

        [TestCase]
        public void GetLevyFunds()
        {
            int noOfmonths = 10;
            int levypermonth = 10000;
            string levyperyear = (noOfmonths * levypermonth).ToString();
            List<List<string>> expected = new List<List<string>>() 
            {
                new List<string>() { "18-19", "11", (levypermonth * 1).ToString(), levyperyear, "2019-02-15" },
                new List<string>() { "18-19", "12", (levypermonth * 2).ToString(), levyperyear, "2019-03-15" },
                new List<string>() { "19-20", "1", (levypermonth * 3).ToString(), levyperyear, "2019-04-15" },
                new List<string>() { "19-20", "2", (levypermonth * 4).ToString(), levyperyear, "2019-05-15" },
                new List<string>() { "19-20", "3", (levypermonth * 5).ToString(), levyperyear, "2019-06-15" },
                new List<string>() { "19-20", "4", (levypermonth * 6).ToString(), levyperyear, "2019-07-15" },
                new List<string>() { "19-20", "5", (levypermonth * 7).ToString(), levyperyear, "2019-08-15" },
                new List<string>() { "19-20", "6", (levypermonth * 8).ToString(), levyperyear, "2019-09-15" },
                new List<string>() { "19-20", "7", (levypermonth * 9).ToString(), levyperyear, "2019-10-15" },
                new List<string>() { "19-20", "8", (levypermonth * 10).ToString(), levyperyear, "2019-11-15" }
            };

            var (_, _, levyDeclarations) = LevyDeclarationDataHelper.LevyFunds(noOfmonths.ToString(), levypermonth.ToString(), new DateTime(2019, 12, 20));

            for (int i = 0; i <= noOfmonths - 1; i++)
            {
                CollectionAssert.AreEqual(expected[i], levyDeclarations.Rows[i].Values);
            }
        }

        [TestCase]
        public void Get0LevyFundsFor1Month()
        {
            //This test was written on 20/02/2020
            int noOfmonths = 1;
            int levypermonth = 0;
            string levyperyear = (noOfmonths * levypermonth).ToString();
            List<List<string>> expected = new List<List<string>>()
            {
                new List<string>() { "19-20", "10", (levypermonth * 1).ToString(), levyperyear, "2020-01-15" },
            };

            var (_, _, levyDeclarations) = LevyDeclarationDataHelper.LevyFunds(noOfmonths.ToString(), levypermonth.ToString());

            for (int i = 0; i <= noOfmonths - 1; i++)
            {
                CollectionAssert.AreEqual(expected[i], levyDeclarations.Rows[i].Values);
            }
        }
    }
}
