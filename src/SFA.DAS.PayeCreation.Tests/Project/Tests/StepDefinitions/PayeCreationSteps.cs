using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.MongoDb.DataGenerator;
using TechTalk.SpecFlow;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using NUnit.Framework;
using System.Linq;
using SFA.DAS.PayeCreation.Tests.Project;

namespace SFA.DAS.PayeCreation.Project.Tests.StepDefinitions
{
    [Binding]
    public class PayeCreationSteps
    {
        private readonly ScenarioContext _context;
        private readonly PayeCreationConfig _payeCreationConfig;
        private readonly ObjectContext _objectContext;

        public PayeCreationSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = context.Get<ObjectContext>();
            _payeCreationConfig = context.GetPayeCreationConfig();
        }

        [Given(@"I add non levy declarations")]
        public void GivenIAddNonLevyDeclarations() => AddPaye(_payeCreationConfig.NoOfNonLevy, false);

        [Given(@"I add levy declarations")]
        public void GivenIAddLevyDeclarations() => AddPaye(_payeCreationConfig.NoOfLevy, true);

        private void AddPaye(string noofpayefromconfig, bool isLevy)
        {
            int.TryParse(noofpayefromconfig, out int noofpaye);

            noofpaye = noofpaye < 100 ? noofpaye : 100;

            _objectContext.SetNoOfPayeRequested(noofpaye);

            for (int i = 0; i < noofpaye; i++)
            {
                var mongodbGenerator = AddGatewayUsers(i);
                
                if (isLevy) AddLevy(mongodbGenerator);
            }
        }
                        
        private MongoDbDataGenerator AddGatewayUsers(int index)
        {
            SetUpDataHelpers();

            var mongodbGenerator = new MongoDbDataGenerator(_context);

            mongodbGenerator.AddGatewayUsers(index);

            return mongodbGenerator;
        }

        private void SetUpDataHelpers() => _objectContext.SetDataHelper(new DataHelper(_context.ScenarioInfo.Tags.Contains("levypaye")));

        private void AddLevy(MongoDbDataGenerator mongoDbDataGenerator)
        {
            var (fraction, calculatedAt, levyDeclarations) = LevyDeclarationDataHelper.LevyFunds(_payeCreationConfig.Duration, _payeCreationConfig.LevyPerMonth);

            foreach (var item in levyDeclarations.Rows.ToList().Select(x => x.Values))
            {
                TestContext.Progress.WriteLine($"Levy Declarations: {mongoDbDataGenerator.EmpRef} - {string.Join(",", item.Select(y => y))}");
            }

            mongoDbDataGenerator.AddLevyDeclarations(fraction, calculatedAt, levyDeclarations);
        }
    }
}
