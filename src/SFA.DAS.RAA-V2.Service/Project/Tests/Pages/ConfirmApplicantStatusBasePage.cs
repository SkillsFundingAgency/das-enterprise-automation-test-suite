using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public abstract class ConfirmApplicantStatusBasePage : Raav2BasePage
    {
        protected override string PageTitle => $"Are you sure you want to tell this applicant that they {_message}?";

        protected override By ContinueButton => By.CssSelector("input[type='submit'][value='Continue']");

        private readonly string _message;

        public ConfirmApplicantStatusBasePage(ScenarioContext context, string message) : base(context, false)
        {
            _message = message;

            VerifyPage();
        }

        protected void NotifyApplicant()
        {
            SelectRadioOptionByForAttribute("notify-candidate-yes");
            Continue();
        }
    }
}
