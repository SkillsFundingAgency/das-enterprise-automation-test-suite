using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class ConfirmApprenticesPage : EIBasePage
    {
        protected override string PageTitle => "Confirm apprentices";

        private By ConfirmButton => By.CssSelector(".govuk-button");

        public ConfirmApprenticesPage(ScenarioContext context) : base(context)  { }

        public DeclarationPage ConfirmApprentices()
        {
            ClickConfirmButton();
            return new DeclarationPage(context);
        }

        public NewLegalAgreementRequiredShutterPage ConfirmApprenticesForVersion4LegalAgreement()
        {
            ClickConfirmButton();
            return new NewLegalAgreementRequiredShutterPage(context);
        }

        private void ClickConfirmButton() => formCompletionHelper.ClickButtonByText(ConfirmButton, "Confirm");
    }
}
