using OpenQA.Selenium;
using SFA.DAS.Campaigns.UITests.Project.Tests.Pages.Employer;
using TechTalk.SpecFlow;

namespace SFA.DAS.Campaigns.UITests.Project.Tests.StepDefinitions
{
    public class RemoveConfirmPage : EmployerBasePage
    {
        protected override string PageTitle => "REMOVE CONFIRMATION";

        #region Helpers and Context
        private readonly ScenarioContext _context;
        #endregion

        #region Page onjects
        private By _removeButton = By.Id("continueButton");
        #endregion

        public RemoveConfirmPage(ScenarioContext context) : base(context) => _context = context;

        public EmployerFavouritesPage ClickConfirmRemoveButton()
        {
            formCompletionHelper.ClickElement(_removeButton);
            return new EmployerFavouritesPage(_context);
        }
    }
}