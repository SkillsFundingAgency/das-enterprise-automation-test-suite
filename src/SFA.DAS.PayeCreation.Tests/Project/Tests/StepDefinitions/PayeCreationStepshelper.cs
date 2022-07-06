using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.MongoDb.DataGenerator;
using TechTalk.SpecFlow;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using NUnit.Framework;
using System.Linq;
using SFA.DAS.PayeCreation.Tests.Project;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.FrameworkHelpers;

namespace SFA.DAS.PayeCreation.Project.Tests.StepDefinitions
{
    public class PayeDetails : PayeCreationConfig
    {
        public string EmpRef { get; set; }
    }

    public class PayeCreationStepshelper
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly PayeDetails _payeDetails;
        private readonly DbConfig _dbConfig;

        public PayeCreationStepshelper(ScenarioContext context, PayeDetails payeDetails)
        {
            _context = context;
            _dbConfig = context.Get<DbConfig>();
            _objectContext = context.Get<ObjectContext>();
            _payeDetails = payeDetails;
        }

        public void AddLevyPaye() => AddPaye(_payeDetails.NoOfLevy, true);

        public void AddNonLevyPaye() => AddPaye(_payeDetails.NoOfNonLevy, false);

        public void AddAornNonLevyPaye()
        {
            AddPaye(_payeDetails.NoOfAornNonLevy, false);

            foreach (var gatewaycred in _objectContext.GetGatewayCreds().ToList())
            {
                var aornNumber = new AornDataHelper().AornNumber;

                InsertTprDataHelper.InsertSingleOrgTprData(_dbConfig.TPRDbConnectionString, aornNumber, gatewaycred.Paye);
                
                _objectContext.UpdateAornNumber(aornNumber, gatewaycred.Index);
            }
        }

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
            _objectContext.SetDataHelper(new DataHelper(_context.ScenarioInfo.Tags));

            var mongodbGenerator = new MongoDbDataGenerator(_context, _payeDetails.EmpRef);

            mongodbGenerator.AddGatewayUsers(index);

            return mongodbGenerator;
        }

        private void AddLevy(MongoDbDataGenerator mongoDbDataGenerator)
        {
            var (fraction, calculatedAt, levyDeclarations) = LevyDeclarationDataHelper.LevyFunds(_payeDetails.Duration, _payeDetails.LevyPerMonth);

            foreach (var item in levyDeclarations.Rows.ToList().Select(x => x.Values))
            {
                TestContext.Progress.WriteLine($"Levy Declarations: {mongoDbDataGenerator.EmpRef} - {string.Join(",", item.Select(y => y))}");
            }

            mongoDbDataGenerator.AddLevyDeclarations(fraction, calculatedAt, levyDeclarations);
        }
    }
}
