using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;

namespace SFA.DAS.TestDataCleanup.Project.Tests.StepDefinitions
{
    public class TestDataCleanUpReport
    {
        private readonly ObjectContext _objectContext;

        public TestDataCleanUpReport(ObjectContext objectContext) => _objectContext = objectContext;

        internal void TestCleanUpReport(List<string> usersdeleted, List<string> userswithconstraints)
        {
            int x = usersdeleted.Count;

            if (x > 0)
            {
                _objectContext.Set($"{NextNumberGenerator.GetNextCount()}_testdatadeleted", $"{x} account{(x == 1 ? string.Empty : "s")} deleted" +
                    $"{ Environment.NewLine}{ string.Join(Environment.NewLine, usersdeleted)}");
            }

            if (userswithconstraints.Count > 0)
            {
                throw new Exception($"{Environment.NewLine}{string.Join(Environment.NewLine, userswithconstraints)}");
            }
        }
    }
}
