using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer
{
    public class AddAnApprenitcePage(ScenarioContext context) : ApprovalsApprenticeBasePage(context)
    {
        protected override string PageTitle => "Add a learner or send a learner request";

        protected override bool TakeFullScreenShot => false;

        private static By StartNowButton => By.CssSelector(".govuk-button--start");

        public ChooseYourMainTrainingProviderPage StartNowToAddTrainingProvider()
        {
            StartNow();
            return new ChooseYourMainTrainingProviderPage(context);
        }

        public DoYouWantToUseTransferFundsPage StartNowToCreateApprenticeViaTransfersFunds()
        {
            StartNow();
            return new DoYouWantToUseTransferFundsPage(context);
        }

        public ChooseFundingPage StartNowToSelectFunding()
        {
            StartNow();
            return new ChooseFundingPage(context);
        }

        public YouCannotCreateAnotherFundingReservationPage NonLevyEmployerTriesToAddApprenticeButHitsReservationShutterPage()
        {
            StartNow();
            return new YouCannotCreateAnotherFundingReservationPage(context);
        }

        private void StartNow() => formCompletionHelper.ClickElement(StartNowButton);
    }
}