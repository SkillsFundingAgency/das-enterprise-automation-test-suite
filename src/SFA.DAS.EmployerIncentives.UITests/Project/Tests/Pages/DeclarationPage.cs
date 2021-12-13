using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerIncentives.UITests.Project.Tests.Pages
{
    public class DeclarationPage : EIBasePage
    {
        protected override string PageTitle => "Declaration";

        private By ConfirmButton => By.CssSelector(".govuk-button");

        public DeclarationPage(ScenarioContext context) : base(context)  { }

        public WeNeedYourOrgBankDetailsPage SubmitDeclaration()
        {
            formCompletionHelper.ClickButtonByText(ConfirmButton, "Confirm and submit");
            return new WeNeedYourOrgBankDetailsPage(_context);
        }
    }
}
