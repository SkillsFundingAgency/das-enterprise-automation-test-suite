using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.UI.Framework.TestSupport;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SFA.DAS.Roatp.UITests.Project
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _context;
        private readonly RoatpConfig _config;
        private readonly ObjectContext _objectContext;
        
        public Hooks(ScenarioContext context)
        {
            _context = context;
            _config = context.GetRoatpConfig<RoatpConfig>();
            _objectContext = context.Get<ObjectContext>();
        }
    }
}
