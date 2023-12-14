using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YouVeSuccessfullySetProviderPermissionsPage(ScenarioContext context) : RegistrationBasePage(context)
    {
        protected override string PageTitle => "You've successfully set provider permissions";

        protected override By ContinueButton => By.Id("submit-training-provider-success");

        public EmployerAccountCreatedPage ContinueToAccountCreationConfirmationPage()
        {
            Continue();
            return new EmployerAccountCreatedPage(context);
        }
    }
}
