using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class DeclarationPage : EIBasePage
    {
        protected override string PageTitle => "Declaration";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        private By ConfirmButton => By.CssSelector(".govuk-button");

        public DeclarationPage(ScenarioContext context) : base(context) => _context = context;

        public AddBankDetailsPage SubmitDeclaration()
        {
            formCompletionHelper.ClickButtonByText(ConfirmButton, "Confirm and submit");
            return new AddBankDetailsPage(_context);
        }
    }
}
