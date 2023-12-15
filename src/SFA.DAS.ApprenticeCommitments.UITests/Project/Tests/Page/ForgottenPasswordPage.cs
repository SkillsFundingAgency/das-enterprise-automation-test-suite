using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ForgottenPasswordPage(ScenarioContext context) : ApprenticeCommitmentsBasePage(context)
    {
        protected override string PageTitle => "Forgotten password";
        private static By Email => By.CssSelector("input#Email");

        public ForgottenPasswordConfirmPage SubmitEmailOnForgottenPasswordPage()
        {
            formCompletionHelper.EnterText(Email, objectContext.GetApprenticeEmail());
            formCompletionHelper.ClickButtonByText(SubmitButton, "Submit");
            return new ForgottenPasswordConfirmPage(context);
        }
    }
}
