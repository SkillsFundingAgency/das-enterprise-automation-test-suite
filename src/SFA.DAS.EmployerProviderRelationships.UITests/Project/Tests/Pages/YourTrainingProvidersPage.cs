using OpenQA.Selenium;
using SFA.DAS.ProviderLogin.Service.Project;
using SFA.DAS.Registration.UITests.Project.Tests.Pages;
using SFA.DAS.UI.FrameworkHelpers;
using TechTalk.SpecFlow;

namespace SFA.DAS.EmployerProviderRelationships.UITests.Project.Tests.Pages
{
    public abstract class EmployerProviderRelationshipsBasePage : RegistrationBasePage
    {
        protected EmployerProviderRelationshipsBasePage(ScenarioContext context) : base(context) => VerifyPage();

        protected override By ContinueButton => By.CssSelector("button[id='continue'][type='submit']");
    }

    public class YourTrainingProvidersPage(ScenarioContext context) : EmployerProviderRelationshipsBasePage(context)
    {
        protected override string PageTitle => "Your training providers";
        private static By SetPermissionsLink => By.PartialLinkText("Set permissions");
        private static By ChangePermissionsLink => By.PartialLinkText("Change permissions");

        private static By NotificationBanner => By.CssSelector($".govuk-notification-banner");

        public YourTrainingProvidersPage VerifyYouHaveAddedNotification()
        {
            VerifyPage(NotificationBanner, "You've added");

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

        public SetPermissionsForTrainingProviderPage SelectChangePermissions()
        {
            formCompletionHelper.ClickElement(ChangePermissionsLink);
            return new SetPermissionsForTrainingProviderPage(context);
        }

        public CreateYourEmployerAccountPage GoBackToCreateYourEmployerAccountPage()
        {
            formCompletionHelper.Click(BackLink);
            return new CreateYourEmployerAccountPage(context);
        }
    }

    public class EnterYourTrainingProviderNameReferenceNumberUKPRNPage(ScenarioContext context) : EmployerProviderRelationshipsBasePage(context)
    {
        protected override string PageTitle => "name or reference number (UKPRN)";

        private static By UKProviderReferenceNumberText => By.CssSelector("input[id='SearchTerm']");
        private static By FirstOption => By.CssSelector("[id='SearchTerm__option--0']");

        public SetPermissionsForTrainingProviderPage SearchForATrainingProvider(ProviderConfig providerConfig)
        {
            formCompletionHelper.EnterText(UKProviderReferenceNumberText, providerConfig.Name);

            pageInteractionHelper.IsElementPresent(FirstOption);

            pageInteractionHelper.WaitForElementToChange(FirstOption, AttributeHelper.InnerText, providerConfig.Ukprn);

            formCompletionHelper.ClickElement(() => pageInteractionHelper.FindElement(FirstOption));

            Continue();

            return new SetPermissionsForTrainingProviderPage(context);
        }
    }

    public class SetPermissionsForTrainingProviderPage(ScenarioContext context) : EmployerProviderRelationshipsBasePage(context)
    {
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");
        protected override string PageTitle => "set permissions";
        protected static By ApprenticeAllowRadioOption => By.Id("addRecords-1");
        protected static By ApprenticeDoNotAllowRadioOption => By.Id("addRecords-2");

        protected static By RecruitAllowRadioOption => By.Id("recruitApprentices-1");
        protected static By RecruitAllowConditionalRadioOption => By.Id("recruitApprentices-2");
        protected static By RecruitDoNotAllowRadioOption => By.Id("recruitApprentices-3");

        public YourTrainingProvidersPage SetPermissions(AddApprenticePermissions cohortpermission, RecruitApprenticePermissions recruitpermission)
        {
            return SetAddApprentice(cohortpermission).SetRecruitApprentice(recruitpermission);
        }

        private SetPermissionsForTrainingProviderPage SetAddApprentice(AddApprenticePermissions permission)
        {
            SetPermissionsForTrainingProviderPage Continue(By by)
            {
                javaScriptHelper.ClickElement(by);
                return this;
            }

            return permission switch
            {
                AddApprenticePermissions.Allow => Continue(ApprenticeAllowRadioOption),
                _ => Continue(ApprenticeDoNotAllowRadioOption),
            };
        }

        private YourTrainingProvidersPage SetRecruitApprentice(RecruitApprenticePermissions permission)
        {
            YourTrainingProvidersPage ContinueToConfirm(By by)
            {
                javaScriptHelper.ClickElement(by);
                formCompletionHelper.ClickButtonByText(ContinueButton, "Confirm");
                return new YourTrainingProvidersPage(context);
            }

            return permission switch
            {
                RecruitApprenticePermissions.Allow => ContinueToConfirm(RecruitAllowRadioOption),
                RecruitApprenticePermissions.AllowConditional => ContinueToConfirm(RecruitAllowConditionalRadioOption),
                _ => ContinueToConfirm(RecruitDoNotAllowRadioOption),
            };
        }
    }
}
