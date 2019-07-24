using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.PocProject.UITests.Project.Helpers
{
    public class RegisterHelper
    {
        private readonly Random random;

        public RegisterHelper()
        {
            random = new Random();
        }

        internal string GenerateRandEmail()
        {
            //ToDo : refactor based on environements
            //if (EnvConfigurator.GetEnvConfigInstance().ExecutionEnvironment.Equals("Local"))
            //    return $"MA_Test_LocalRun{System.DateTime.Now.ToString("ddMMMyyyy_HHmmss")}@mailinator.com";
            //else
            return $"MA_Test_{random.Next(100, 999)}_{System.DateTime.Now.ToString("ddMMMyyyy_HHmmss")}@mailinator.com";
        }
    }
}
