using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AddAnApprenitcePage : ApprovalsBasePage
    {
        protected override string PageTitle => "Add an apprentice";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        private By StartNowButton => By.CssSelector(".govuk-button--start");

        public AddAnApprenitcePage(ScenarioContext context) : base(context) => _context = context;

        public AddTrainingProviderDetailsPage StartNowToAddTrainingProvider()
        {
            StartNow();
            return new AddTrainingProviderDetailsPage(_context);
        }

        public DoYouWantToUseTransferFundsPage StartNowToCreateApprenticeViaTransfersFunds()
        {
            StartNow();
            return new DoYouWantToUseTransferFundsPage(_context);
        }

        private void StartNow() => formCompletionHelper.ClickElement(StartNowButton);
    }
}