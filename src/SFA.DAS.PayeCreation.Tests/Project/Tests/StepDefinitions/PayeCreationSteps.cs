using SFA.DAS.MongoDb.DataGenerator;
using TechTalk.SpecFlow;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using System.Linq;

namespace SFA.DAS.PayeCreation.Project.Tests.StepDefinitions
{
    [Binding]
    public class PayeCreationSteps
    {
        private MongoDbDataGenerator _mongoDbDataGenerator;
        private readonly ScenarioContext _context;
        private readonly PayeCreationConfig _payeCreationConfig;

        public PayeCreationSteps(ScenarioContext context)
        {
            _context = context;
            _mongoDbDataGenerator = new MongoDbDataGenerator(_context);
            _payeCreationConfig = context.GetPayeCreationConfig();
        }

        [Given(@"I add non levy declarations")]
        public void GivenIAddNonLevyDeclarations() => AddGatewayUsers();

        [Given(@"I add levy declarations")]
        public void GivenIAddLevyDeclarations()
        {
            var gatewayCreds = AddGatewayUsers();

            var (fraction, calculatedAt, levyDeclarations) = LevyDeclarationDataHelper.LevyFunds(_payeCreationConfig.Duration, _payeCreationConfig.LevyPerMonth);
            foreach (var item in levyDeclarations.Rows.ToList().Select(x => x.Values))
            {
                TestContext.Progress.WriteLine($"Levy Declarations: {gatewayCreds.Paye} - {string.Join(",", item.Select(y => y))}");
            }
           
            _mongoDbDataGenerator.AddLevyDeclarations(fraction, calculatedAt, levyDeclarations);
        }

        private GatewayCreds AddGatewayUsers() => _mongoDbDataGenerator.AddGatewayUsers(0);
    }
}
