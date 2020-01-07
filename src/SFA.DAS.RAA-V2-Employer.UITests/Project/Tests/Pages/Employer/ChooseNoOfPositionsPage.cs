using OpenQA.Selenium;
using SFA.DAS.RAA_V2.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2_Employer.UITests.Project.Tests.Pages.Employer
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
            formCompletionHelper.EnterText(NumberOfPositions, dataHelper.NumberOfVacancy);
            Continue();
            return new SelectOrganisationPage(_context);
        }
    }
}
