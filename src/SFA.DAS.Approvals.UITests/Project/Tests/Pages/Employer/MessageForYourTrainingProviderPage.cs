using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class MessageForYourTrainingProviderPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Message for your training provider";

        protected override bool TakeFullScreenShot => false;

        private By MessageBox => By.Id("Message");
        private By SendButton => By.Id("continue-button");

        public MessageForYourTrainingProviderPage(ScenarioContext context) : base(context)  { }

        public CohortSentYourTrainingProviderPage SendInstructionsToProviderForEmptyCohort()
        {
            formCompletionHelper.EnterText(MessageBox, apprenticeDataHelper.MessageToProvider);
            formCompletionHelper.ClickElement(SendButton);
            return new CohortSentYourTrainingProviderPage(context);
        }
    }
}