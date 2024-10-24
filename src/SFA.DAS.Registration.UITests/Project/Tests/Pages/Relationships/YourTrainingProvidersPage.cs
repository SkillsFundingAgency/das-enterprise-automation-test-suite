using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.Registration.UITests.Project.Tests.Pages.Relationships
{
    public enum AddApprenticePermissions
    {
        [ToString("Yes, employer will review records")]
        AllowConditional,
        [ToString("No")]
        DoNotAllow
    }

    public enum RecruitApprenticePermissions
    {
        [ToString("Yes")]
        Allow,
        [ToString("Yes, employer will review adverts")]
        AllowConditional,
        [ToString("No")]
        DoNotAllow
    }

    public class YourTrainingProvidersPage(ScenarioContext context) : EmployerProviderRelationshipsBasePage(context)
    {
        protected override string PageTitle => "Manage training providers";

        private static By SetPermissionsLink => By.PartialLinkText("Set permissions");

        private static By ChangePermissionsLink(string ukprn) => By.CssSelector($"a[href*='providers/{ukprn}/changePermissions?']");

        private static By NotificationBanner => By.CssSelector($".govuk-notification-banner");

        public YourTrainingProvidersPage VerifyYouHaveAddedNotification()
        {
            VerifyPage(NotificationBanner, "You've added");

            return this;
        }

        public YourTrainingProvidersPage VerifyYouHaveSetPermissionNotification()
        {
            VerifyPage(NotificationBanner, "You've set permissions for");

            return this;
        }

        public EnterYourTrainingProviderNameReferenceNumberUKPRNPage SelectAddATrainingProvider()
        {
            formCompletionHelper.ClickButtonByText(ContinueButton, "Add a training provider");

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

        public SetPermissionsForTrainingProviderPage SelectChangePermissions(string ukprn)
        {
            formCompletionHelper.ClickElement(ChangePermissionsLink(ukprn));

            return new SetPermissionsForTrainingProviderPage(context);
        }

        public CreateYourEmployerAccountPage GoBackToCreateYourEmployerAccountPage()
        {
            formCompletionHelper.Click(BackLink);
            return new CreateYourEmployerAccountPage(context);
        }
    }
}
