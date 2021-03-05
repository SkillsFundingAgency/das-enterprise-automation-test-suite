using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ConfirmApprenticesPage : EIBasePage
    {
        protected override string PageTitle => "Confirm apprentices";

        #region Locators
        private readonly ScenarioContext _context;
        #endregion

        private By ConfirmButton => By.CssSelector(".govuk-button");

        public ConfirmApprenticesPage(ScenarioContext context) : base(context) => _context = context;

        public DeclarationPage ConfirmApprentices()
        {
            formCompletionHelper.ClickButtonByText(ConfirmButton, "Confirm");
            return new DeclarationPage(_context);
        }

        public NewLegalAgreementRequiredPage ConfirmApprenticesForVersion4LegalAgreement()
        {
            formCompletionHelper.ClickButtonByText(ConfirmButton, "Confirm");
            return new NewLegalAgreementRequiredPage(_context);
        }
    }
}
