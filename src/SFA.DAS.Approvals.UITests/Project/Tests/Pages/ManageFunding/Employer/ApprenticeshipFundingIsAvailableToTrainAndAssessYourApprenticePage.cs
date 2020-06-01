using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprenticeship funding is available to train and assess your apprentice";
        private By YesReserveFundingNowRadioButton => By.CssSelector("label[for=Reserve]");
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        public ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage(ScenarioContext context) : base(context) => _context = context;

        public ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage ClickYesReserveFundingNowRadioButton()
        {
            formCompletionHelper.ClickElement(YesReserveFundingNowRadioButton);
            return new ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage(_context);
        }

        public SuccessfullyReservedFundingPage ClickConfirmButton()
        {
            Continue();
            return new SuccessfullyReservedFundingPage(_context);
        }
    }
}