using SFA.DAS.ApprenticeCommitments.APITests.Project;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Hooks
{
    [Binding]
    public class BeforeScenarioHooks(ScenarioContext context)
    {
        [BeforeScenario(Order = 42)]
        public void SetUpHelpers()
        {
            var config = context.GetApprenticeCommitmentsConfig<ApprenticeCommitmentsConfig>();

            context.Get<ObjectContext>().SetApprenticePassword(config.AC_AccountPassword);

        }
    }
}