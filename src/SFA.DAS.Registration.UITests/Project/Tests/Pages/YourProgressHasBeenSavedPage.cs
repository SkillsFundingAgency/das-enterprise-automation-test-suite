using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YourProgressHasBeenSavedPage(ScenarioContext context) : RegistrationBasePage(context)
    {
        protected override string PageTitle => "You've successfully added";

        private static By ContinueCreatingYourAccountButton => By.Id("continue-task-list");
        private static By SignOutButton => By.XPath("//button[contains(text(),'Save and come back later')]");

        public CreateYourEmployerAccountPage SelectContinueCreatingYourAccount()
        {
            formCompletionHelper.Click(ContinueCreatingYourAccountButton);
            return new CreateYourEmployerAccountPage(context);
        }

        public YouveLoggedOutPage SelectSignOut()
        {
            formCompletionHelper.Click(SignOutButton);
            return new YouveLoggedOutPage(context);
        }
    }
}
