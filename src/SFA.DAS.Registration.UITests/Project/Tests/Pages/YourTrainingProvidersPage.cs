using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages
{
    public class YourTrainingProvidersPage : RegistrationBasePage
    {
        protected override string PageTitle => "Your training providers";

        private static By AddANewTrainingProviderButton => By.LinkText("Add a training provider");
        private static By SetPermissionsLink => By.PartialLinkText("Set permissions");
        private static By ChangePermissionsLink => By.PartialLinkText("Change permissions");

        public YourTrainingProvidersPage(ScenarioContext context) : base(context) { }

        public EnterYourTrainingProviderNameReferenceNumberUKPRNPage SelectAddATrainingProvider()
        {
            formCompletionHelper.ClickElement(AddANewTrainingProviderButton);
            return new EnterYourTrainingProviderNameReferenceNumberUKPRNPage(context);
        }
        public SetPermissionsForTrainingProviderPage SelectSetPermissions(string orgName)
        {
            if (string.IsNullOrEmpty(orgName))
                formCompletionHelper.ClickElement(SetPermissionsLink);
            else
                tableRowHelper.SelectRowFromTable("Set permissions", orgName);

            return new SetPermissionsForTrainingProviderPage(context);
        }

        public SetPermissionsForTrainingProviderPage SelectChangePermissions()
        {
            formCompletionHelper.ClickElement(ChangePermissionsLink);
            return new SetPermissionsForTrainingProviderPage(context);
        }
    }
}
