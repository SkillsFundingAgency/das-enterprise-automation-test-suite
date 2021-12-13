using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AddAnApprenitcePage : ApprovalsBasePage
    {
        protected override string PageTitle => "Add an apprentice";

        private By StartNowButton => By.CssSelector(".govuk-button--start");

        public AddAnApprenitcePage(ScenarioContext context) : base(context) { }

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