using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.FrameworkHelpers;
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

        public DirectorySetup(ScenarioContext context, FeatureContext featureContext)
        {
            _featureContext = featureContext;
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 4)]
        public void SetUpDirectory()
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory
             + "../../"
             + "Project\\Screenshots\\"
             + DateTime.Now.ToString("dd-MM-yyyy")
             + "\\"
             + EscapePatternHelper.DirectoryEscapePattern(_featureContext.FeatureInfo.Title)
             + "\\";

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            _objectContext.SetDirectory(directory);

            _objectContext.SetAfterStepInformations();
        }
    }
}
