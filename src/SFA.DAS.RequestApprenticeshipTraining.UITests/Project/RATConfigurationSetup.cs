using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service.Project;
using SFA.DAS.Login.Service.Project.Helpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RequestApprenticeshipTraining.UITests.Project
{
    [Binding]
    public class RATConfigurationSetup(ScenarioContext context)
    {
        private readonly ConfigSection _configSection = context.Get<ConfigSection>();

        [BeforeScenario(Order = 2)]
        public void SetUpRATConfigConfiguration()
        {
            context.SetEasLoginUser(
            [
                _configSection.GetConfigSection<RATOwnerUser>()
            ]);
        }


    }
}
