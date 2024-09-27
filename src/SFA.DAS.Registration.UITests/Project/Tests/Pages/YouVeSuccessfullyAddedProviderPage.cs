using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YouVeSuccessfullyAddedProviderPage(ScenarioContext context) : RegistrationBasePage(context)
    {
        protected override string PageTitle => "You've successfully added";

        private static By SaveComebackLaterButton => By.XPath("//a[contains(text(),'Save and come back later')]");

        public YourProgressHasBeenSavedPage SelectSaveAndComeBackLater()
        {
            formCompletionHelper.Click(SaveComebackLaterButton);
            return new YourProgressHasBeenSavedPage(context);
        }
    }
}
