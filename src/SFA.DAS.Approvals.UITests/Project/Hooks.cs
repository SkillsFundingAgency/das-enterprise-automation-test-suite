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
            var dataHelper = new ApprovalsDataHelper(_objectcontext, random);
            _context.Set(dataHelper);

            var tabhelper = new TabHelper(_context.GetWebDriver());
            _context.Set(tabhelper);
        }
    }
}
