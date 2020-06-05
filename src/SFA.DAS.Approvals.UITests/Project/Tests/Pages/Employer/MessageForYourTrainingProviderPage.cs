using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class MessageForYourTrainingProviderPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Message for your training provider";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By MessageBox => By.Id("Message");
        private By SendButton => By.Id("continue-button");

        public MessageForYourTrainingProviderPage(ScenarioContext context) : base(context) => _context = context;

        public CohortSentYourTrainingProviderPage SendInstructionsToProviderForEmptyCohort()
        {
            formCompletionHelper.EnterText(MessageBox, apprenticeDataHelper.MessageToProvider);
            formCompletionHelper.ClickElement(SendButton);
            return new CohortSentYourTrainingProviderPage(_context);
        }
    }
}