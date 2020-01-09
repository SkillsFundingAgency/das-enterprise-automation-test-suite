using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.PayeCreation.Project
{
    [Binding]
    public class Hooks          
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 22)]
        public void SetUpDataHelpers()
        {
            var name = _context.ScenarioInfo.Tags.Contains("levypaye") ? "LE" : "NL";

            var dataHelper = new DataHelper(name);

            _objectContext.SetDataHelper(dataHelper);
        }
    }
}
