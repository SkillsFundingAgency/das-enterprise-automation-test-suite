using SFA.DAS.FrameworkHelpers;
using SFA.DAS.IdamsLogin.Service.Project.Helpers;
using SFA.DAS.IdamsLogin.Service.Project.Helpers.DfeSign.User;
using SFA.DAS.Login.Service;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_QA.UITests.Project
{
    [Binding]
    public class RAAV2QAConfigurationSetup
    {
        private readonly ScenarioContext _context;

        public RAAV2QAConfigurationSetup(ScenarioContext context) => _context = context;

        [BeforeScenario(Order = 2)]
        public void SetUpRAAV2QAProjectConfiguration() => _context.SetNonEasLoginUser(SetDfeAdminCredsHelper.SetDfeAdminCreds(_context.Get<FrameworkList<DfeAdminUsers>>(), new VacancyQaUser()));
    }
}
