using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project.Helpers
{
    public class RegisterHelper
    {
        public RegisterHelper()
        {
            NextNumber = NextNumberGenerator.GetNextCount();
            RandomUserName = GenerateRandUserName();
            RandomEmail = GenerateRandEmail();
        }

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
            return $"Account_Test_{NextNumber}_{System.DateTime.Now.ToString("ddMMMyyyy_HHmmss")}";
        }
    }

    public static class NextNumberGenerator
    {
        static readonly object _object = new object();

        private static int count;

        static NextNumberGenerator()
        {
            count = 100;
        }

        public static int GetNextCount()
        {
            lock (_object)
            {
                count++;
                return count;
            }
        }
    }
}
