using OpenQA.Selenium;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.UITests.Project.Tests.Pages.Employer
{
    public class ChooseNoOfPositionsPage : RAAV2CSSBasePage
    {
        protected override string PageTitle => "How many positions are there for this apprenticeship?";

        #region Helpers and Context
        private readonly FormCompletionHelper _formCompletionHelper;
        private readonly ScenarioContext _context;

        #endregion

        private By NumberOfPositions => By.CssSelector("#NumberOfPositions");

        public ChooseNoOfPositionsPage(ScenarioContext context) : base(context)
        {
            _context = context;
            _formCompletionHelper = context.Get<FormCompletionHelper>();
            VerifyPage();
        }

        public SelectOrganisationPage ChooseNoOfPositions()
        {
            _formCompletionHelper.EnterText(NumberOfPositions, 2);
            _formCompletionHelper.Click(Continue);
            return new SelectOrganisationPage(_context);
        }
    }
}
