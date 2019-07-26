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
            RandomUserName = GenerateRandUserName();
            RandomEmail = GenerateRandEmail();
        }

        public string TwoDigitProjectCode { get; }

        public string EmpRefDigits { get; }

        public int NextNumber { get; }

        public string RandomEmail { get; }

        public string RandomUserName { get; }

        private string GenerateRandEmail()
        {
            return $"{RandomUserName}@mailinator.com";
        }
        
        private string GenerateRandUserName()
        {
            //ToDo : refactor based on environements
            //if (EnvConfigurator.GetEnvConfigInstance().ExecutionEnvironment.Equals("Local"))
            //    return $"MA_Test_LocalRun{System.DateTime.Now.ToString("ddMMMyyyy_HHmmss")}@mailinator.com";
            //else
            return $"{TwoDigitProjectCode}_Test_{NextNumber}_{dateTime.ToString("ddMMMyyyy_HHmmss")}{EmpRefDigits}";
        }
    }
}
