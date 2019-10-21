using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionWhatAreTheBenefitsForMe
    {
        #region Private Variables
        private readonly ScenarioContext _context;
        private readonly WhatAreTheBenefitsForMePage whatAreTheBenefitsForMePage;
        #endregion

        public StepDefinitionWhatAreTheBenefitsForMe(ScenarioContext context)
        {
            _context = context;
            whatAreTheBenefitsForMePage = new WhatAreTheBenefitsForMePage(_context);
        }

        [Then(@"I verify the content under WHAT ARE MY FUTURE PROSPECTS section")]
        public void VerifySoYouHaveFoundTheApprenticeshipSection()
        {
            whatAreTheBenefitsForMePage.VerifyContentUnderWhatAreMyFutureProspects();
        }

        [Then(@"I verify the content under HOW MUCH CAN YOU EARN section")]
        public void VerifyHowMuchCanYouEarnSection()
        {
            whatAreTheBenefitsForMePage.VerifyContentUnderHowMuchCanYouEarnSection();
        }

        [Then(@"I verify the content under WHAT WILL MY APPRENTICESHIP COST ME section")]
        public void VerifyWhatWillMyApprenticeshipCostMeSection()
        {
            whatAreTheBenefitsForMePage.VerifyContentUnderWhatWillMyApprenticeshipCostMeSection();
        }

    }
}