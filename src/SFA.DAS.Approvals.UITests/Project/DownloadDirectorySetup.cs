using SFA.DAS.FrameworkHelpers;
using System.IO;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project
{
    [Binding, Scope(Tag = "@setdownloadsdirectory")]
    public class DownloadDirectorySetup(ScenarioContext context)
    {
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();

        [BeforeScenario(Order = 35)]
        public void SetUpDirectory()
        {
            string directory = GetDirectoryPath();

            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            _objectContext.Set("downloadDirectory", directory);
        }

        private static string GetDirectoryPath()
        {
            string directory = FileHelper.GetDownloadsDirectoryPath();

            return Path.GetFullPath(directory);
        }
    }
}
