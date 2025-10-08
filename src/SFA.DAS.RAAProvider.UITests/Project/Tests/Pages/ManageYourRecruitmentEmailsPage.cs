using OpenQA.Selenium;
using SFA.DAS.RAA.Service.Project.Tests.Pages;
using TechTalk.SpecFlow;

namespace SFA.DAS.RAAProvider.UITests.Project.Tests.Pages
{
    public class ManageYourRecruitmentEmailsPage(ScenarioContext context) : RaaBasePage(context)
    {
        protected override string PageTitle => "Manage your recruitment emails";
        private static By NotificationBannerTitleLocator => By.CssSelector(".govuk-notification-banner__title");
        private static By NotificationBannerHeadingLocator => By.CssSelector(".govuk-notification-banner__heading");

        public ManageYourRecruitmentEmailsPage SelectAndSaveEmailPreferences()
        {
            SelectRadioOptionByForAttribute("approved-rejected-mine");
            SelectRadioOptionByForAttribute("applications-mine");
            SelectRadioOptionByForAttribute("notify-now");
            SelectRadioOptionByForAttribute("vacancy-reviewed-mine");
            SelectRadioOptionByForAttribute("employer-publish-vacancy-rejected-all");

            formCompletionHelper.ClickButtonByText(SaveAndContinueButton, "Save settings");
            return this;
        }

        public ManageYourRecruitmentEmailsPage VerifyEmailSettingsConfirmationBanner()
        {
            var ExpectedBannerTitle = "Success";
            var ExpectedBannerHeading = "Recruitment email settings saved.";
            pageInteractionHelper.VerifyText(NotificationBannerTitleLocator, ExpectedBannerTitle);
            pageInteractionHelper.VerifyText(NotificationBannerHeadingLocator, ExpectedBannerHeading);
            return this;
        }

    }
}
