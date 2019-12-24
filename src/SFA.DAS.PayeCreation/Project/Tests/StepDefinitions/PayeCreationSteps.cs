using SFA.DAS.PayeCreation.Project;
using SFA.DAS.MongoDb.DataGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using SFA.DAS.MongoDb.DataGenerator.Helpers;

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
        public void GivenIAddNonLevyDeclarations()
        {
            AddGatewayUsers();
        }

        [Given(@"I add levy declarations")]
        public void GivenIAddLevyDeclarations()
        {
            AddGatewayUsers();

            var (fraction, calculatedAt, levyDeclarations) = LevyDeclarationDataHelper.LevyFunds(_payeCreationConfig.Duration, _payeCreationConfig.LevyPerMonth);
            _mongoDbDataGenerator.AddLevyDeclarations(fraction, calculatedAt, levyDeclarations);
        }

        private void AddGatewayUsers()
        {
            _mongoDbDataGenerator.AddGatewayUsers();
        }

    }
}
