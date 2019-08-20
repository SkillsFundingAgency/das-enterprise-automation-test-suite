using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class BackgroundDataSteps
    {
        private readonly ScenarioContext _context;
        private readonly MongoDbDataGenerator _levyDeclarationHelper;

        public BackgroundDataSteps(ScenarioContext context)
        {
            _context = context;
            _levyDeclarationHelper = new MongoDbDataGenerator(_context);
        }

        [Given(@"I have levy declarations")]
        public void GivenIHaveLevyDeclarations()
        {
            var table = new Table("Year", "Month", "LevyDueYTD", "LevyAllowanceForFullYear", "SubmissionDate");
            table.AddRow("19-20", "1", "62000", "80000", "2019-05-15");
            _levyDeclarationHelper.AddLevyDeclarations(1.00m, new DateTime(2019, 01, 15), table);
        }


        [Given(@"the following levy declarations with english fraction of (.*) calculated at (.*)")]
        public void GivenTheFollowingLevyDeclarationsWithEnglishFractionOfCalculatedAt(decimal fraction, DateTime calculatedAt, Table table)
        {
            _levyDeclarationHelper.AddLevyDeclarations(fraction, calculatedAt, table);
        }
    }
}
