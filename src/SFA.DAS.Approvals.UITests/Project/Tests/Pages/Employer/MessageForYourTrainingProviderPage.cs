using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class MessageForYourTrainingProviderPage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Message for your training provider";

        protected override bool TakeFullScreenShot => false;

        private static By MessageBox => By.Id("Message");
        private static By SendButton => By.Id("continue-button");

        public CohortSentYourTrainingProviderPage SendInstructionsToProviderForEmptyCohort()
        {
            formCompletionHelper.EnterText(MessageBox, apprenticeDataHelper.MessageToProvider);
            formCompletionHelper.ClickElement(SendButton);
            return new CohortSentYourTrainingProviderPage(context);
        }
    }
}