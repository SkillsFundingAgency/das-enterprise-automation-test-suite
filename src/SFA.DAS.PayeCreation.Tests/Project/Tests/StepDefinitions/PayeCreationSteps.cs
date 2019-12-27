using SFA.DAS.MongoDb.DataGenerator;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using NUnit.Framework;
using SFA.DAS.Configuration;
using System.Linq;

namespace SFA.DAS.PayeCreation.Project.Tests.StepDefinitions
{
    [Binding]
    public class PayeCreationSteps
    {
        private MongoDbDataGenerator _mongoDbDataGenerator;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly PayeCreationConfig _payeCreationConfig;

        public PayeCreationSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _mongoDbDataGenerator = new MongoDbDataGenerator(_context);
            _payeCreationConfig = context.GetPayeCreationConfig();
        }

        [Given(@"I add non levy declarations")]
        public void GivenIAddNonLevyDeclarations() => AddGatewayUsers();

        [Given(@"I add levy declarations")]
        public void GivenIAddLevyDeclarations()
        {
            AddGatewayUsers();

            var (fraction, calculatedAt, levyDeclarations) = LevyDeclarationDataHelper.LevyFunds(_payeCreationConfig.Duration, _payeCreationConfig.LevyPerMonth);
            foreach(var item in levyDeclarations.Rows.ToList().Select(x => x.Values))
            {
                TestContext.Progress.WriteLine($"Levy Declarations: {_objectContext.GetGatewayPaye()} - {string.Join(",", item.Select(y => y))}");
            }
            _mongoDbDataGenerator.AddLevyDeclarations(fraction, calculatedAt, levyDeclarations);
            
        }

        private void AddGatewayUsers() => _mongoDbDataGenerator.AddGatewayUsers();
    }
}
