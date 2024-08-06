using NUnit.Framework;
using OpenQA.Selenium;
using SFA.DAS.FrameworkHelpers;
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

    public class EnterYourTrainingProviderNameReferenceNumberUKPRNPage(ScenarioContext context) : EmployerProviderRelationshipsBasePage(context)
    {
        protected override string PageTitle => "name or reference number (UKPRN)";

        private static By UKProviderReferenceNumberText => By.CssSelector("input[id='SearchTerm']");

        private static By AutoCompleteMenu => By.CssSelector("[id='SearchTerm__listbox']");

        private static By AutoCompleteOptions => By.CssSelector(".autocomplete__option");

        private static By FirstOption => By.CssSelector("[id='SearchTerm__option--0']");

        public AddPermissionsForTrainingProviderPage SearchForATrainingProvider(ProviderConfig providerConfig)
        {
            formCompletionHelper.EnterText(UKProviderReferenceNumberText, providerConfig.Name);

            context.Get<RetryAssertHelper>().RetryOnNUnitException(() =>
            {
                pageInteractionHelper.WaitForElementToChange(AutoCompleteMenu, "class", "autocomplete__menu--visible");

                pageInteractionHelper.WaitForElementToChange(FirstOption, AttributeHelper.InnerText, providerConfig.Ukprn);

                if (!pageInteractionHelper.IsElementDisplayed(FirstOption) && !pageInteractionHelper.GetStringCollectionFromElementsGroup(AutoCompleteOptions).ToList().Any(x=>x.ContainsCompareCaseInsensitive(providerConfig.Ukprn)))
                {
                    Assert.Fail($"Auto complete menu for list of providers does not pop up provider : {providerConfig.Name}, {providerConfig.Ukprn}");
                }

                pageInteractionHelper.FocusTheElement(FirstOption);

            }, RetryTimeOut.GetTimeSpan([10, 5, 5]));

            javaScriptHelper.ClickElement(FirstOption);

            Continue();

            return new AddPermissionsForTrainingProviderPage(context, providerConfig);
        }
    }

    public abstract class PermissionBasePageForTrainingProviderPage(ScenarioContext context) : EmployerProviderRelationshipsBasePage(context)
    {
        protected static By ApprenticeAllowRadioOption => By.Id("addRecords-1");
        protected static By ApprenticeDoNotAllowRadioOption => By.Id("addRecords-2");

        protected static By RecruitAllowRadioOption => By.Id("recruitApprentices-1");
        protected static By RecruitAllowConditionalRadioOption => By.Id("recruitApprentices-2");
        protected static By RecruitDoNotAllowRadioOption => By.Id("recruitApprentices-3");

        protected static By ErrorMsg => By.CssSelector(".govuk-error-summary");

        public YourTrainingProvidersPage AddOrSetPermissions((AddApprenticePermissions cohortpermission, RecruitApprenticePermissions recruitpermission) permisssion)
        {
            SetAddApprentice(permisssion.cohortpermission);

            SetRecruitApprentice(permisssion.recruitpermission);

            return new YourTrainingProvidersPage(context);
        }

        protected void SetAddApprentice(AddApprenticePermissions permission)
        {
            void Continue(By by) => javaScriptHelper.ClickElement(by);

            switch (permission)
            {
                case AddApprenticePermissions.AllowConditional: Continue(ApprenticeAllowRadioOption); break;
                case AddApprenticePermissions.DoNotAllow: Continue(ApprenticeDoNotAllowRadioOption); break;
            };
        }

        protected void SetRecruitApprentice(RecruitApprenticePermissions permission)
        {
            void ContinueToConfirm(By by)
            {
                javaScriptHelper.ClickElement(by);

                formCompletionHelper.ClickButtonByText(ContinueButton, "Confirm");
            }

            switch (permission)
            {
                case RecruitApprenticePermissions.Allow: ContinueToConfirm(RecruitAllowRadioOption); break;
                case RecruitApprenticePermissions.AllowConditional: ContinueToConfirm(RecruitAllowConditionalRadioOption); break;
                case RecruitApprenticePermissions.DoNotAllow: ContinueToConfirm(RecruitDoNotAllowRadioOption); break;
            };
        }

    }

    public class AddPermissionsForTrainingProviderPage(ScenarioContext context, ProviderConfig providerConfig) : PermissionBasePageForTrainingProviderPage(context)
    {
        protected override string PageTitle => $"Add {providerConfig.Name} and set permissions";

        public void VerifyDoNotAllowPermissions()
        {
            SetAddApprentice(AddApprenticePermissions.DoNotAllow);

            SetRecruitApprentice(RecruitApprenticePermissions.DoNotAllow);

            VerifyPage(ErrorMsg, "You must select yes for at least one permission for add apprentice records or recruit apprentices");
        }
    }

    public class SetPermissionsForTrainingProviderPage(ScenarioContext context) : PermissionBasePageForTrainingProviderPage(context)
    {
        protected override By PageHeader => By.CssSelector(".govuk-fieldset__heading");

        protected override string PageTitle => $"Set permissions";
    }
}
