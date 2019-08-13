using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionApplication
    {
        #region Private Variables
        private readonly JsonConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private ApplicationPage applicationPage;
        #endregion

        public StepDefinitionApplication(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.Get<JsonConfig>();
            _objectContext = context.Get<ObjectContext>();
            applicationPage = new ApplicationPage(_context);
        }

        [Then(@"I verify the content under SO, YOU'VE FOUND THE APPRENTICESHIP section")]
        public void verifySoYouHaveFoundTheApprenticeshipSection()
        {
            applicationPage.verifyContentUnderSoYouHaveFoundTheApprenticeshipSection();
        }

        [Then(@"I verify the content under APPLY FOR THE JOB section")]
        public void verifyApplyForTheJobSection()
        {
            applicationPage.verifyContentUnderApplyForTheJobSection();
        }

        [Then(@"I verify the content under WAIT FOR THE APPLICATIONS section")]
        public void verifyWaitForTheApplicationSection()
        {
            applicationPage.verifyContentUnderWaitForTheApplicationSection();
        }

        [Then(@"I verify the content under IF YOU’RE ON THE SHORTLIST section")]
        public void verifyIfYouAreOnTheShortlistSection()
        {
            applicationPage.verifyContentUnderIfYouAreOnTheShortlistSection();
        }

        [Then(@"I verify the content under TRAINING PROVIDERS section")]
        public void verifyTrainingProvidersSection()
        {
            applicationPage.verifyContentUnderTrainingProvidersSection();
        }

    }
}