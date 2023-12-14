using SFA.DAS.DfeAdmin.Service.Project.Helpers;
using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_QA.UITests.Project
{
    [Binding]
    public class RAAV2QAConfigurationSetup(ScenarioContext context)
    {
        [BeforeScenario(Order = 2)]
        public void SetUpRAAV2QAProjectConfiguration() => context.SetNonEasLoginUser(SetDfeAdminCredsHelper.SetDfeAdminCreds(context.Get<FrameworkList<DfeAdminUsers>>(), new VacancyQaUser()));
    }
}
