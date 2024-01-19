using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class ConfirmTrainingProviderPage(ScenarioContext context) : Raav2BasePage(context)
    {
        protected override string PageTitle => "Confirm the training provider";

        protected override By ContinueButton => By.CssSelector("[data-automation='btn-continue']");

        public SubmitNoOfPositionsPage ConfirmTrainingProviderAndContinue()
        {
            Continue();
            return new SubmitNoOfPositionsPage(context);
        }

        public SummaryOfTheApprenticeshipPage ConfirmProviderAndContinueToSummaryPage()
        {
            Continue();
            return new SummaryOfTheApprenticeshipPage(context);
        }
    }
}
