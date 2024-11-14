using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
using SFA.DAS.ProviderLogin.Service.Project;
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

    public class AddAsATrainingProviderPage(ScenarioContext context, ProviderConfig providerConfig) : PermissionBasePageForTrainingProviderPage(context)
    {
        protected override string PageTitle => $"Add {providerConfig.Name.ToUpperInvariant()} as a training provider";
    }

    public class ManageTrainingProvidersPage(ScenarioContext context) : EmployerProviderRelationshipsBasePage(context)
    {
        protected override string PageTitle => "Manage training providers";

        private static By SetPermissionsLink => By.PartialLinkText("Set permissions");

        private static By ChangePermissionsLink(string ukprn) => By.CssSelector($"a[href*='providers/{ukprn}/changePermissions?']");

        private static By NotificationBanner => By.CssSelector($".govuk-notification-banner");

        private static By TableRows => By.ClassName("govuk-table__row");

        public ManageTrainingProvidersPage VerifyYouHaveAddedNotification()
        {
            VerifyPage(NotificationBanner, "You've added");

            return this;
        }

        public ManageTrainingProvidersPage VerifyYouHaveSetPermissionNotification()
        {
            VerifyPage(NotificationBanner, "You've set permissions for");

            return this;
        }

        public AddAsATrainingProviderPage ViewProviderRequests(ProviderConfig providerConfig, string requestId)
        {
            VerifyFromMultipleElements(TableRows, providerConfig.Name);

            formCompletionHelper.Click(By.CssSelector($"a[href*='{requestId}']"));

            return new(context, providerConfig);
        }

        public EnterYourTrainingProviderNameReferenceNumberUKPRNPage SelectAddATrainingProvider()
        {
            formCompletionHelper.ClickButtonByText(ContinueButton, "Add a training provider");

            return new (context);
        }

        public SetPermissionsForTrainingProviderPage SelectSetPermissions(string orgName)
        {
            if (string.IsNullOrEmpty(orgName))
                formCompletionHelper.ClickElement(SetPermissionsLink);
            else
                tableRowHelper.SelectRowFromTable("Set permissions", orgName);

            return new (context);
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
