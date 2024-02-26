using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Provider;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages
{
    public class ChangeOfPriceCheckYourChangesPage(ScenarioContext context) : ChangePriceNegotiationAmountsPage(context)
    {
        protected override string PageTitle => "Check your changes before sending to the employer";
        private static By SendButton => By.Id("buttonSubmitChangeOfPrice");
        private static By GoBackToEditChangesLink => By.Id("linkGoBackToEdit");
        private static By ChangeTrainingPriceLink => By.Id("linkTrainingprice");
        private static By ChangeEndPointAssessmentPriceLink => By.Id("linkEndPointAssessmentPrice");
        private static By ChangeEffectiveFromDateLink => By.Id("linkEffectiveFromDate");
        private static By ChangeReasonForChangeLink => By.Id("linkReasonForChange");

        public ProviderApprenticeDetailsPage ClickSendButton()
        {
            formCompletionHelper.Click(SendButton);
            return new ProviderApprenticeDetailsPage(context);
        }

    }
}
