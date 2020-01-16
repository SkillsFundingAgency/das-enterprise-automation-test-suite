using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionInterview
    {
        #region Private Variables
        private readonly ScenarioContext _context;
        private readonly InterviewPage interviewPage;
        #endregion

        public StepDefinitionInterview(ScenarioContext context)
        {
            _context = context;
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