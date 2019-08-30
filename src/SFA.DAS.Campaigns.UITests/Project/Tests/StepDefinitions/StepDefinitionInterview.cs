using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using SFA.DAS.UI.Framework.TestSupport;
using OpenQA.Selenium;
using SFA.DAS.UI.Framework;
using TechTalk.SpecFlow;
using TestContext = NUnit.Framework.TestContext;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionInterview
    {
        #region Private Variables
        private readonly CampaignsConfig _configuration;
        private readonly ScenarioContext _context;
        private readonly ObjectContext _objectContext;
        private readonly IWebDriver _webDriver;
        private InterviewPage interviewPage;
        #endregion

        public StepDefinitionInterview(ScenarioContext context)
        {
            _context = context;
            _webDriver = context.Get<IWebDriver>("webdriver");
            _configuration = context.GetProjectConfig<CampaignsConfig>();
            _objectContext = context.Get<ObjectContext>();
            interviewPage = new InterviewPage(_context);
        }

        [Then(@"I verify the content under The Interview Process section")]
        public void VerifyTheInterveiwProcessSection()
        {
            interviewPage.VerifyContentUnderInterviewSection();
        }

        [Then(@"I verify the content under Before Your Interview section")]
        public void VerifyBeforeYourInterviewSection()
        {
            interviewPage.VerifyContentUnderBeforeYourInterviewSection();
        }

        [Then(@"I verify the content under Day Of The Interview section")]
        public void VerifyDayOfTheInterviewSection()
        {
            interviewPage.VerifyContentUnderDayOfTheInterviewSection();
        }

    }
}