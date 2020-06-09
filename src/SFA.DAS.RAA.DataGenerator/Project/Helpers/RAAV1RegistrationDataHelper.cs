using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.RAA.DataGenerator
{
    public class RAAV1RegistrationDataHelper : RandomDataGeneratorHelper
    {
        public RAAV1RegistrationDataHelper(RandomDataGenerator randomDataGenerator) : base(randomDataGenerator)
        {
            FirstName = randomDataGenerator.GenerateRandomAlphabeticString(6);
            LastName = randomDataGenerator.GenerateRandomAlphabeticString(7);
            EmailAddress = $"{FirstName}.{LastName}@lorem.com";
            Password = $"{randomDataGenerator.GenerateRandomAlphanumericStringWithSpecialCharacters(9)}1";
        }

        public string Title => "Mr";
        public string FirstName { get; }
        public string LastName { get; }
        public string EmailAddress { get; }
        public string MobileNumber => "07777777777";
        public string Password { get; }
    }
}