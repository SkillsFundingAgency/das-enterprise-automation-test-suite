using SFA.DAS.FrameworkHelpers;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    public class EIDataHelper
    {
        public EIDataHelper() { }

        public static string AddressLine1 => $"{RandomDataGenerator.GenerateRandomAlphabeticString(5)} {RandomDataGenerator.GenerateRandomAlphabeticString(5)}";

        public static string Town => RandomDataGenerator.GenerateRandomAlphabeticString(8);

        public static string Poscode => $"CV{RandomDataGenerator.GenerateRandomNumber(1)} {RandomDataGenerator.GenerateRandomNumber(1)}WT";

        public static string BankName => RandomDataGenerator.GenerateRandomAlphabeticString(5);

        public static string AccountNumber => $"2{RandomDataGenerator.GenerateRandomNumber(7)}";

        public static string Sortcode => "000002";

        public static string TelephoneNumber => $"012{RandomDataGenerator.GenerateRandomNumber(8)}";

        public static string FirstName => RandomDataGenerator.GenerateRandomAlphabeticString(10);

        public static string SurName => RandomDataGenerator.GenerateRandomAlphabeticString(10);
    }
}
