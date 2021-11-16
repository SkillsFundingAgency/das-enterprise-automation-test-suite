using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers
{
    public abstract class EPAODataHelper : RandomElementHelper
    {
        public EPAODataHelper() : base()
        {
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

        public string GetRandomNumber(int length) => RandomDataGenerator.GenerateRandomNumber(length);

        public string GetRandomAlphabeticString(int length) => RandomDataGenerator.GenerateRandomAlphabeticString(length);
        public string GetRandomAlphanumericString(int length) => RandomDataGenerator.GenerateRandomAlphanumericStringWithSpecialCharacters(length);

        public IWebElement GetRandomElementFromListOfElements(List<IWebElement> options) => base.GetRandomElementFromListOfElements(options);

        private string GetDateTimeValue() => DateTime.Now.ToString("ddMMMyyyyHHmmss").ToUpper();
    }
}