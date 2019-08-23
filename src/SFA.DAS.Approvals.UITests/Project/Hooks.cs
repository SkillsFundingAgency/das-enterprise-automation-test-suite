using SFA.DAS.Approvals.UITests.Project.Helpers;
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
        private ApprovalsDataHelper _dataHelper;

        public Hooks(ScenarioContext context)
        {
            _context = context;
        }

        [BeforeScenario(Order = 22)]
        public void SetUpDataHelpers()
        {
            var random = _context.Get<RandomDataGenerator>();
            _dataHelper = new ApprovalsDataHelper(random);
            _context.Set(_dataHelper);
        }
    }
}
