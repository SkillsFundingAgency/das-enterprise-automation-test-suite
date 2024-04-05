using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.EarlyConnectForms.UITests.Project.Helpers
{
    public class EarlyConnectDataHelper
    {
        public EarlyConnectDataHelper() 
        {
            Firstname = RandomDataGenerator.GenerateRandomAlphabeticString(6);
            Lastname = RandomDataGenerator.GenerateRandomAlphabeticString(9);
            FullName = $"{Firstname} {Lastname}";
            Email = $"{Firstname}.{Lastname}@example.com";
        }
        public string FullName { get; }

        public string Firstname { get; }

        public string Lastname { get; }
        public string Email { get; }
    }
}
