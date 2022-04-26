using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages.CreateAdvert
{
    public class SubmitNoOfPositionsPage : Raav2BasePage
    {
        protected override string PageTitle => isRaaV2Employer ? "How many positions are there for this apprenticeship?" : "How many positions are available?";

        private By NumberOfPositions => By.CssSelector("#NumberOfPositions");

        public SubmitNoOfPositionsPage(ScenarioContext context) : base(context) { }

        public ChooseApprenticeshipLocationPage SubmitNoOfPositionsAndNavigateToChooseLocationPage()
        {
            EnterNumberOfPositionsAndContinue("location");
            return new ChooseApprenticeshipLocationPage(context);
        }

        public SelectOrganisationPage SubmitNoOfPositionsAndNavigateToSelectOrganisationPage()
        {
            EnterNumberOfPositionsAndContinue();
            return new SelectOrganisationPage(context);
        }

        public void EnterNumberOfPositionsAndContinue() => EnterNumberOfPositionsAndContinue("employer");

        public void EnterNumberOfPositionsAndContinue(string urltext)
        {
            formCompletionHelper.EnterText(NumberOfPositions, rAAV2DataHelper.NumberOfVacancy);
            Continue();
            pageInteractionHelper.WaitforURLToChange(urltext);
        }
    }
}
