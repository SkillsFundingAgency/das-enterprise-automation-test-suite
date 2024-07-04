using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace SFA.DAS.RAA.Service.Project.Tests.Pages.CreateAdvert
{
    public class SubmitNoOfPositionsPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => isRaaEmployer ? "How many positions are there for this apprenticeship?" : "How many positions are available?";

        private static By NumberOfPositions => By.CssSelector("#NumberOfPositions");

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
            formCompletionHelper.EnterText(NumberOfPositions, RAA.DataGenerator.RAADataHelper.NumberOfVacancy);
            Continue();
            pageInteractionHelper.WaitforURLToChange(urltext);
        }
    }
}
