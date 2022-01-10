using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.RAA.DataGenerator
{
    public class RAAV1RegistrationDataHelper
    {
        public RAAV1RegistrationDataHelper()
        {
            FirstName = RandomDataGenerator.GenerateRandomAlphabeticString(6);
            LastName = RandomDataGenerator.GenerateRandomAlphabeticString(7);
            EmailAddress = $"{FirstName}.{LastName}@lorem.com";
            Password = $"{RandomDataGenerator.GenerateRandomAlphanumericStringWithSpecialCharacters(9)}1";
        }

        public string Title => "Mr";
        public string FirstName { get; }
        public string LastName { get; }
        public string EmailAddress { get; }
        public string MobileNumber => "07777777777";
        public string Password { get; }
    }
}