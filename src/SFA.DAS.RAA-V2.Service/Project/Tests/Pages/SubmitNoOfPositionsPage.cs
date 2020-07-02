using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class SubmitNoOfPositionsPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "How many positions are there for this apprenticeship?";

        #region Helpers and Context
        private readonly ScenarioContext _context;

        #endregion

        private By NumberOfPositions => By.CssSelector("#NumberOfPositions");
        
        public SubmitNoOfPositionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public SelectOrganisationPage SubmitNoOfPositionsAndNavigateToSelectOrganisationPage()
        {
            EnterNumberOfPositionsAndContinue();
            return new SelectOrganisationPage(_context);
        }

        public void EnterNumberOfPositionsAndContinue()
        {
            formCompletionHelper.EnterText(NumberOfPositions, rAAV2DataHelper.NumberOfVacancy);
            Continue();
            pageInteractionHelper.WaitforURLToChange("employer");
        }
    }
}
