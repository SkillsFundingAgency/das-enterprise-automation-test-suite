using System;

namespace SFA.DAS.PocProject.UITests.Project.Helpers
{
    public class DataHelper
    {
        private readonly DateTime dateTime;

        public DataHelper(string code)
        {
            TwoDigitProjectCode = code;
            dateTime = DateTime.Now;
            EmpRefDigits = dateTime.ToString("fffff");
            NextNumber = NextNumberGenerator.GetNextCount();
            RandomUserName = GenerateRandomUserName();
            RandomEmail = GenerateRandomEmail();
        }

        public string TwoDigitProjectCode { get; }

        public string EmpRefDigits { get; }

        public int NextNumber { get; }

        public string RandomEmail { get; }

        public string RandomUserName { get; }

        private string GenerateRandomEmail()
        {
            return $"{RandomUserName}@mailinator.com";
        }
        
        private string GenerateRandomUserName()
        {
            return $"{TwoDigitProjectCode}_Test_{NextNumber}_{dateTime.ToString("ddMMMyyyy_HHmmss")}{EmpRefDigits}";
        }
    }
}
