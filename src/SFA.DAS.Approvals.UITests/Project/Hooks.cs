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
        private ApprenticeDataHelper _datahelper;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _objectcontext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 22)]
        public void SetUpHelpers()
        {
            var random = _context.Get<RandomDataGenerator>();

            _datahelper = new ApprenticeDataHelper(_objectcontext, random);

            _context.Set(_datahelper);

            _context.Set(new EditedApprenticeDataHelper(random, _datahelper));

            _context.Set(new TabHelper(_context.GetWebDriver()));

            var commitmentsDataHelper = new CommitmentsDataHelper(_context.GetApprovalsConfig<ApprovalsConfig>(), _context.Get<SqlDatabaseConnectionHelper>());
            _context.Set(commitmentsDataHelper);
        }

        [AfterScenario(Order = 9)]
        public void AddUln()
        {
            _datahelper.Ulns.ForEach((x) => _objectcontext.Set($"Uln_{x}", x));
        }
    }
}
