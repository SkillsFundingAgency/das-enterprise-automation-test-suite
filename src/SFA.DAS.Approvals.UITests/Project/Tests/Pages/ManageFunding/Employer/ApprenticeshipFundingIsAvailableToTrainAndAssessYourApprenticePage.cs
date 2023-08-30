using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.ManageFunding.Employer
{
    public class ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage : ApprovalsBasePage
    {
        protected override string PageTitle => "Apprenticeship funding is available to train and assess your apprentice";

        protected override bool TakeFullScreenShot => false;

        private static By YesReserveFundingNowRadioButton => By.CssSelector("label[for=Reserve]");
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button");

        public ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage(ScenarioContext context) : base(context)  { }

        public ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage ClickYesReserveFundingNowRadioButton()
        {
            formCompletionHelper.ClickElement(YesReserveFundingNowRadioButton);
            return new ApprenticeshipFundingIsAvailableToTrainAndAssessYourApprenticePage(context);
        }

        public SuccessfullyReservedFundingPage ClickConfirmButton()
        {
            Continue();
            return new SuccessfullyReservedFundingPage(context);
        }
    }
}