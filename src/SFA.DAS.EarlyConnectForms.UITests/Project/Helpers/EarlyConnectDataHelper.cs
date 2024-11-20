using SFA.DAS.FrameworkHelpers;
using SFA.DAS.MailosaurAPI.Service.Project.Helpers;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Helpers
{
    public class EarlyConnectDataHelper
    {
        public EarlyConnectDataHelper(MailosaurUser user) 
        {
            Firstname = RandomDataGenerator.GenerateRandomAlphabeticString(6);
            Lastname = RandomDataGenerator.GenerateRandomAlphabeticString(9);
            FullName = $"{Firstname} {Lastname}";
            DateOfBirthDay = RandomDataGenerator.GenerateRandomDateOfMonth();
            DateOfBirthMonth = RandomDataGenerator.GenerateRandomMonth();             
            DateOfBirthYear = RandomDataGenerator.GenerateRandomDobYear();
            TelephoneNumber  = $"020{RandomDataGenerator.GenerateRandomNumber(8)}";
            Email = $"{GetDateTimeValue()}@{user.DomainName}";
            user.AddToEmailList(Email);
        }

        public string TelephoneNumber { get;}
        public string FullName { get; }
        public string Firstname { get; }
        public string Lastname { get; }
        public string Email { get; }
        public int DateOfBirthDay { get; set; }
        public int DateOfBirthMonth { get; set; }
        public int DateOfBirthYear { get; set; }
        private static string GetDateTimeValue() => DateTime.Now.ToString("ddMMMyyyyHHmmss").ToLower();
    }
}
