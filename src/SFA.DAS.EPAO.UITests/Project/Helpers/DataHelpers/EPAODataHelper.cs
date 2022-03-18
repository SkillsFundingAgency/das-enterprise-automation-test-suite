using SFA.DAS.FrameworkHelpers;
using System;

namespace SFA.DAS.EPAO.UITests.Project.Helpers.DataHelpers
{
    public abstract class EPAODataHelper
    {
        public EPAODataHelper()
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

        public string AddressLine1 => "5";
        public string AddressLine2 => "QuintonRoad";
        public string AddressLine3 => "Cheylesmore House";
        public string TownName => "Coventry";
        public string CountyName => "Warwick";
        public string PostCode => "CV1 2WT";

        public string GetRandomNumber(int length) => RandomDataGenerator.GenerateRandomNumber(length);

        public string GetRandomAlphabeticString(int length) => RandomDataGenerator.GenerateRandomAlphabeticString(length);

        private string GetDateTimeValue() => DateTime.Now.ToString("ddMMMyyyyHHmmss").ToUpper();
    }
}