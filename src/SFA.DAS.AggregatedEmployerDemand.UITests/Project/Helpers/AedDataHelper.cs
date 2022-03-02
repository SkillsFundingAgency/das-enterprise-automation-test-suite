using System;
using System.Collections.Generic;
using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.AggregatedEmployerDemand.UITests.Project.Helpers
{
    public class AedDataHelper
    {
        public AedDataHelper()
        {
            RandomEmail = GetDateTimeValue() + "@mailinator.com";
            RandomWebsiteAddress = "www.TEST" + GetDateTimeValue() + ".com";
            TelephoneNumber = $"020{GetRandomNumber(8)}";
            Location = RandomDataGenerator.GetRandomElementFromListOfElements(ValidLocations);
        }

        public string RandomEmail { get; }
        public string RandomWebsiteAddress { get; }
        public string TelephoneNumber { get; }

        public string Location { get; }     

        public string OrganisationName => "Quinton Testing Ltd";

        public string GetRandomNumber(int length) => RandomDataGenerator.GenerateRandomNumber(length);

        private string GetDateTimeValue() => DateTime.Now.ToString("ddMMMyyyyHHmmss").ToUpper();

        private static List<string> ValidLocations => new List<string> { "Crawley, West Sussex", "Bilston, West Midlands", "Coventry, West Midlands", "Canary Wharf, Greater London", "CV1 2WT" };
    }
}
