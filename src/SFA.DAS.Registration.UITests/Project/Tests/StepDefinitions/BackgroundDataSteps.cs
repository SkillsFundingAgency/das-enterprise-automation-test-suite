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

        [Given(@"I have levy declarations for past (.*) months")]
        public void GivenIHaveLevyDeclarationsForPastMonths(int p0)
        {
            throw new PendingStepException();
        }

        [Given(@"the following levy declarations with english fraction of (.*) calculated at (.*)")]
        public void GivenTheFollowingLevyDeclarationsWithEnglishFractionOfCalculatedAt(decimal fraction, DateTime calculatedAt, Table table)
        {
            new MongoDbDataGenerator(_context).AddLevyDeclarations(fraction, calculatedAt, table);
        }
    }
}
