using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Apprentice;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.Features.Apprentice
{
    [Binding]
    public class CA_AP_09Steps
    {
        private readonly CampaignsStepsHelper _stepsHelper;
        private ApprenticeHubPage _apprenticeHubPage;
        private readonly ScenarioContext _context;
        public CA_AP_09Steps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new CampaignsStepsHelper(context);
        }
        [Given(@"the user navigates to Become An Apprentice page")]
        public void GivenTheUserNavigatesToBecomeAnApprenticePage()
        {
            _stepsHelper.GoToFireItUpHomePage()
                .NavigateToApprenticeshipHubPage();
        }
        [Given(@"Verify the content on Become An Apprentice Page")]
        public void GivenVerifyTheContentOnBecomeAnApprenticePage()
        {
            _apprenticeHubPage = new ApprenticeHubPage(_context);
            _apprenticeHubPage.VerifyBecomeAnApprenticeCard1()
                .VerifyBecomeAnApprenticeCard2()
                .VerifyBecomeAnApprenticeCard3()
                .VerifyBecomeAnApprenticeCard4()
                .VerifyBecomeAnApprenticeCard5()
                .VerifyBecomeAnApprenticeCard6()
                .VerifyBecomeAnApprenticeCard7()
                .VerifyBecomeAnApprenticeCard8()
                .VerifyBecomeAnApprenticeCard9()
                .VerifyBecomeAnApprenticeCard10();
            

        }

    }
}
