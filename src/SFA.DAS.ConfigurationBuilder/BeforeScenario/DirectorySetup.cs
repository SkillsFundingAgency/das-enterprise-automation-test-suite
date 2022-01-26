using SFA.DAS.FrameworkHelpers;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace SFA.DAS.ConfigurationBuilder.BeforeScenario
{
    [Binding]
    public class DirectorySetup
    {
        private readonly ObjectContext _objectContext;
        private readonly FeatureContext _featureContext;

        public DirectorySetup(ScenarioContext context, FeatureContext featureContext)
        {
            _featureContext = featureContext;
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 4)]
        public void SetUpDirectory()
        {
            string directory = GetDirectoryPath();

            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            _objectContext.SetDirectory(directory);
        }

        private string GetDirectoryPath()
        {
            string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestAttachments", $"{DateTime.Now:dd-MM-yyyy}", $"{EscapePatternHelper.DirectoryEscapePattern(_featureContext.FeatureInfo.Title)}");

            return Path.GetFullPath(directory);
        }
    }
}