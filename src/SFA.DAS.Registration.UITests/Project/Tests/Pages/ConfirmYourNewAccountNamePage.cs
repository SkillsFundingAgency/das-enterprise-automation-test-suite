using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class ConfirmYourNewAccountNamePage : RegistrationBasePage
    {
        protected override string PageTitle => "Confirm your new account name";
        protected override By ContinueButton => By.XPath("//*[@id=\"accept\"]");

        public ConfirmYourNewAccountNamePage(ScenarioContext context) : base(context) => VerifyPage();

        public YouAccountNameHasBeenChangeToPage ContinueToAcknowledge(string newAccountName)
        {
            Continue();
            return new YouAccountNameHasBeenChangeToPage(context, newAccountName);
        }
    }
}