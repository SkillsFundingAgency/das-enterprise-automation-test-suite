using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ConfirmApplicantSuccessStatusPage : Raav2BasePage
    {
        protected override string PageTitle => $"Are you sure you want to make {rAAV2DataHelper.CandidateFullName}'s application {_message}"; 

        protected override By ContinueButton => By.CssSelector("input[type='submit'][value='Continue']");

        private readonly string _message;

        public ConfirmApplicantSuccessStatusPage(ScenarioContext context, string message) : base(context, false)
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
