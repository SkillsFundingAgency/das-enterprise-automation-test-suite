using SFA.DAS.Approvals.UITests.Project.Helpers;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectcontext;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _objectcontext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 22)]
        public void SetUpHelpers()
        {
            var random = _context.Get<RandomDataGenerator>();
            var datahelper = new ApprovalsDataHelper(_objectcontext, random);
            _context.Set(datahelper);

            _context.Set(new CocDataHelper(random, datahelper));

            _context.Set(new TabHelper(_context.GetWebDriver()));

            var commitmentsDataHelper = new CommitmentsDataHelper(_context.GetApprovalsConfig<ApprovalsConfig>(), _context.Get<SqlDatabaseConncetionHelper>());
            _context.Set(commitmentsDataHelper);
        }
    }
}
