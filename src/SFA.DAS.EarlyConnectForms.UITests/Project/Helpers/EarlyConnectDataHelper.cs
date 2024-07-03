using SFA.DAS.FrameworkHelpers;
using System;
using System.Security.Cryptography;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Helpers
{
    public class EarlyConnectDataHelper
    {
        public EarlyConnectDataHelper() 
        {
            Firstname = RandomDataGenerator.GenerateRandomAlphabeticString(6);
            Lastname = RandomDataGenerator.GenerateRandomAlphabeticString(9);
            FullName = $"{Firstname} {Lastname}";
            Email = $"{Firstname}.{Lastname}@szs3qaml.mailosaur.net";
            DateOfBirthDay = RandomDataGenerator.GenerateRandomDateOfMonth();
            DateOfBirthMonth = RandomDataGenerator.GenerateRandomMonth();             
            DateOfBirthYear = RandomDataGenerator.GenerateRandomDobYear();

        }
        public string FullName { get; }
        public string Firstname { get; }
        public string Lastname { get; }
        public string Email { get; }
        public int DateOfBirthDay { get; set; }
        public int DateOfBirthMonth { get; set; }
        public int DateOfBirthYear { get; set; }
    }
}
