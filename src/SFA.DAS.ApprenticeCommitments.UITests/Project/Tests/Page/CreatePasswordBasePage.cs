using OpenQA.Selenium;
using SFA.DAS.UI.Framework.TestSupport;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public abstract class CreatePasswordBasePage(ScenarioContext context) : ApprenticeCommitmentsBasePage(context)
    {
        protected string validPassword = context.GetApprenticeCommitmentsConfig<ApprenticeCommitmentsConfig>().AC_AccountPassword;
        protected override string PageTitle { get; }
        private static By PasswordError => By.XPath("(//ul[@class='govuk-list govuk-error-summary__list']/li)[1]");
        protected static By ConfirmPassword => By.CssSelector("#ConfirmPassword");

        public void EnterMismatchedPasswordsOnCreateLoginDetailsPage(string password)
        {
            SubmitPassword(password, password + 1);
            formCompletionHelper.ClickButtonByText(SubmitButton, "Save and continue");
        }

        protected void SubmitPassword(string password, string confirmpassword, bool clickSubmit = false)
        {
            formCompletionHelper.EnterText(Password, password);
            formCompletionHelper.EnterText(ConfirmPassword, confirmpassword);

            if (clickSubmit)
                formCompletionHelper.ClickButtonByText(SubmitButton, "Submit");
        }
    }
}