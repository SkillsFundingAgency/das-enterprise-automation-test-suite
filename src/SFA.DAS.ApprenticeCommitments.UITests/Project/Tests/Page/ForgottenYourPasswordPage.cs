using OpenQA.Selenium;
using SFA.DAS.ApprenticeCommitments.APITests.Project;
using TechTalk.SpecFlow;

namespace SFA.DAS.ApprenticeCommitments.UITests.Project.Tests.Page
{
    public class ForgottenYourPasswordPage : ApprenticeCommitmentsBasePage
    {
        protected override string PageTitle => "Forgotten password";
        private By NewEmailAddress => By.CssSelector("#Email");
        private By Message => By.CssSelector("#main-content .govuk-body");
        protected override By ContinueButton => By.CssSelector("#main-content .govuk-button[type='submit']");

        public ForgottenYourPasswordPage(ScenarioContext context) : base(context, verifyserviceheader: false)  { }

        public ForgottenYourPasswordPage RequestToUpdatePassword()
        {
            formCompletionHelper.EnterText(NewEmailAddress, objectContext.GetApprenticeEmail());
            Continue();
            VerifyPage(Message, "we have sent an email with instructions to reset your password.");
            return new ForgottenYourPasswordPage(_context);
        }
    }
}
