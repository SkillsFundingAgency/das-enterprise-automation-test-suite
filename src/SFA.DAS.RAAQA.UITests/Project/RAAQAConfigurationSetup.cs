using SFA.DAS.DfeAdmin.Service.Project.Helpers;
using SFA.DAS.DfeAdmin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAQA.UITests.Project
{
    [Binding]
    public class RAAQAConfigurationSetup(ScenarioContext context)
    {
        [BeforeScenario(Order = 2)]
        public void SetUpRAAQAProjectConfiguration() => context.SetNonEasLoginUser(SetDfeAdminCredsHelper.SetDfeAdminCreds(context.Get<FrameworkList<DfeAdminUsers>>(), new VacancyQaUser()));
    }
}
