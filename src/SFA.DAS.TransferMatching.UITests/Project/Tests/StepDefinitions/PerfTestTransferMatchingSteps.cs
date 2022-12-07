using SFA.DAS.ConfigurationBuilder;
using SFA.DAS.Login.Service;
using SFA.DAS.Registration.UITests.Project.Helpers;
using SFA.DAS.TransferMatching.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using SFA.DAS.Login.Service.Project.Helpers;
using SFA.DAS.TransferMatching.UITests.Project.Helpers;

namespace SFA.DAS.TransferMatching.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class PerfTestTransferMatchingSteps
    {
        private readonly ScenarioContext _context;

        public PerfTestTransferMatchingSteps(ScenarioContext context) => _context = context;

        [Then(@"an employer can apply for '(.*)' pledge")]
        public void ThenAnEmployerCanApplyTimesForGXWBWPledge(string pledgeId)
        {
            new CreateAccountEmployerPortalLoginHelper(_context).Login(_context.GetUser<NonLevyUser>(), false);

            _context.Get<ObjectContext>().SetPledgeDetail(pledgeId);

            for (int i = 0; i < 1; i++)
            {
                _context.Get<TabHelper>().GoToUrl(UrlConfig.TransferMacthingApplyUrl(pledgeId));

                var page = new TransferFundDetailsPage(_context).ApplyForTransferFundsAfterLogin();

                new SubmitApplicationHelper().SubmitApplication(page);
            }
        }
    }
}