using OpenQA.Selenium;
using TechTalk.SpecFlow;


namespace SFA.DAS.RAA_V2.Service.Project.Tests.Pages
{
    public class ConfirmApplicantSucessfulPage : Raav2BasePage
    {
        protected override string PageTitle => "Are you sure you want to tell this applicant that they have been accepted?";

        protected override By ContinueButton => By.CssSelector("input[type='submit'][value='Continue']");

        public ConfirmApplicantSucessfulPage(ScenarioContext context) : base(context) { }

        public ApplicationSuccessfulPage NotifyApplicant()
        {
            SelectRadioOptionByForAttribute("notify-candidate-yes");
            Continue();
            return new ApplicationSuccessfulPage(context);
        }
    }    
}
