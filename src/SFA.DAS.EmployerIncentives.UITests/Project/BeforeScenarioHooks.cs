using SFA.DAS.Approvals.UITests.Project.Helpers.SqlHelpers;
using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.EmployerIncentives.UITests.Project.Helpers;
using SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages.VRF;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using System.Linq;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project
{
    [Binding]
    public class BeforeScenarioHooks(ScenarioContext context)
    {
        [BeforeScenario(Order = 41)]
        public void LoginToVRFService()
        {
            var tabHelper = context.Get<TabHelper>();

            context.Set(new EIDataHelper());

            if (context.ScenarioInfo.Tags.Contains("vrfservice"))
            {
                tabHelper.GoToUrl(UrlConfig.EI_VRFUrl);
                new VRFLoginPage(context).SignIntoVRF();
                tabHelper.OpenInNewTab(UrlConfig.EmployerApprenticeshipService_BaseUrl);
            }
        }

        [BeforeScenario(Order = 42)]
        public void SetUpHelpers()
        {
            var objectcontext = context.Get<ObjectContext>();

            var dbConfig = context.Get<DbConfig>();

            context.Set(new EISqlHelper(objectcontext, dbConfig));

            context.Set(new CommitmentsSqlDataHelper(objectcontext, dbConfig));
        }

        [BeforeScenario(Order = 44)]
        public void ResetPeriodEndInProgress() => context.Get<EISqlHelper>().ResetPeriodEndInProgress();
    }
}
