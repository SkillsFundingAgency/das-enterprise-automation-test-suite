using NUnit.Framework;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using SFA.DAS.PayeCreation.Tests.Project;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.PayeCreation.Project.Tests.StepDefinitions
{
    public class PayeDetails : PayeCreationConfig
    {
        public string EmpRef { get; set; }
    }

    public class PayeCreationStepshelper(ScenarioContext context, PayeDetails payeDetails)
    {
        private readonly ObjectContext _objectContext = context.Get<ObjectContext>();
        private readonly DbConfig _dbConfig = context.Get<DbConfig>();

        public void AddLevyPaye() => AddPaye(payeDetails.NoOfLevy, true);

        public void AddNonLevyPaye() => AddPaye(payeDetails.NoOfNonLevy, false);

        public void AddAornNonLevyPaye()
        {
            AddPaye(payeDetails.NoOfAornNonLevy, false);

            foreach (var gatewaycred in _objectContext.GetGatewayCreds().ToList())
            {
                var aornNumber = new AornDataHelper().AornNumber;

                new InsertTprDataHelper(_objectContext, _dbConfig).InsertSingleOrgTprData(aornNumber, gatewaycred.Paye);

                _objectContext.UpdateAornNumber(aornNumber, gatewaycred.Index);
            }
        }

        private void AddPaye(string noofpayefromconfig, bool isLevy)
        {
            _ = int.TryParse(noofpayefromconfig, out int noofpaye);

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
            _objectContext.SetDataHelper(new DataHelper(context.ScenarioInfo.Tags));

            var mongodbGenerator = new MongoDbDataGenerator(context, payeDetails.EmpRef);

            mongodbGenerator.AddGatewayUsers(index);

            return mongodbGenerator;
        }

        private void AddLevy(MongoDbDataGenerator mongoDbDataGenerator)
        {
            var (fraction, calculatedAt, levyDeclarations) = LevyDeclarationDataHelper.LevyFunds(payeDetails.Duration, payeDetails.LevyPerMonth);

            foreach (var item in levyDeclarations.Rows.ToList().Select(x => x.Values))
            {
                TestContext.Progress.WriteLine($"Levy Declarations: {mongoDbDataGenerator.EmpRef} - {string.Join(",", item.Select(y => y))}");
            }

            mongoDbDataGenerator.AddLevyDeclarations(fraction, calculatedAt, levyDeclarations);
        }
    }
}
