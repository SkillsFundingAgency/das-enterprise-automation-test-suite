using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.TestDataExport.Helper;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestDataExport.BeforeScenario
{
    [Binding]
    public class DirectorySetup
    {
        private readonly ObjectContext _objectContext;
        private readonly FeatureContext _featureContext;
        private readonly ScenarioContext _context;

        public DirectorySetup(ScenarioContext context, FeatureContext featureContext)
        {
            _context = context;
            _featureContext = featureContext;
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 1)]
        public void SetUpHelpers() => _context.Set(new TryCatchExceptionHelper(_objectContext));

        [BeforeScenario(Order = 4)]
        public void SetUpDirectory()
        {
            string directory = GetDirectoryPath();

            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            _objectContext.SetDirectory(directory);

            _objectContext.SetTestDataList();
        }

        private string GetDirectoryPath()
        {
            string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots", $"{DateTime.Now:dd-MM-yyyy}", $"{EscapePatternHelper.DirectoryEscapePattern(_featureContext.FeatureInfo.Title)}");

            return Path.GetFullPath(directory);
        }
    }
}
