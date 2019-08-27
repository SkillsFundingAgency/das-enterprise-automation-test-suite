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
        private ApprovalsDataHelper _dataHelper;

        public Hooks(ScenarioContext context)
        {
            _context = context;
            _objectcontext = context.Get<ObjectContext>();
        }

        [BeforeScenario(Order = 22)]
        public void SetUpDataHelpers()
        {
            var random = _context.Get<RandomDataGenerator>();
            _dataHelper = new ApprovalsDataHelper(_objectcontext, random);
            _context.Set(_dataHelper);
        }
    }
}
