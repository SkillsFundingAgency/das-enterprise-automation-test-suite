using SFA.DAS.FrameworkHelpers;
using System.Collections.Generic;

namespace SFA.DAS.Campaigns.UITests.Project.Helpers
{
    public class CampaignsDataHelper
    {
        public CampaignsDataHelper()
        {
            Firstname = RandomDataGenerator.GenerateRandomAlphabeticString(6);
            Lastname = RandomDataGenerator.GenerateRandomAlphabeticString(9);
            FullName = $"{Firstname} {Lastname}";
            Email = $"{Firstname}.{Lastname}@example.com";
            Positions = RandomDataGenerator.GenerateRandomNumber(1);
            Course = $"Abattoir worker (Level 2)";
            EmployeesSize = RandomDataGenerator.GetRandomElementFromListOfElements(EmployeeRadioOptions);
            Industry = RandomDataGenerator.GetRandomElementFromListOfElements(ValidIndustries);
            Region = RandomDataGenerator.GetRandomElementFromListOfElements(ValidLocations);
        }

        public string FullName { get; }

        public string Firstname { get; }

        public string Lastname { get; }

        public string Email { get; }

        public string Positions { get; }

        public string Course { get; }
        public string Industry { get; init; }
        public string Region { get; init; }
        public string EmployeesSize { get; init; }
        private static List<string> EmployeeRadioOptions => ["Between 10 and 49 employees", "Between 50 and 249 employees", "Over 250 employees"];

        private static List<string> ValidIndustries => ["Care services", "Catering and hospitality", "Creative and design", "Digital", "Education and early years", "Engineering and manufacturing", "Hair and beauty", "Health and science", "Protective services", "Sales, marketing and procurement", "Transport and logistics"];

        private static List<string> ValidLocations => ["South West", "South East", "London", "East of England", "East Midlands", "West Midlands", "North West", "Yorkshire and Humber", "North East"];
    }
}
