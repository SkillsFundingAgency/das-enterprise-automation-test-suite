using SFA.DAS.ConfigurationBuilder;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace SFA.DAS.TestDataExport.BeforeScenario
{
    [Binding]
    public class DirectorySetup
    {
        private readonly ObjectContext _objectContext;

        public DirectorySetup(ScenarioContext context) => _objectContext = context.Get<ObjectContext>();

        [BeforeScenario(Order = 4)]
        public void SetUpDirectory()
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory
             + "../../"
             + "Project\\Screenshots\\"
             + DateTime.Now.ToString("dd-MM-yyyy")
             + "\\";

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            _objectContext.SetDirectory(directory);
        }
    }
}
