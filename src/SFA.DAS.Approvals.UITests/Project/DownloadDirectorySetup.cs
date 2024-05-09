using System;
using System.IO;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project
{
    [Binding]
    public class DownloadDirectorySetup(ScenarioContext context)
    {
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

        [BeforeScenario(Order = 5)]
        public void SetUpDirectory()
        {
            string directory = GetDirectoryPath();

            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            _objectContext.Set("downloadDirectory", directory);
        }

        private static string GetDirectoryPath()
        {
            string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Downloads");

            return Path.GetFullPath(directory);
        }
    }
}
