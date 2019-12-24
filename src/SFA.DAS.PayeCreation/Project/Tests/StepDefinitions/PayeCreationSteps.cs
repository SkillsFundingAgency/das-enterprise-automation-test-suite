using SFA.DAS.PayeCreation.Project;
using SFA.DAS.MongoDb.DataGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

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
            _payeCreationConfig = context.GetPayeCreationConfig();
        }

        [Given(@"I add non levy declarations")]
        public void GivenIAddNonLevyDeclarations()
        {
            _mongoDbDataGenerator = new MongoDbDataGenerator(_context);

            _mongoDbDataGenerator.AddGatewayUsers();
        }

        [Given(@"I add levy declarations")]
        public void GivenIAddLevyDeclarations()
        {
            throw new PendingStepException();
        }

    }
}
