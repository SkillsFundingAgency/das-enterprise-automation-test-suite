using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class EmployerAccountCreatedPage : RegistrationBasePage
    {
        protected override string PageTitle => "Employer account created";
        private static By GoToYourEmployerAccountHomepage => By.LinkText("Go to your employer account homepage");

        public EmployerAccountCreatedPage(ScenarioContext context) : base(context) => VerifyPage();

        public HomePage SelectGoToYourEmployerAccountHomepage()
        {
            formCompletionHelper.Click(GoToYourEmployerAccountHomepage);
            return new HomePage(context);
        }

    }
}
