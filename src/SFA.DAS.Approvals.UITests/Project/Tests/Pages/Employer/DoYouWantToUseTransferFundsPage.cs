using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class DoYouWantToUseTransferFundsPage : ApprovalsBasePage
    {
        protected override string PageTitle => "Do you want to use transfer funds to pay for this training?";
        private By CohortFundingOptions => By.CssSelector(".govuk-radios__item");
        protected override By ContinueButton => By.Id("submit-transfer-connection");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public DoYouWantToUseTransferFundsPage(ScenarioContext context) : base(context) => _context = context;

        public AddTrainingProviderDetailsPage SelectYesIWantToUseTransferFunds(string organisationName)
        {
            formCompletionHelper.SelectRadioOptionByText(CohortFundingOptions, $"Yes, I will use transfer funds from {organisationName}");
            Continue();
            return new AddTrainingProviderDetailsPage(_context);
        }
    }
}