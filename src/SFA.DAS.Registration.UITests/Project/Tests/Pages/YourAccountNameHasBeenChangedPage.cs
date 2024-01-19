using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YourAccountNameHasBeenChangedPage : RegistrationBasePage
    {
        protected override string PageTitle => "You have confirmed your Account name";
        protected override By ContinueButton => By.XPath("//a[contains(text(),'Continue')]");

        public YourAccountNameHasBeenChangedPage(ScenarioContext context) : base(context) => VerifyPage();

        public CreateYourEmployerAccountPage ContinueToAcknowledge()
        {
            Continue();
            return new CreateYourEmployerAccountPage(context);
        }


    }
}
