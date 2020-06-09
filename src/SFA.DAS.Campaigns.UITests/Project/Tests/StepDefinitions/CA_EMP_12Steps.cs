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

        public CA_EMP_12Steps(ScenarioContext context)
        {
            _context = context;
            _stepsHelper = new CampaignsStepsHelper(context);
        }
        [Then(@"Employer Selects Yes on How do they work page and clicks continue")]
        public void ThenEmployerSelectsYesOnHowDoTheyWorkPageAndClicksContinue()
        {
            _howDoTheyWorkPage = new HowDoTheyWorkPage(_context);
            _howDoTheyWorkPage.ClickContinueButton()
                .ClickHowDoTheyWorkLink()
                .NavigateToFundingAnApprenticeshipPage();
        }
        
        [Then(@"Verifies that correct content is displayed on Funding An Apprentice page")]
        public void ThenVerifiesThatCorrectContentIsDisplayedOnFundingAnApprenticePage()
        {
            fundingAnApprenticeshipPage = new FundingAnApprenticeshipPage(_context);
            fundingAnApprenticeshipPage.CheckForNonLevyContent();
        }
    }
}
