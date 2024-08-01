using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.DfeAdmin.Service.Project.Helpers;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Login.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project
{
    [Binding]
    public class RATConfigurationSetup(ScenarioContext context)
    {
        [BeforeScenario(Order = 2)]
        public void SetUpRATConfigConfiguration()
        {
            var configSection = context.Get<ConfigSection>();

            context.SetEasLoginUser(
            [
                configSection.GetConfigSection<RATOwnerUser>(),
            ]);

            
        }


    }
}
