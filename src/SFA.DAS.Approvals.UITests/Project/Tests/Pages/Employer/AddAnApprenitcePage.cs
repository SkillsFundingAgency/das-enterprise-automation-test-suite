using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AddAnApprenitcePage(ScenarioContext context) : ApprovalsBasePage(context)
    {
        protected override string PageTitle => "Add an apprentice";

        protected override bool TakeFullScreenShot => false;

        private static By StartNowButton => By.CssSelector(".govuk-button--start");

        public AddTrainingProviderDetailsPage StartNowToAddTrainingProvider()
        {
            StartNow();
            return new AddTrainingProviderDetailsPage(context);
        }

        public DoYouWantToUseTransferFundsPage StartNowToCreateApprenticeViaTransfersFunds()
        {
            StartNow();
            return new DoYouWantToUseTransferFundsPage(context);
        }

        private void StartNow() => formCompletionHelper.ClickElement(StartNowButton);
    }
}