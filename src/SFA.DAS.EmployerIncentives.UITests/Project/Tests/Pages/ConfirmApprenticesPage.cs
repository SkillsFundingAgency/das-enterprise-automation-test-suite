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
            formCompletionHelper.ClickButtonByText(ConfirmButton, "Confirm");
            return new DeclarationPage(context);
        }

        public NewLegalAgreementRequiredShutterPage ConfirmApprenticesForVersion4LegalAgreement()
        {
            formCompletionHelper.ClickButtonByText(ConfirmButton, "Confirm");
            return new NewLegalAgreementRequiredShutterPage(context);
        }
    }
}
