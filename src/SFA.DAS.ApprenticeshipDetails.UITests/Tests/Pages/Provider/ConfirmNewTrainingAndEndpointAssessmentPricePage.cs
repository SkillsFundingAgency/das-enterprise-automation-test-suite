using OpenQA.Selenium;
using SFA.DAS.Approvals.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeshipDetails.UITests.Tests.Pages.Provider
{
    public  class ConfirmNewTrainingAndEndpointAssessmentPricePage(ScenarioContext context) : ChangeOfPriceReviewChangeRequestPage(context)
    {
        protected override string PageTitle => "Confirm new training and end-point assessment price";
        private static By SaveButton => By.Id("buttonSubmitForm");

        public ApprenticeDetailsPage EnterTrainingAndEndpointAssessmentPrices(string trainingPrice, string  epa)
        {
            formCompletionHelper.EnterText(TrainingPrice, trainingPrice);
            formCompletionHelper.EnterText(EndpointAssessmentPrice, epa);

            formCompletionHelper.Click(SaveButton);

            return new ApprenticeDetailsPage(context);
        }
    }
}
