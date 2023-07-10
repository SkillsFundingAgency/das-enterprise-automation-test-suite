using OpenQA.Selenium;
using Polly;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YourAccountNameHasBeenChangedPage : RegistrationBasePage
    {
        protected override string PageTitle => "Your account name has been set";
        protected override By ContinueButton => By.XPath("//a[contains(text(),'Continue')]");

        public YourAccountNameHasBeenChangedPage(ScenarioContext context) : base(context) => VerifyPage();

        public EmployerAccountCreatedPage ContinueToAcknowledge()
        {
            Continue();
            return new EmployerAccountCreatedPage(context);
        }
         

    }
}
