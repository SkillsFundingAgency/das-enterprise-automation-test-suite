using DnsClient;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YouVeSuccessfullyAddedProviderPage : RegistrationBasePage
    {
        protected override string PageTitle => "You've successfully added";

        protected override By ContinueButton => By.XPath("//a[contains(text(),'Continue to set permissions')]");
        private By SaveComebackLaterButton => By.XPath("//a[contains(text(),'Save and come back later')]");
        private By ReturnToYourTrainingProvidersButton => By.XPath("//a[contains(text(),'Return to your training providers')]");

        public YouVeSuccessfullyAddedProviderPage(ScenarioContext context) : base(context) { }

        public SetPermissionsForTrainingProviderPage SelectContinueToSetPermissions()
        {
            Continue();
            return new SetPermissionsForTrainingProviderPage(context);
        }

        public YourProgressHasBeenSavedPage SelectSaveAndComeBackLater()
        {
            formCompletionHelper.Click(SaveComebackLaterButton);
            return new YourProgressHasBeenSavedPage(context);
        }

        public YourTrainingProvidersPage SelectReturnToYourTrainingProviders()
        {
            formCompletionHelper.Click(ReturnToYourTrainingProvidersButton);
            return new YourTrainingProvidersPage(context);
        }


    }
}
