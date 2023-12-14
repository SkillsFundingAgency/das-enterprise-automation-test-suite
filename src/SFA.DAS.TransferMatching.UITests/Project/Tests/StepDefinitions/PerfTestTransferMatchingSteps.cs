using SFA.DAS.FrameworkHelpers;
using SFA.DAS.Login.Service;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.TransferMatching.UITests.Project.Helpers;
using SFA.DAS.TransferMatching.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class PerfTestTransferMatchingSteps(ScenarioContext context)
    {
        [Then(@"an employer can apply for '(.*)' pledge")]
        public void ThenAnEmployerCanApplyTimesForGXWBWPledge(string pledgeId)
        {
            new CreateAccountEmployerPortalLoginHelper(context).Login(context.GetUser<NonLevyUser>(), false);

            context.Get<ObjectContext>().SetPledgeDetail(pledgeId);

            for (int i = 0; i < 1; i++)
            {
                context.Get<TabHelper>().GoToUrl(UrlConfig.TransferMacthingApplyUrl(pledgeId));

                var page = new TransferFundDetailsPage(context).ApplyForTransferFundsAfterLogin();

                new SubmitApplicationHelper().SubmitApplication(page);
            }
        }
    }
}