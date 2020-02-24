using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.MongoDb.DataGenerator.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class BackgroundDataSteps
    {
        private readonly ScenarioContext _context;
        private readonly MongoDbDataGenerator _levyDeclarationHelper;
        private readonly LoginCredentialsHelper _loginCredentialsHelper;

        public BackgroundDataSteps(ScenarioContext context)
        {
            _context = context;
            _loginCredentialsHelper = context.Get<LoginCredentialsHelper>();
            _levyDeclarationHelper = new MongoDbDataGenerator(_context);
        }

        [Given(@"the following levy declarations with english fraction of (.*) calculated at (.*)")]
        public void GivenTheFollowingLevyDeclarationsWithEnglishFractionOfCalculatedAt(decimal fraction, DateTime calculatedAt, Table table)
        {
            _levyDeclarationHelper.AddLevyDeclarations(fraction, calculatedAt, table);
            _loginCredentialsHelper.SetIsLevy();
        }

        [Given(@"levy declarations are added for the past (.*) months with levypermonth as (.*)")]
        public void GivenLevyDeclarationsIsAddedForPastMonthsWithLevypermonthAs(string duration, string levyPerMonth)
        {
            var (fraction, calculatedAt, levyDeclarations) = LevyDeclarationDataHelper.LevyFunds(duration, levyPerMonth);
            _levyDeclarationHelper.AddLevyDeclarations(fraction, calculatedAt, levyDeclarations);
            _loginCredentialsHelper.SetIsLevy();
        }
    }
}
