using SFA.DAS.Campaigns.UITests.Project.Helpers;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using System;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests
{
    [Binding]
    public class CA_EMP_12Steps

    {
        private readonly CampaignsStepsHelper _stepsHelper;
        private readonly ScenarioContext _context;
        private HowDoTheyWorkPage _howDoTheyWorkPage;
        private FundingAnApprenticeshipPage fundingAnApprenticeshipPage;
        private NonLevyPayingEmployerPage fundingAnApprenticeshipForNonLevyEmployerPage;

        public CA_EMP_12Steps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new CampaignsStepsHelper(context);
        }
        [Then(@"Employer selects Levy Paying and continues")]
        public void ThenEmployerSelectsLevyPayingAndContinues()
        {
            fundingAnApprenticeshipPage = new FundingAnApprenticeshipPage(_context);
            fundingAnApprenticeshipPage.NavigateToLevyEmployerPage();
        }

        [Then(@"Employer selects non Levy Paying and continues")]
        public void ThenEmployerSelectsNonLevyPayingAndContinues()
        {
            fundingAnApprenticeshipPage = new FundingAnApprenticeshipPage(_context);
            fundingAnApprenticeshipPage.NavigateToNonLevyEmployerPage();
        }
        [Then(@"Employer selects non sure Levy Paying and continues")]
        public void ThenEmployerSelectsNonSureLevyPayingAndContinues()
        {
            fundingAnApprenticeshipPage = new FundingAnApprenticeshipPage(_context);
            fundingAnApprenticeshipPage.NavigateToNotSureLevyEmployerPage();
        }
    }
}
