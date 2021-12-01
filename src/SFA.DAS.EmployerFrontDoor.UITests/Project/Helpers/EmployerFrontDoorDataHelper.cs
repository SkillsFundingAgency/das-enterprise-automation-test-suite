using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.EmployerFrontDoor.UITests.Project.Helpers
{
    public class EmployerFrontDoorDataHelper : RandomElementHelper
    {
        public EmployerFrontDoorDataHelper(RandomDataGenerator randomDataGenerator) : base(randomDataGenerator)
        {
            Firstname = randomDataGenerator.GenerateRandomAlphabeticString(6);
            Lastname = randomDataGenerator.GenerateRandomAlphabeticString(9);
            FullName = $"{Firstname} {Lastname}";
            Email = $"{Firstname}.{Lastname}@example.com";
        }

        public string FullName { get; }

        public string Firstname { get; }

        public string Lastname { get; }

        public string Email { get; }
    }
}
