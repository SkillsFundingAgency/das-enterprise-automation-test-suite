using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ChooseNoOfPositionsPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "How many positions are there for this apprenticeship?";

        #region Helpers and Context
        private readonly ScenarioContext _context;

        #endregion

        private By NumberOfPositions => By.CssSelector("#NumberOfPositions");

        public ChooseNoOfPositionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
        }

        public SelectOrganisationPage ChooseNoOfPositions()
        {
            EnterNumberOfVacancy();
            return new SelectOrganisationPage(_context);
        }

        public EmployerNamePage ChooseNoOfPositionsAndNavigateToEmployerNamePage()
        {
            EnterNumberOfVacancy();
            return new EmployerNamePage(_context);
        }

        private void EnterNumberOfVacancy()
        {
            formCompletionHelper.EnterText(NumberOfPositions, dataHelper.NumberOfVacancy);
            Continue();
        }
    }
}
