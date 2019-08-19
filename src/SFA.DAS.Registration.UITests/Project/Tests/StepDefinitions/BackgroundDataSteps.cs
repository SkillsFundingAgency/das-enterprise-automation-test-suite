using NUnit.Framework;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class BackgroundDataSteps
    {
        private readonly ScenarioContext _context;

        private readonly MongoDbConnectionHelper _mongodbConnectionHelper;

        private readonly MongoDbDataHelper _mongoDbDataHelper;

        private readonly ObjectContext _objectContext;

        public BackgroundDataSteps(ScenarioContext context)
        {
            _context = context;
            _objectContext = _context.Get<ObjectContext>();
            _mongodbConnectionHelper = _context.Get<MongoDbConnectionHelper>();
            _mongoDbDataHelper = _context.Get<MongoDbDataHelper>();
        }

        [Given(@"the following levy declarations with english fraction of (.*) calculated at (.*)")]
        public void GivenTheFollowingLevyDeclarationsWithEnglishFractionOfCalculatedAt(Decimal fraction, DateTime calculatedAt, Table table)
        {
            var set = table.CreateDynamicSet().ToList();

            var mongoDbHelper = new MongoDbHelper(_mongodbConnectionHelper, new DeclarationsDataGenerator(_mongoDbDataHelper, set));

            mongoDbHelper.AsyncCreateData().Wait();

            TestContext.Progress.WriteLine($"Declarations Created for, EmpRef: {_objectContext.GetGatewayPaye()}");

            _context.Set(mongoDbHelper, typeof(DeclarationsDataGenerator).FullName);

            EnglishFraction(fraction, calculatedAt);
        }


        public void EnglishFraction(Decimal fraction, DateTime calculatedAt)
        {
            var mongoDbHelper = new MongoDbHelper(_mongodbConnectionHelper, new EnglishFractionDataGenerator(_mongoDbDataHelper, fraction, calculatedAt));

            mongoDbHelper.AsyncCreateData().Wait();

            TestContext.Progress.WriteLine($"English fraction Created for, EmpRef: {_objectContext.GetGatewayPaye()}");

            _context.Set(mongoDbHelper, typeof(EnglishFractionDataGenerator).FullName);
        }
    }
}
