using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestDataCleanup.Project.Tests.StepDefinitions
{
    public abstract class TestdataCleanupBaseSteps
    {
        protected readonly DbConfig _dbConfig;

        private readonly ScenarioContext _context;

        public TestdataCleanupBaseSteps(ScenarioContext context)
        {
            _context = context;
            
            _dbConfig = context.Get<DbConfig>();
        }

        protected void CleanUpTestData(Func<(List<string>, List<string>)> func)
        {
            var (usersdeleted, userswithconstraints) = func.Invoke();

            TestCleanUpReport(usersdeleted, userswithconstraints);
        }

        private void TestCleanUpReport(List<string> usersdeleted, List<string> userswithconstraints)
        {
            int x = usersdeleted.Count;

            if (x > 0)
            {
                _context.Get<ObjectContext>().Set($"{NextNumberGenerator.GetNextCount()}_testdatadeleted", $"{x} account{(x == 1 ? string.Empty : "s")} deleted" +
                    $"{ Environment.NewLine}{ string.Join(Environment.NewLine, usersdeleted)}");
            }

            if (userswithconstraints.Count > 0)
            {
                throw new Exception($"{Environment.NewLine}{string.Join(Environment.NewLine, userswithconstraints)}");
            }
        }
    }
}
