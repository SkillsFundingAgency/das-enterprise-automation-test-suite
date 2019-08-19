using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionWhatAreTheBenefitsForMe
    {
        #region Private Variables
        private readonly JsonConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private WhatAreTheBenefitsForMePage whatAreTheBenefitsForMePage;
        #endregion

        public StepDefinitionWhatAreTheBenefitsForMe(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.Get<JsonConfig>();
            _objectContext = context.Get<ObjectContext>();
            whatAreTheBenefitsForMePage = new WhatAreTheBenefitsForMePage(_context);
        }

        [Then(@"I verify the content under WHAT ARE MY FUTURE PROSPECTS section")]
        public void verifySoYouHaveFoundTheApprenticeshipSection()
        {
            whatAreTheBenefitsForMePage.verifyContentUnderWhatAreMyFutureProspects();
        }

        [Then(@"I verify the content under HOW MUCH CAN YOU EARN section")]
        public void verifyHowMuchCanYouEarnSection()
        {
            whatAreTheBenefitsForMePage.verifyContentUnderHowMuchCanYouEarnSection();
        }

        [Then(@"I verify the content under WHAT WILL MY APPRENTICESHIP COST ME section")]
        public void verifyWhatWillMyApprenticeshipCostMeSection()
        {
            whatAreTheBenefitsForMePage.verifyContentUnderWhatWillMyApprenticeshipCostMeSection();
        }

    }
}