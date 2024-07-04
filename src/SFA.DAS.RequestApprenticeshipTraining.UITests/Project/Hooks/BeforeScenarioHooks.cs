using SFA.DAS.FrameworkHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project.Hooks
{
    [Binding]
    public class BeforeScenarioHooks(ScenarioContext context)
    {
        [BeforeScenario(Order = 46)]
        public void SetUpHelpers()
        {
            
        }
    }
}
