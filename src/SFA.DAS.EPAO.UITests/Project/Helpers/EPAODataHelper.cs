using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.EPAO.UITests.Project.Helpers
{
    public class EPAODataHelper : RandomElementHelper
    {
        protected readonly RandomDataGenerator randomDataGenerator;

        public EPAODataHelper(RandomDataGenerator randomDataGenerator) : base(randomDataGenerator)
        {
            this.randomDataGenerator = randomDataGenerator;
            CurrentDay = DateTime.Now.Day;
            CurrentMonth = DateTime.Now.Month;
            CurrentYear = DateTime.Now.Year;
            RandomEmail = GetDateTimeValue() + "@mailinator.com";
            RandomWebsiteAddress = "www.TEST" + GetDateTimeValue() + ".com";
        }

        public int CurrentDay { get; }
        public int CurrentMonth { get; }
        public int CurrentYear { get; }
        public string RandomEmail { get; }
        public string RandomWebsiteAddress { get; }
        public string TownName => "Coventry";
        public string CountyName => "Warwick";
        public string PostCode => "CV1 2WT";
        public string InvalidOrgNameWithAlphabets => "asfasfasdfasdf";
        public string InvalidOrgNameWithNumbers => "54678900";
        public string InvalidOrgNameWithAWord => "EPA01";

        public string GetRandomNumber(int length) => randomDataGenerator.GenerateRandomNumber(length);

        public string GetRandomAlphabeticString(int length) => randomDataGenerator.GenerateRandomAlphabeticString(length);
        public string GetRandomAlphanumericString(int length) => randomDataGenerator.GenerateRandomAlphanumericStringWithSpecialCharacters(length);

        public IWebElement GetRandomElementFromListOfElements(List<IWebElement> options) => randomDataGenerator.GetRandomElementFromListOfElements(options);

        private string GetDateTimeValue() => DateTime.Now.ToString("ddMMMyyyyHHmmss").ToUpper();
    }
}