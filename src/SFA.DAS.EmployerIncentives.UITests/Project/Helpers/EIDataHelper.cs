using SFA.DAS.FrameworkHelpers;
using System;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Helpers
{
    public class EIDataHelper
    {
        public EIDataHelper() { }

        public string AddressLine1 => $"{RandomDataGenerator.GenerateRandomAlphabeticString(5)} {RandomDataGenerator.GenerateRandomAlphabeticString(5)}";

        public string Town => RandomDataGenerator.GenerateRandomAlphabeticString(8);

        public string Poscode => $"CV{RandomDataGenerator.GenerateRandomNumber(1)} {RandomDataGenerator.GenerateRandomNumber(1)}WT";

        public string BankName => RandomDataGenerator.GenerateRandomAlphabeticString(5);

        public string AccountNumber => $"2{RandomDataGenerator.GenerateRandomNumber(7)}";

        public string Sortcode => "000002";

        public string TelephoneNumber => $"012{RandomDataGenerator.GenerateRandomNumber(8)}";

        public string FirstName => RandomDataGenerator.GenerateRandomAlphabeticString(10);

        public string SurName => RandomDataGenerator.GenerateRandomAlphabeticString(10);

        public DateTime JoiningDate(bool validStartDate)
            => validStartDate ? RandomDataGenerator.GenerateRandomDate(new DateTime(2021, 10, 1), new DateTime(2021, 12, 31)) :
                                RandomDataGenerator.GenerateRandomDate(new DateTime(2022, 02, 4), new DateTime(2022, 02, 28)) ;
    }
}
