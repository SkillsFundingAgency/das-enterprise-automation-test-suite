using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class ConfirmRequestForChangeOfProviderPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Are you sure you want to send this request to";
        protected override By ContinueButton => By.Id("continue-button");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ConfirmRequestForChangeOfProviderPage(ScenarioContext context) : base(context) => _context = context;

        public ChangeOfTrainingProviderRequestedPage SelectYesAndContinue()
        {
            formCompletionHelper.SelectRadioOptionByText("Yes");
            Continue();
            return new ChangeOfTrainingProviderRequestedPage(_context);
        }
    }
}
