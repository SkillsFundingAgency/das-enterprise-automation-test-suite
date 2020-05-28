using SFA.DAS.UI.Framework.TestSupport;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Helpers.DataHelpers;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class MessageForYourTrainingProviderPage : BasePage
    {
        protected override string PageTitle => "Message for your training provider";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;
        private readonly ApprenticeDataHelper _dataHelper;
        #endregion

        private By MessageBox => By.Id("Message");
        private By SendButton => By.Id("continue-button");

        public MessageForYourTrainingProviderPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _dataHelper = context.Get<ApprenticeDataHelper>();
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public CohortSentYourTrainingProviderPage SendInstructionsToProviderForEmptyCohort()
        {
            _formCompletionHelper.EnterText(MessageBox, _dataHelper.MessageToProvider);
            _formCompletionHelper.ClickElement(SendButton);
            return new CohortSentYourTrainingProviderPage(_context);
        }
    }
}