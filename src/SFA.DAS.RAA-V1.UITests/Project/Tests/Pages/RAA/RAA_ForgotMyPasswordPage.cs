using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V1.UITests.Project.Tests.Pages.RAA
{
    public class RAA_ForgotMyPasswordPage : RAAV1BasePage
    {
        protected override By PageHeader => By.CssSelector(".pageTitle");

        protected override string PageTitle => "Forgotten Password";

        private By UsernameField => By.Id("username");

        private By SubmitButton => By.CssSelector("button.btn.btn-ml");

        private By FormInfo => By.CssSelector("p.form-info");
        
        public RAA_ForgotMyPasswordPage(ScenarioContext context) : base(context) { }
       
        public RAA_ForgotMyPasswordPage ResetPassword()
        {
            formCompletionHelper.EnterText(UsernameField, rAAV1Config.RecruitUserName);
            formCompletionHelper.Click(SubmitButton);
            return this;
        }

        public string FormInfoText()
        {
            pageInteractionHelper.WaitforURLToChange("/passwordRecoveryEmailSent/"); 
            return pageInteractionHelper.GetText(FormInfo);
        }
    }
}
