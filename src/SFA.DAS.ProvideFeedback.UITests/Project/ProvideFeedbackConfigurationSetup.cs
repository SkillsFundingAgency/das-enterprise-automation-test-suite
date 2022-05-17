using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.MongoDb.DataGenerator;
using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SFA.DAS.ProvideFeedback.UITests.Project
{
    [Binding]
    public class ProvideFeedbackConfigurationSetup
    {
        private readonly ScenarioContext _context;
        private readonly IConfigSection _configSection;

        public ProvideFeedbackConfigurationSetup(ScenarioContext context)
        {
            _context = context;
            _configSection = context.Get<IConfigSection>();
        }

        [BeforeScenario(Order = 2)]
        public void SetUpProvideFeedbackConfigConfiguration()
        {
            _context.SetProvideFeedbackConfig(_configSection.GetConfigSection<ProvideFeedbackConfigurationSetup>());

            _context.SetEasLoginUser(new List<EasAccountUser>()
            {
                _configSection.GetConfigSection<ProvideFeedbackUser>(),
            });
        }
    }
}
