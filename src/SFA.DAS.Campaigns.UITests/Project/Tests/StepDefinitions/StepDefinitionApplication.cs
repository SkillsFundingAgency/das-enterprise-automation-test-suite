using SFA.DAS.Campaigns.UITests.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    [Binding]
    public class StepDefinitionApplication
    {
        #region Private Variables
        private readonly ScenarioContext _context;
        private readonly ApplicationPage applicationPage;
        #endregion

        public StepDefinitionApplication(ScenarioContext context)
        {
            _context = context;
            applicationPage = new ApplicationPage(_context);
        }

        [Then(@"I verify the content under SO, YOU'VE FOUND THE APPRENTICESHIP section")]
        public void VerifySoYouHaveFoundTheApprenticeshipSection()
        {
            applicationPage.VerifyContentUnderSoYouHaveFoundTheApprenticeshipSection();
        }

        [Then(@"I verify the content under APPLY FOR THE JOB section")]
        public void VerifyApplyForTheJobSection()
        {
            applicationPage.VerifyContentUnderApplyForTheJobSection();
        }

        [Then(@"I verify the content under WAIT FOR THE APPLICATIONS section")]
        public void VerifyWaitForTheApplicationSection()
        {
            applicationPage.VerifyContentUnderWaitForTheApplicationSection();
        }

        [Then(@"I verify the content under IF YOU’RE ON THE SHORTLIST section")]
        public void VerifyIfYouAreOnTheShortlistSection()
        {
            applicationPage.VerifyContentUnderIfYouAreOnTheShortlistSection();
        }

        [Then(@"I verify the content under TRAINING PROVIDERS section")]
        public void VerifyTrainingProvidersSection()
        {
            applicationPage.VerifyContentUnderTrainingProvidersSection();
        }

    }
}