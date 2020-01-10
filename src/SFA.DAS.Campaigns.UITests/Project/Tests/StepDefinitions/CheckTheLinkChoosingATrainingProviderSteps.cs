using NUnit.Framework;
using SFA.DAS.Campaigns.UITests.Project;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests
{
    [Binding]
    public class CheckTheLinkChoosingATrainingProviderSteps
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private FireItUpHomePage fireItUpHomePage;
        private EmployerMenuOptionPage employerMenuOptionPage;
        private ChoosingATrainingProviderPage choosingATrainingProviderPage;
        #endregion

        public CheckTheLinkChoosingATrainingProviderSteps(ScenarioContext context)
        {
            _context = context;
            _configuration = context.GetCampaignsProjectConfig<CampaignsConfig>();
        }

        [Given(@"I launch Choosing A Training Provider page")]
        public void GivenILaunchChoosingATrainingProviderPage()
        {
            fireItUpHomePage = new FireItUpHomePage(_context);
            fireItUpHomePage.FocusOnEmployerSettingUpMenue();
            TestContext.Progress.WriteLine("Navigating to Choosing a Training Provider page");
            fireItUpHomePage.ClickChoosingATrainingProviderLink();
        }
        
        [Then(@"I verify the title for Choosing A Training Provider page")]
        public void ThenIVerifyTheTitleForChoosingATrainingProviderPage()
        {
            choosingATrainingProviderPage = new ChoosingATrainingProviderPage(_context);
            choosingATrainingProviderPage.CheckChoosingATrainingProviderTitle();
        }
    }
}
